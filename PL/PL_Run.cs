using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedClasses;


namespace PL
{
    public class PL_Run: IPL
    {
        public void Run()
        {
            User tempUser = new User("Keren");

            //change password
            Console.WriteLine("user area:");
            Console.WriteLine("press '1' to change your password");
            changePassStep1(Console.ReadLine());
   
            Console.WriteLine("press '1' for a random password, or press '2' to set yourself");
            changePassStep2(Console.ReadLine(),tempUser);
        }

        

        public void changePassStep1(String s)
        {
            if(s.Length!=1 || s[0] != 1)
            {
                Console.WriteLine("wrong input. press '1' to change your password");
                changePassStep1(Console.ReadLine());
            }
        }


        public void changePassStep2(String s, User user)
        {
            BL.IBL ibl = new BL.BL_Function();
            if (s.Length == 1 && s[0] == '1')
            {
                ((BL.BL_Function)ibl).setPassword(user);
                
             //   Console.WriteLine("Your new password is:" +);
            }
            else if (s.Length == 1 && s[0] == '2')
            {
                Console.WriteLine("please enter a new password. the password should contain 8 characters and at least one number");
                string newPass = Console.ReadLine();
                bool ans = ((BL.BL_Function)ibl).checkPassword(newPass);
                while (!ans)
                {
                    Console.WriteLine("illegal password, please enter a new one. The password should contain 8 characters and at least one number");
                    newPass = Console.ReadLine();
                }
               ((BL.BL_Function)ibl).setPassword(user,newPass);
            }
            else
            {
                Console.WriteLine("wrong input. press '1' for a random password, or press '2' to set yourself") ;
                changePassStep2(Console.ReadLine(), user);
            }
        }
    } 
}
