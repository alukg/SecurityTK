using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;


namespace BL
{
    class DataLeakageTool
    {
        private DataLeakageDictionary dictionary;

        //building the mapping dictionary
        public DataLeakageTool()
        {
            dictionary = new DataLeakageDictionary();
        }

        /*
         * The function gets a folder path.
         * checking if the path is valid - if it isn't a file's path and if it exists.
         * for each file in the path we check it's sesitivity score.
         * returning a sorted dictionary of FileInfo and scores. 
         * file.Name -- gives the name of the file
         * file.FullName -- gives the path
         */
        public SortedDictionary<FileInfo,double> checkSensitivity(string path)
        {
            if (File.Exists(path)) 
                throw new IOException ("The given path is of a file and not of a folder");
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException("The path does not exist");

            DirectoryInfo directory= new DirectoryInfo(path);
            FileInfo [] fileNames = directory.GetFiles("*.txt"); //saving all the txt files' names in an array
            
            if (fileNames.Length == 0)
                throw new IOException("There are no text files in the folder");

            SortedDictionary<FileInfo, double> calculatedScores = new SortedDictionary<FileInfo, double>();

            //Going over all the file names in the folder
            for (int i=0; i<fileNames.Length; i++)
            {
                FileInfo file = new FileInfo(fileNames[i].FullName);

                //the memory mapping file will help using a large text file
                MemoryMappedFile mappedFile = MemoryMappedFile.CreateFromFile(file.FullName); 
                Stream stream = mappedFile.CreateViewStream();
                StreamReader sr = new StreamReader(stream, System.Text.Encoding.ASCII);
                double score = scanDocument(sr);

                calculatedScores.Add(file, score); // adding to our sorted dictionary the score of the file
            }

            return calculatedScores;
            
                        
        }

        // The function recieves a stream. It separates the text into words and calculate the score of each word.
        public double scanDocument(StreamReader sr)
        {
            double score = 0;
            int numberOfWords = 0;
            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                line = removesCharsAtEnd(line);
                string[] wordsOfSentence=line.Split(' ');
                numberOfWords += wordsOfSentence.Length;

                //we wish to check if one of the dangerous words appear in some form in the line
                //only if one of the word may appear in the current line, check it.
                if (checkIfSensitiveSentence(line))
                {
                    for (int i = 0; i < wordsOfSentence.Length; i++)
                    {
                        wordsOfSentence[i] = removesCharsAtEnd(wordsOfSentence[i]);
                        wordsOfSentence[i] = removesCharsInWord(wordsOfSentence[i]);
                        score += dictionary.getWordScore(wordsOfSentence[i]);
                    }      
                }
            }
            return calculateScore(numberOfWords,score);
        }
    
        /* The function gets a string, and removes the last character if it is
         * not a letter or a number.
         */
        public string removesCharsAtEnd(string s)
        {
            char lastChar = s[s.Length - 1];
            byte lastCharAscci = (byte)lastChar;
            if ((lastCharAscci >= 33 && lastCharAscci <= 47) || (lastCharAscci >= 91 && lastCharAscci <= 96))
                return s.Substring(0, s.Length - 1);
            else
                return s;
        }

        public string removesCharsInWord(string word)
        {
            byte[] asciiWord = Encoding.ASCII.GetBytes(word); // converting the word to ascci
            int i = 0, wordLength = word.Length;
            while(i< wordLength)
            {
                if ((asciiWord[i] >= 33 && asciiWord[i] <= 47) || (asciiWord[i] >= 91 && asciiWord[i] <= 96))
                {
                    string tempWord = word;
                    word = word.Substring(0, i) + tempWord.Substring(i + 1, wordLength - i + 1);
                    wordLength = word.Length;
                }
            }
            return word;
        }

        //checking if the sentence contains one of the dangerous words.
        public bool checkIfSensitiveSentence(string sentence)
        {
            return dictionary.isDangerousSentence(sentence);
        }



        // The function calculates the score of a document
        public double calculateScore(int numOfWords, double wordsScore)
        {
            double d = 1 / Math.Abs(numOfWords);
            return wordsScore * d;
        }
    }
}

