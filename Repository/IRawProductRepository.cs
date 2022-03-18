using System.Collections.Generic;
using Cowrk_Space_Mangment_System.Models;
namespace Cowrk_Space_Mangment_System.Repository
{
    public interface IRawProductRepository: Irepository<RawProduct,int>
    {
        public List<RawProduct> ExpiredRaw();
    }
}
