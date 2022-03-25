using Cowrk_Space_Mangment_System.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cowrk_Space_Mangment_System.Repository
{
    public interface IReceptionistRepository : Irepository<Receptionist, int>
    {
        Task<int> UpdateAsync(int id, Receptionist Receptionist);

        Task<int> DeleteAsync(int id);
   
    }
}