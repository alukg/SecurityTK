using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BL;
using System.IO;

namespace SecurityTK_Test.Test
{
    [TestFixture]
    class DataLeakageTool_Test
    {

        private DataLeakageTool dlt;

        public DataLeakageTool_Test()
        {
            countWordsInLineTest();
        }

        [Test]
        public void checkInvalidInputsForFiles()
        {
            dlt = new DataLeakageTool();
            Assert.AreEqual(dlt.checkSensitivity("hello"), new IOException());    
        }

        [Test]
        public void countWordsInLineTest()
        {
            dlt = new DataLeakageTool();
            string sentence1 = "Subject: Re: Dayton P&L - 0002 Production - Sales";
            string[] sentence1Array = sentence1.Split(dlt.separators);
            for(int i=0; i<sentence1Array.Length; i++)
                Console.WriteLine(sentence1Array[i]);
            int countWords1 = dlt.countWordsInLine(sentence1Array);
            Assert.AreEqual(7, countWords1);


        }


    }
}
