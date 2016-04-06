using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using SharedClasses;


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
            string username = Console.ReadLine();
            Console.WriteLine("Please enter your password:");
            string password = Console.ReadLine();

            int NUM_OF_TRIES = 5;
            int counter = 1;
            bool isVerified = false;

            while (!isVerified)
            {
                while (!theBL.verifyCardentials(username,password) && counter < NUM_OF_TRIES)
                {
                    counter++;
                    Console.WriteLine("The entered username does not exist in our system, please re-enter your credentials:");
                    Console.WriteLine("Please enter your username:");
                    username = Console.ReadLine();
                    Console.WriteLine("Please enter your password:");
                    password = Console.ReadLine();
                }

                if (counter >= NUM_OF_TRIES)
                {
                    Environment.Exit(0);
                    counter = 1;
                }
                else {
                    isVerified = theBL.verifyCardentials(username, password);
                    if (!isVerified)
                    {
                        counter++;
                        Console.WriteLine("The password is incorrect");
                        Console.WriteLine("Please re-enter your username:");
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

                User tempUser = new User(username, theBL.findUsername(username),password);



                //change password
                Console.WriteLine("user area:");
                Console.WriteLine("press '1' to change your password or '0'to exit");
                changePassStep1(Console.ReadLine());

                Console.WriteLine("press '1' for a random password, or press '2' to set yourself");
                changePassStep2(Console.ReadLine(), tempUser);
                Console.Read(); // Keeps the console window open
            }

        }
        // check if the user enter illegal input
        public void changePassStep1(String s)
        {

            if (s[0] == '0')
            {
                Console.WriteLine("Thank you, and goodbye");
                Environment.Exit(0);
            }
            if (s.Length!=1 || s[0] != '1')
            {
                Console.WriteLine("wrong input. press '1' to change your password or '0'to exit");
                changePassStep1(Console.ReadLine());
            }

        }


        // check user's second input

        public void changePassStep2(string s, User user)

        {
            //change user password to a random one
            if (s.Length == 1 && s[0] == '1')
            {
                theBL.setPassword(user);
                Console.WriteLine("Your new password is:" +user.getPassword());
            }

            //change user password to a new one
            else if (s.Length == 1 && s[0] == '2')
            {
                Console.WriteLine("please enter a new password. the password should contain 8 characters and at least one number");
                string newPass = Console.ReadLine();
                bool ans = this.theBL.checkPassword(newPass);
                //check if the user enter illegal password
                while (!ans)
                {
                    Console.WriteLine("illegal password, please enter a new one. The password should contain 8 characters and at least one number");
                    newPass = Console.ReadLine();
                }

                theBL.setPassword(user,newPass);
                Console.WriteLine("Your password was successfuly changed!");

            }
            //check if the user enter illegal input
            else
            {
                Console.WriteLine("wrong input. press '1' for a random password, or press '2' to set yourself") ;
                changePassStep2(Console.ReadLine(), user);
            }
            Console.WriteLine("Press 0 to exit");
            string exit = Console.ReadLine();
            if (exit.Equals("0"))
            {
                Console.WriteLine("Thank you, and goodbye");
                Environment.Exit(0);
            }
            Console.Read();//keeps the screen open
        }
    } 
}
