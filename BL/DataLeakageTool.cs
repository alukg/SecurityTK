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
        private Dictionary<string,double> mapping;

        //building the mapping dictionary
        public DataLeakageTool()
        {
            mapping.Add("classified", 1);
            mapping.Add("secret", 1);
            mapping.Add("password", 1);
            mapping.Add("restricted", 1);
            mapping.Add("private", 0.9);
            mapping.Add("sensitive", 0.8);
            mapping.Add("encrypt", 0.8);
            mapping.Add("pin", 0.8);
            mapping.Add("key", 0.8);
            mapping.Add("hash", 0.75);
            mapping.Add("break-in", 0.6);
            mapping.Add("credential", 0.6);
            mapping.Add("admin", 0.6);
            mapping.Add("virus", 0.6);
            mapping.Add("worm", 0.4);
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
            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                //we wish to check if one of the dangerous words appear in some form in the line
                bool contatins = false;
                foreach(var item in mapping)
                {
                    if (line.Contains(item.Key))
                        contatins = true;
                }

                //only if one of the word may appear in the current line, check it.
                if (contatins)
                {
                    byte[] asciiLine = Encoding.ASCII.GetBytes(line); // converting the line to ascci
                    int i = 0;
                    while (i < line.Length)
                    {
                        string word = "";

                        //as long as there are letters, add them to the word
                        while (asciiLine[i] >= 65 && asciiLine[i] <= 90 || asciiLine[i] >= 97 && asciiLine[i] <= 122 && i < line.Length)
                        {
                            word += line[i];
                            i++;
                        }
                        score += getScore(word); // getting the score of each word in the document

                        //as long as the next character in the line is not a line, ignore it
                        while (asciiLine[i] <= 65 && asciiLine[i] >= 90 || asciiLine[i] <= 97 && asciiLine[i] >= 122 && i < line.Length)
                            i++;
                    }
                }
            }
            return score;
        }


        //The function calulates the score of a word
        public double getScore(string word)
        {
            double score = 0.0;
            if (mapping.ContainsKey(word)) //if a word is one of the dangerous words, get the score
                score = mapping[word]; 
            return score;
        }
    }
}
