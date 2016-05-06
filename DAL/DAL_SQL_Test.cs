using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DAL
{
    [TestFixture]
    public class DAL_SQL_Test
    {
        IDAL db = new DAL_SQL();

        [TestCase]
        public void userNameExistsTest()
        {
            Assert.AreEqual(false, db.userNameExists("superBall"));
            Assert.AreEqual(true, db.userNameExists("superball"));
        }
    }
}
