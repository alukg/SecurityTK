namespace SharedClasses
{
    public enum Role { Administrator, Manager, Employee, Guest };

    public class User
    {
        public readonly string userName;
        public readonly string password;
        public readonly Role role;

        //Constractor
        public User(string userName, string password, Role role)
        {
            this.userName = userName;
            this.password = password;
            this.role = role;
        }
    }
}
