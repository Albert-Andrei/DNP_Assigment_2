using System.Threading.Tasks;
using Assigment_V2.Model;

namespace Assigment_V2.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string Password);
    }
}