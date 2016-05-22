using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedClasses;
using NUnit.Framework;

namespace DAL
{
    [TestFixture]
    public class DAL_SQL_Test
    {
        
        private IDAL db = new DAL_SQL();

        [TestCase]
        public void userNameExistsTest()
        {
            Assert.AreEqual(true, db.userNameExists("superBall"));
            Assert.AreEqual(true, db.userNameExists("superball"));
            Assert.AreEqual(false, db.userNameExists("supeall"));
            Assert.AreEqual(true, db.userNameExists("poWer2"));
        }

        [TestCase]
        public void getPasswordTest()
        {
            Assert.AreEqual("base0000", db.getPassword("superMan"));
            Assert.AreEqual("base0000", db.getPassword("superman"));
            Assert.AreNotEqual("bAse0000", db.getPassword("superman"));
            Assert.AreNotEqual("dragon02", db.getPassword("poWer2"));
            Assert.AreEqual("draGon02", db.getPassword("poWer2"));
        }

        [TestCase]
        public void getRoleTest()
        {
            Assert.AreEqual(Role.Employee, db.getRole("superMan"));
            Assert.AreNotEqual(Role.Manager, db.getRole("superMan"));
        }

        [TestCase]
        public void setAndRemoveUserTest()
        {
            db.setNewUser("Guy", "guy12345", Role.Employee);
            Assert.AreEqual(true, db.userNameExists("guy"));
            Assert.AreEqual("guy12345", db.getPassword("gUy"));
            Assert.AreEqual(Role.Employee, db.getRole("Guy"));
            db.removeUser("Guy");
            Assert.AreEqual(false, db.userNameExists("guy"));
        }

        [TestCase]
        public void setPasswordTest()
        {
            Assert.AreEqual("1234abcd", db.getPassword("lighter"));
            db.setPassword("lighter", "guy12345");
            Assert.AreEqual("guy12345", db.getPassword("lighter"));
            Assert.AreNotEqual("1234abcd", db.getPassword("lighter"));
            Assert.AreNotEqual("Guy12345", db.getPassword("lighter"));
            db.setPassword("lighter", "1234abcd");
            Assert.AreEqual("1234abcd", db.getPassword("lighter"));
        }

        [TestCase]
        public void setRoleTest()
        {
            Assert.AreEqual(Role.Administrator, db.getRole("snake"));
            Assert.AreNotEqual(Role.Employee, db.getRole("snake"));
            db.setRole("snake", Role.Employee);
            Assert.AreEqual(Role.Employee, db.getRole("snake"));
            db.setRole("snake", Role.Administrator);
            Assert.AreEqual(Role.Administrator, db.getRole("snake"));
        }
        
    }
}
