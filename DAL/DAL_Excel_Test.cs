using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Excel_Test
    {
        private static bool testPassed = true;
        private static int testNum = 0;

        public void test_DAL_Excel()
        {
            // Each function here should test the matches function.
            testGetLine();
            testGetPassword();
            testSetPassword();

            // Notifying the user that the code have passed all tests.
            if (testPassed)
            Console.WriteLine("All " + testNum + " tests passed!");
        }

        /// <summary>
        /// This utility function will count the number of times it was invoked.
        /// In addition, if a test fails the function will print the error message.
        /// </summary>
        /// <param name="exp"></param> The actual test condition
        /// <param name="msg"></param> An error message, will be printed to the screen in case the test fails.
        private static void test(bool exp, String msg)
        {
            testNum++;
            if (!exp)
            {
                testPassed = false;
                Console.WriteLine("Test " + testNum + " failed: " + msg);
            }
        }

        /// <summary>
        /// Tests the getLone function.
        /// </summary>
        private static void testGetLine()
        {
            IDAL testDal = new DAL_Excel();

            test(testDal.getLine("zonkedbilled") == 1, "Value should be 1");
            test(testDal.getLine("soregusty") == 20, "Value should be 20");
            test(testDal.getLine("abrakadabra") == -1, "Value should be -1");
            try { testDal.getLine(null); }
            catch (Exception e)
            {
                test((e.Message).Equals("input is null"), "Should be thrown an Exception");
            }
        }

        /// <summary>
        /// Tests the getPassword function.
        /// </summary>
        private static void testGetPassword()
        {
            IDAL testDal = new DAL_Excel();

            test(testDal.getPassword(1) == "abc12345", "Value should be abc12345");
            test(testDal.getPassword(20) == "12121212", "Value should be 12121212");
            test(testDal.getPassword(5) == "1234abcd", "Value should be 1234abcd");
            try { testDal.getPassword(21); }
            catch (Exception e)
            {
                test((e.Message).Equals("There is no such user number"), "Should be thrown an Exception");
            }

            try { testDal.getPassword(40); }
            catch (Exception e)
            {
                test((e.Message).Equals("There is no such user number"), "Should be thrown an Exception");
            }
        }

        /// <summary>
        /// Tests the setPassword function.
        /// </summary>
        private static void testSetPassword()
        {
            IDAL testDal = new DAL_Excel();

            testDal.setPassword(4, "passcheck");
            test(testDal.getPassword(4) == "passcheck", "Value should be passcheck");
            testDal.setPassword(4, "12341234");
            test(testDal.getPassword(4) == "12341234", "Value should be 12341234");

        }
    }
}
