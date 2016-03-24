using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace PL
{
    public class PL_Run: IPL
    {

        private IBL theBL;

        //constractor
        public PL_Run(IBL theBL)
        {
            this.theBL= theBL;
        }


        public void Run()
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("Please enter your username:");
            Console.WriteLine("Please enter your password:");
            string username = Console.ReadLine();
            
            string password = Console.ReadLine();
            
            int NUM_OF_TRIES = 5;
            int counter = 0;
            bool isVerified = false;

            while(!isVerified)
            {
                while (theBL.findUsername(username) == -1 && counter<NUM_OF_TRIES)
                {
                    counter++;
                    Console.WriteLine("The entered username does not exist in our system, please re-renter your credentials:");
                    Console.WriteLine("Please enter your username:");
                    username = Console.ReadLine();
                    Console.WriteLine("Please enter your password:");
                    password = Console.ReadLine();
                }

                if (counter >= NUM_OF_TRIES)
                {
                    Environment.Exit(0);
                    counter = 0;
                }
                else {
                    isVerified = theBL.verifyCardentials(username, password);
                    if (!isVerified)
                    {
                        counter++;
                        Console.WriteLine("Please enter your username:");
                        username = Console.ReadLine();
                        Console.WriteLine("Please enter your password:");
                        password = Console.ReadLine();
                    }
                }
            }
            if (counter >= NUM_OF_TRIES)
            {
                Environment.Exit(0);
                counter = 0;
            }
            else if (isVerified)
            {
                Console.WriteLine("Hello " + username);
            }

            Console.Read(); // Keeps the console window open

        }
    }
}
