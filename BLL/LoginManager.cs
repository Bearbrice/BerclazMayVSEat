using DAL;
using DTO;

namespace BLL
{
    public class LoginManager : ILoginManager
    {
        private ILoginDB LoginDBObject { get; }

        public LoginManager(ILoginDB loginDB)
        {
            LoginDBObject = loginDB;
        }

        public int GetStaffId(string username)
        {
            return LoginDBObject.GetStaffId(username);
        }

        public int GetCustomerId(string username)
        {
            return LoginDBObject.GetCustomerId(username);
        }

        public Login AddLogin(Login login)
        {
            return LoginDBObject.AddLogin(login);
        }

        public bool IsItACustomer(string username)
        {
            return LoginDBObject.IsItACustomer(username);
        }

        public bool IsLoginValid(Login login)
        {
            return LoginDBObject.IsLoginValid(login);
        }

        public bool IsUsernameTaken(string username)
        {
            return LoginDBObject.IsUsernameTaken(username);
        }



    }
}
