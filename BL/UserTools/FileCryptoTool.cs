using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Collections;

namespace BL.UserTools
{
    public class FileCryptoTool
    {
        private RijndaelManaged crypto;

        //constructor
        public FileCryptoTool()
        {
            crypto = new RijndaelManaged();
        }

        /*the function gets a file to encrypt, the destination path to save the file to
         * and a password (will be the encryption key).
         * The function creates a new encrypted file.
         */
        public void encrypt(string filePath,string destinationPath,string password)
        {
            try
            {
                crypto.Padding = PaddingMode.PKCS7;
                FileInfo origin = new FileInfo(@filePath);

                //creating the path of the encrypted file
                destinationPath = destinationPath +"\\encrypted_"+ origin.Name; 

                byte[] passwordByte = ASCIIEncoding.ASCII.GetBytes(password);
                passwordByte = createValidKey(passwordByte, password); //getting a valid sized key
             
                using (FileStream destinationFile = new FileStream(destinationPath, FileMode.Create))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(destinationFile, crypto.CreateEncryptor(passwordByte, passwordByte), CryptoStreamMode.Write))
                    {
                        using (FileStream originFile = new FileStream(@filePath, FileMode.Open))
                        {
                            int b;
                            while ((b = originFile.ReadByte()) != -1)
                                cryptoStream.WriteByte((byte)b);
                        }
                        
                    }
                }
            }
            catch (Exception e)
            {
                if (e.Message.Contains("Padding"))
                    Console.WriteLine("The decryption key is invalid, please enter the correct key");
                else
                    Console.WriteLine(e.Message);
            }

        }

        public void decrypt(string filePath, string destinationPath, string password)
        {
            try
            {
                crypto.Padding = PaddingMode.PKCS7;
                FileInfo origin = new FileInfo(@filePath);

                //checking if the input file is encrypted.
                if (!origin.Name.Contains("encrypted_"))
                    throw new Exception("The file is not encrypted");

                //creating the path of the encrypted file
                destinationPath = destinationPath + "\\decrypted_" + origin.Name.Substring(10);

                byte[] passwordByte = ASCIIEncoding.ASCII.GetBytes(password);

                passwordByte = createValidKey(passwordByte, password); //getting a valid sized key


                using (FileStream destinationFile = new FileStream(destinationPath, FileMode.Create))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(destinationFile, crypto.CreateDecryptor(passwordByte, passwordByte), CryptoStreamMode.Write))
                    {
                        using (FileStream originFile = new FileStream(@filePath, FileMode.Open))
                        {
                            int b;
                            while ((b = originFile.ReadByte()) != -1)
                                cryptoStream.WriteByte((byte)b);
                        }

                    }
                }
            }
            catch(Exception e)
            {
                if (e.Message.Contains("Padding"))
                    Console.WriteLine("The decryption key is invalid, please enter the correct key");
                else
                    Console.WriteLine(e.Message);
            }
        }
        /*
         * The function recieves a byte array and password. if the password size is not
         * 128/196/256 bits then the function converts it into a valid size.
         */ 
        private byte[] createValidKey(byte[] passwordByte,String password)
        {
            BitArray ba = new BitArray(passwordByte);
            int n = ba.Length;
            if (ba.Length > 256)
            {
                int difference = (ba.Length - 256) / 8;
                password = password.Substring(difference);
                Console.WriteLine(password);
                passwordByte = ASCIIEncoding.ASCII.GetBytes(password);
            }
            else
            {
                if (ba.Length != 128 && ba.Length != 196 && ba.Length != 256)
                {
                    int difference = 0;
                    if (ba.Length < 128)
                        difference = (128 - ba.Length) / 8;
                    else if (ba.Length > 128 && ba.Length < 196)
                        difference = (196 - ba.Length) / 8;
                    else if (ba.Length > 196 && ba.Length < 256)
                        difference = (256 - ba.Length) / 8;

                    for (int i = 0; i < difference; i++)
                    {
                        password += password[i % password.Length];
                        passwordByte = ASCIIEncoding.ASCII.GetBytes(password);
                        ba = new BitArray(passwordByte);
                    }
                }
            }
            return passwordByte;
        }


    }
}
