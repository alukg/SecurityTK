using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class Serializer
    {
        public static void saveToBinaryFile(Dictionary<string,string> objectToWrite)
        {
            Stream myFileStream = new FileStream("UsersDB.bin", FileMode.Open);
            BinaryFormatter myFormatter = new BinaryFormatter();
            myFormatter.Serialize(myFileStream, objectToWrite);
            myFileStream.Close();
        }

        public static Dictionary<string, string> getFromBinaryFile()
        {
            Dictionary<string, string> UsersDB = new Dictionary<string, string>();
            if (File.Exists("UsersDB.bin"))
            {
                Stream myFileStream = new FileStream("UsersDB.bin", FileMode.Open);
                BinaryFormatter myFormatter = new BinaryFormatter();
                UsersDB = (Dictionary<string, string>)myFormatter.Deserialize(myFileStream);
                myFileStream.Close();
                return UsersDB;
            }
            else
            {
                throw new Exception("The DataBase file doesn't exsist");
            }
        }
    }
}
