using Cowrk_Space_Mangment_System.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cowrk_Space_Mangment_System.Repository
{
    public interface IReceptionistRepository : Irepository<Receptionist, string>
    {
        Task<int> UpdateAsync(string id, Receptionist Receptionist);

        Task<int> DeleteAsync(string id);
   
    }
}