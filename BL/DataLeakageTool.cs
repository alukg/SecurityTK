using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

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
        public void checkSensitivity(string path)
        {
            if (File.Exists(path)) 
                throw new IOException ("The given path is of a file and not of a folder");
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException("The path does not exist");

            DirectoryInfo directory= new DirectoryInfo(path);
            FileInfo [] fileNames = directory.GetFiles("*.txt"); //saving all the txt files' names in an array

            if (fileNames.Length == 0)
                throw new IOException("There are no text files in the folder");

                        
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
