using DTO;

namespace BLL
{
    public interface ILoginManager
    {
        Login AddLogin(Login login);

        int GetStaffId(string username);

        int GetCustomerId(string username);

        bool IsItACustomer(string username);

        bool IsLoginValid(Login login);

        bool IsUsernameTaken(string username);
    }
}