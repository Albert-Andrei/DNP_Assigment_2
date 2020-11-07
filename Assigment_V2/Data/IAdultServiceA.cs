using System.Collections.Generic;
using System.Threading.Tasks;
using Assigment_V2.Model;

namespace Assigment_V2.Data
{
    public interface IAdultServiceA
    {
        Task<IList<Adult>> GetAdultsAsync();
        Task AddAdultsAsync(Adult adult);
        Task RemoveAdultsAsync(int personId);
        Task UpdateAdultsAsync(Adult adult);
    }
}