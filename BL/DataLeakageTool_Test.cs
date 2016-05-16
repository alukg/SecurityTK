using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BL
{
    [TestFixture]
    class DataLeakageTool_Test
    {
        private DataLeakageTool dlt = new DataLeakageTool();

        [TestCase]
        public void countWordsInLine_Test()
        {
            Assert.AreEqual(5, dlt.countWordsInLine("From: phillip.allen@enron.com".Split(dlt.getSeparators(), StringSplitOptions.RemoveEmptyEntries)));
            Assert.AreEqual(9, dlt.countWordsInLine("X-Folder: -Phillip_Allen_Dec2000-Notes Folders\'sent mail".Split(dlt.getSeparators(), StringSplitOptions.RemoveEmptyEntries)));
            Assert.AreEqual(7, dlt.countWordsInLine("i wish the input would be 7!".Split(dlt.getSeparators(), StringSplitOptions.RemoveEmptyEntries)));
            Assert.AreEqual(0, dlt.countWordsInLine("@##$$#%^$".Split(dlt.getSeparators(), StringSplitOptions.RemoveEmptyEntries)));
        }

        [TestCase]
        public void removeCharsInWord_test()
        {
            Assert.AreEqual(2, dlt.removesCharsInWord("Rotem%Avni"));
            Assert.AreEqual(0, dlt.removesCharsInWord("%^"));
            Assert.AreEqual(2, dlt.removesCharsInWord("Test1.milestone2:"));
            Assert.AreEqual(3, dlt.removesCharsInWord("Test1.milestone2:start"));
            Assert.AreEqual(1, dlt.removesCharsInWord("Testing"));
            Assert.AreEqual(0, dlt.removesCharsInWord(""));

        }

        [TestCase]
        public void getNewSentence_Test()
        {
            string sentence1 = "Bcc: steve.gillespie@enron.com";
            string[] sentence1Array = sentence1.Split(' ');
            string[] sentence1ArrayExpected = new string[] { "Bcc", "steve", "gillespie", "enron", "com" };
            Assert.AreEqual(sentence1ArrayExpected, dlt.getNewSentence(sentence1Array, 5));
            
            string sentence2 = "Message-ID: <31107389.1075853843650.JavaMail.evans@thyme>";
            string[] sentence2Array = sentence2.Split(' ');
            string[] sentence2ArrayExpected = new string[] { "Message", "ID", "31107389", "1075853843650", "JavaMail", "evans", "thyme" };
            Assert.AreEqual(sentence2ArrayExpected, dlt.getNewSentence(sentence2Array, 7));

            string sentence3 = "Content-Type: text/plain; charset=us-ascii";
            string[] sentence3Array = sentence3.Split(' ');
            string[] sentence3ArrayExpected = new string[] { "Content", "Type", "text", "plain", "charset", "us", "ascii" };
            Assert.AreEqual(sentence3ArrayExpected, dlt.getNewSentence(sentence3Array, 7));

        }

        [TestCase]
        public void checkIfSensitiveSentence_Test()
        {
            Assert.AreEqual(false, dlt.checkIfSensitiveSentence("Content-Type: text/plain; charset=us-ascii"));
            Assert.AreEqual(true, dlt.checkIfSensitiveSentence("Today's focus: Super-secretive Linux By Phil Hochmuth Network Associates is teaming up with the Nationa"));
            Assert.AreEqual(false, dlt.checkIfSensitiveSentence("Security Agency, the government's top electronic cryptography and spying institution, to help the agency fine - tune its highly secure version of Linux. The goal is to create a version of Linux that is impervious to outside attacks. Security Enhanced Linux, or SELinux, is a project under development"));
        }
    }
}
