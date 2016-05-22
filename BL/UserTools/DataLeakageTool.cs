using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;

namespace BL.UserTools
{
    public class DataLeakageTool
    {
        private DataLeakageDictionary dictionary;
        private char[] separators;
        private SortedDictionary<double,FileInfo> calculatedScore;

        //building the mapping dictionary
        public DataLeakageTool()
        {
            dictionary = new DataLeakageDictionary();
            separators = new char[] { ' ', '!', '\"', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '+', '=', '/', '.','?','<','>',';', ',','~','`','|' , '\\' , '{', '}','[',']', ',','@',':'};
            calculatedScore= new SortedDictionary<double, FileInfo>();
        }

        /*
         * The function gets a folder path.
         * checking if the path is valid - if it isn't a file's path and if it exists.
         * for each file in the path we check it's sesitivity score.
         * returning a sorted dictionary of FileInfo and scores. 
         * file.Name -- gives the name of the file
         * file.FullName -- gives the path
         */
        public SortedDictionary<double, FileInfo> checkSensitivity(string path)
        {
            try
            {
                isPathLegal(path);
                DirectoryInfo directory = new DirectoryInfo(@path);
                FileInfo[] fileNames = directory.GetFiles("*.txt"); //saving all the txt files' names in an array
                double lie = -1;

                if (fileNames.Length == 0)
                    throw new IOException("There are no text files in the folder");

                //Going over all the file names in the folder
                for (int i = 0; i < fileNames.Length; i++)
                {
                    FileInfo file = new FileInfo(fileNames[i].FullName);

                    //the memory mapping file will help using a large text file
                    MemoryMappedFile mappedFile = MemoryMappedFile.CreateFromFile(file.FullName);
                    Stream stream = mappedFile.CreateViewStream();
                    StreamReader sr = new StreamReader(stream, System.Text.Encoding.ASCII);
                    double score =scanDocument(sr);
                    
                    if(score==0)
                    {
                        score = lie;
                        lie--;
                    }
                    if (calculatedScore.ContainsKey(score))
                        score = findSimilarValue(score);
                    lock (calculatedScore)
                    {
                        calculatedScore.Add(score, file); // adding to our sorted dictionary the score of the file
                    }
                    sr.Close();
                    stream.Close();
                    mappedFile.Dispose();
                }

                return calculatedScore;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }               
        }

        private bool isPathLegal(string path)
        {
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException("The path does not exist");
            if (File.Exists(path)) 
                throw new IOException ("The given path is of a file and not of a folder");

            return true;
        }

        // The function recieves a stream. It separates the text into words and calculate the score of each word.
        private double scanDocument(StreamReader sr)
        {
            double score = 0;
            int numberOfWords = 0;
            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                char[] c = new char[] { ' ' };

                string[] wordsOfSentence=line.Split(c,StringSplitOptions.RemoveEmptyEntries);// spliting the line into words.

                int tempCount = countWordsInLine(wordsOfSentence);
                numberOfWords += tempCount;

                //we wish to check if one of the dangerous words appear in some form in the line
                //only if one of the word may appear in the current line, check it.
                if (checkIfSensitiveSentence(line))
                {
                    //if there are "hidden" words in the sentence, separate them.
                    if (tempCount != wordsOfSentence.Length)
                        wordsOfSentence = getNewSentence(wordsOfSentence,tempCount);
                    //for each word in line, calculate its score.
                    for (int i = 0; i < wordsOfSentence.Length; i++)
                        score += dictionary.getWordScore(wordsOfSentence[i]);    
                }
            }
            return calculateScore(numberOfWords,score);
        }

        /* The function gets an array of strings representing words
         * The function checks if there are more words in the sentece, 
         * for example if they were separated by a charachter other then space.
         * The function returns the number of words in the sentence. 
         */
        private int countWordsInLine(string[] wordsOfSentence)
        {
            int count = wordsOfSentence.Length;
            for (int i = 0; i < wordsOfSentence.Length; i++)
            {
                count += removesCharsInWord(wordsOfSentence[i])-1;
                if (wordsOfSentence[i].Equals(""))
                    count--;
            }
            return count;
        }


        /*
         * The function gets a string and separates it to different words, if there are any.
         */
        private int removesCharsInWord(string word)
        {
            //if the word is actully one illegal char
            if (word.Length == 1)
            {
                char c = word[0];
                if (separators.Contains(c))
                    return 0;
            }

            string[] separatedWord = word.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int count = separatedWord.Length;
            if (count == 0)
                return 0;
            if (count < 2 || separatedWord == null)
            {
                return 1;
            }
            else
            {
                if (separatedWord[0].Equals(""))
                    count--;
                for (int i = 0; i < separatedWord.Length - 1; i++)
                    if (separatedWord[i + 1].Equals(""))
                        count = count - 1;
            }
            return count;
        }

        /*
         * The function gets a sentence and separates it better, according to chars
         * that are not a space.
         */
        private string [] getNewSentence(string[] sentence, int numOfWords)
        {
            //initializing the new array
            string[] newSentence = new string[numOfWords];
            int index = 0;
            for(int i=0; i<sentence.Length; i++)
            {
                int numOfSubWords = removesCharsInWord(sentence[i]);
                if (numOfSubWords>1)
                {
                    int length;
                    string[] subWords = sentence[i].Split(separators,StringSplitOptions.RemoveEmptyEntries);
                    if (subWords[subWords.Length - 1].Equals(""))
                        length = subWords.Length - 1;
                    else
                        length = subWords.Length;

                    for (int j = 0; j < length; j++)
                        newSentence[index + j] = subWords[j];
                    index = index + length;
                }
                else if(numOfSubWords!=0)
                {
                    String []temp=sentence[i].Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    sentence[i] = temp[0];
                    newSentence[index] = sentence[i];
                    index++;
                }
            }

            return newSentence;
        }


        //checking if the sentence contains one of the dangerous words.
        private bool checkIfSensitiveSentence(string sentence)
        {
            return dictionary.isDangerousSentence(sentence);
        }



        // The function calculates the score of a document
        private double calculateScore(int numOfWords, double wordsScore)
        {
            double d = 1.0 / (Math.Abs(numOfWords));
            return wordsScore * d;
        }

        /*
         * This function is used in a rare case, when the dictionary already contains
         * a key with the same score as we wish to insert. 
         * The function finds the most similar value to our input in order to be able
         * to insert it to the dictionary
         */
        private double findSimilarValue(double score)
        {
            while (calculatedScore.ContainsKey(score))
                score=score+ 0.000000000001;
            return score;
        }

        private char[] getSeparators()
        {
            return this.separators;
        }

        private SortedDictionary<double,FileInfo> getDictionary()
        {
            return this.calculatedScore;
        }

        

    }
}

