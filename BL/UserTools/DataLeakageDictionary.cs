using System;
using System.Collections.Generic;

namespace BL.UserTools
{
    public class DataLeakageDictionary
    {
        private Dictionary<string, double> mapping;

        public DataLeakageDictionary()
        {
            mapping = new Dictionary<string, double>();

            mapping.Add("classified", 1);
            mapping.Add("secret", 1);
            mapping.Add("secrets", 1);
            mapping.Add("secretive", 1);
            mapping.Add("secret's", 1);
            mapping.Add("password", 1);
            mapping.Add("passwords", 1);
            mapping.Add("password's", 1);
            mapping.Add("restricted", 1);
            mapping.Add("restricted's", 1);
            mapping.Add("private", 0.9);
            mapping.Add("private's", 0.9);
            mapping.Add("sensitive", 0.8);
            mapping.Add("sensitive's", 0.8);
            mapping.Add("encrypt", 0.8);
            mapping.Add("encrypting", 0.8);
            mapping.Add("encrypts", 0.8);
            mapping.Add("encrypted", 0.8);
            mapping.Add("pin", 0.8);
            mapping.Add("pins", 0.8);
            mapping.Add("pin's", 0.8);
            mapping.Add("key", 0.8);
            mapping.Add("keys", 0.8);
            mapping.Add("key's", 0.8);
            mapping.Add("hash", 0.75);
            mapping.Add("hashing", 0.75);
            mapping.Add("hashed", 0.75);
            mapping.Add("hashes", 0.75);
            mapping.Add("break-in", 0.6);
            mapping.Add("breaks-in", 0.6);
            mapping.Add("breaked-in", 0.6);
            mapping.Add("credential", 0.6);
            mapping.Add("credentials", 0.6);
            mapping.Add("credential's", 0.6);
            mapping.Add("admin", 0.6);
            mapping.Add("admins", 0.6);
            mapping.Add("virus", 0.6);
            mapping.Add("viruses", 0.6);
            mapping.Add("virus's", 0.6);
            mapping.Add("worm", 0.4);
            mapping.Add("worms", 0.4);
            mapping.Add("worm's", 0.4);
        }

        //The function calculates the score of a word.
        //comparing strings regardless to their case.
        public double getWordScore(string word)
        {
            foreach (var item in mapping)
                if (String.Equals(word, item.Key, StringComparison.CurrentCultureIgnoreCase))
                    return item.Value;
            return 0;
        }

        //checking if the sentence contains one of the dangerous words.
        public bool isDangerousSentence(string sentence)
        {
            foreach (var item in mapping)
                if (sentence.Contains(item.Key))
                    return true;
            return false;
        }
    }
}
