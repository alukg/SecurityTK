
namespace SharedClasses
{
    public class User
    {
        public readonly string userName;
        public readonly string password;
        public readonly string role;

        //Constractor
        public User(string userName, string password, string role)
        {
            this.userName = userName;
            this.password = password;
            this.role = role;
        }
    }
}
