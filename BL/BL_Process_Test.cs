
using DAL;
using NUnit.Framework;
using SharedClasses;

namespace BL
{
    [TestFixture]
    public class BL_Process_Test
    {
        private BL_Process blp = new BL_Process(new DAL_SQL());
        private DAL_SQL db = new DAL_SQL();

        [TestCase]
        public void UserVarificationTest()
        {
            Assert.AreEqual(true,blp.userVarification("superball", "12341234"));
            Assert.AreEqual(true,blp.userVarification("superBall", "12341234"));
            Assert.AreEqual(false, blp.userVarification("poWer2", "dragon02"));
            Assert.AreEqual(true, blp.userVarification("poWer2", "draGon02"));
            Assert.AreEqual(false, blp.userVarification("yossi", "dragon02"));
        }

        [TestCase]
        public void changeRoleTest()
        {
            blp.currUser = new User("superball", "12341234", Role.Manager);
            Assert.AreEqual("No permission to perform the operation", blp.changeRole("yossi", Role.Employee));
            blp.currUser = new User("superball", "12341234", Role.Administrator);
            Assert.AreEqual("Username don't exits", blp.changeRole("yossi", Role.Employee));
            Assert.AreEqual(Role.Administrator, db.getRole("snake"));
            Assert.AreEqual("Role changed successfully", blp.changeRole("snake", Role.Manager));
            Assert.AreEqual(Role.Manager, db.getRole("snake"));
            Assert.AreEqual("Role changed successfully", blp.changeRole("snake", Role.Administrator));
            Assert.AreEqual(Role.Administrator, db.getRole("snake"));
        }

        [TestCase]
        public void changePassTest()
        {
            blp.currUser = new User("billy", "abc12345", Role.Employee);
            Assert.AreEqual("Password is not good", blp.changePass("superball", "123456789"));
            Assert.AreEqual("Password is not good", blp.changePass("superball", "abcdefgh"));
            Assert.AreEqual("Username does not exist", blp.changePass("yossi", "123456789"));
            Assert.AreEqual("Password changed successfully. The new password is: 12345678", blp.changePass("billy", "12345678"));
            Assert.AreEqual("12345678", blp.currUser.password);
            Assert.AreEqual("12345678", db.getPassword("billy"));
            Assert.AreEqual("There is no permissions", blp.changePass("power2", "12345678"));
            blp.currUser = new User("lighter", "1234abcd", Role.Manager);
            Assert.AreEqual("There is no permissions", blp.changePass("snake", "12345678"));
            Assert.AreEqual("Password changed successfully. The new password is: abc12345", blp.changePass("billy", "abc12345"));
            Assert.AreEqual("abc12345", db.getPassword("billy"));
            Assert.AreNotEqual("abc12345", blp.currUser.password);
            blp.currUser = new User("snake", "qwerty12", Role.Administrator);
            Assert.AreEqual("The new password identical to the current one", blp.changePass("billy", "abc12345"));
        }

        [TestCase]
        public void addUserTest()
        {
            Assert.AreEqual(false, db.userNameExists("guy"));
            blp.currUser = new User("billy", "abc12345", Role.Employee);
            Assert.AreEqual("No permission to perform the operation", blp.addUser("guy", "a1a1a1a1", Role.Administrator));
            blp.currUser = new User("lighter", "1234abcd", Role.Manager);
            Assert.AreEqual("That Username already taken", blp.addUser("snAke", "a1a1a1a1", Role.Administrator));
            Assert.AreEqual("Password is not good", blp.addUser("guy", "a1a1a1a1a", Role.Administrator));
            Assert.AreEqual("There is no permission to add user with that role", blp.addUser("guy", "a1a1a1a1", Role.Administrator));
            blp.currUser = new User("snake", "qwerty12", Role.Administrator);
            Assert.AreEqual("User added successfully. The password is: a1a1a1a1", blp.addUser("guy", "a1a1a1a1", Role.Administrator));
            Assert.AreEqual(true, db.userNameExists("guY"));
            Assert.AreEqual(true, blp.addUser("guy2", Role.Administrator).Contains("successfully"));
            Assert.AreEqual(true, db.userNameExists("guY2"));
            db.removeUser("Guy");
            db.removeUser("Guy2");
            Assert.AreEqual(false, db.userNameExists("guy"));
            Assert.AreEqual(false, db.userNameExists("guy2"));
        }
    }
}
