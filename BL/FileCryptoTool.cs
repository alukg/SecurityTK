using System;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Collections;

namespace BL
{
    public class FileCryptoTool
    {
        private RijndaelManaged crypto;
        public FileCryptoTool()
        {
            this.crypto = new RijndaelManaged();
            crypto.Padding=PaddingMode.PKCS7;
        }

        public void encrypt(string filePath,string destinationPath,string password)
        {
            try
            {
                FileInfo origin = new FileInfo(@filePath);
                destinationPath = destinationPath +"\\encrypted_"+ origin.Name;
                byte[] passwordByte = System.Text.Encoding.Unicode.GetBytes(password);
                passwordByte = createValidKey(passwordByte, password); //getting a valid sized key

             
                using (FileStream destinationFile = new FileStream(destinationPath, FileMode.Create))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(destinationFile, crypto.CreateEncryptor(passwordByte, passwordByte), CryptoStreamMode.Write))
                    {
                        using (FileStream originFile = new FileStream(@filePath, FileMode.Open))
                        {
                            int counter;
                            while ((counter = originFile.ReadByte()) != -1)
                                cryptoStream.WriteByte((byte)counter);
                        }
                        
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }



        public void decrypt(string filePath, string destinationPath, string password)
        {
            try
            {
                FileInfo origin = new FileInfo(@filePath);
                if (!origin.Name.Contains("encrypted_"))
                    throw new Exception("The file is not encrypted");
                destinationPath = destinationPath + "\\" + origin.Name.Substring(10);

                byte[] passwordByte = System.Text.Encoding.Unicode.GetBytes(password);
                passwordByte = createValidKey(passwordByte, password); //getting a valid sized key


                using (FileStream destinationFile = new FileStream(destinationPath, FileMode.Create))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(destinationFile, crypto.CreateDecryptor(passwordByte, passwordByte), CryptoStreamMode.Read))
                    {
                        using (FileStream originFile = new FileStream(@filePath, FileMode.Open))
                        {
                            int counter;
                            while ((counter = originFile.ReadByte()) != -1)
                                cryptoStream.WriteByte((byte)counter);
                        }

                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /*
         * The function recieves a byte array and password. if the password size is not
         * 128/196/256 bits then the function converts it into a valid size.
         */ 
        private byte[] createValidKey(Byte[] passwordByte,String password)
        {
            BitArray ba = new BitArray(passwordByte);
            int n = ba.Length;
            if (ba.Length > 256)
            {
                int difference = (ba.Length - 256) / 16;
                password = password.Substring(difference);
                Console.WriteLine(password);
                passwordByte = System.Text.Encoding.Unicode.GetBytes(password);
            }
            else
            {
                if (ba.Length != 128 && ba.Length != 196 && ba.Length != 256)
                {
                    int difference = 0;
                    if (ba.Length < 128)
                        difference = (128 - ba.Length) / 16;
                    else if (ba.Length > 128 && ba.Length < 196)
                        difference = (196 - ba.Length) / 16;
                    else if (ba.Length > 196 && ba.Length < 256)
                        difference = (256 - ba.Length) / 16;

                    for (int i = 0; i < difference; i++)
                    {
                        password += password[i % password.Length];
                        passwordByte = System.Text.Encoding.Unicode.GetBytes(password);
                        ba = new BitArray(passwordByte);
                    }
                }
            }
            return passwordByte;


        }


    }
}
