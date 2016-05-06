using NUnit.Framework;
using System;
using DAL;

namespace BL
{
    [TestFixture]
    public class BL_Process_Test
    {
        private BL_Process blp = new BL_Process(new DAL_SQL());

        /*
        [TestCase]
        //[ExpectedException(typeof(ArgumentNullException))]
        public void UserVarificationTest()
        {
            Assert.AreEqual(true,blp.userVarification("superball", "12341234"));
            Assert.AreEqual(false,blp.userVarification("superBall", "12341234"));
            Assert.AreEqual(false,"superball".Equals("superBall"));
        }
        */
    }
}
