using Cowrk_Space_Mangment_System.Models;
namespace Cowrk_Space_Mangment_System.Repository
{
    public interface ILogingRepository : Irepository<Loging, int>
    {
        public Loging GetbyReceptionistId(string id);
    }
}
