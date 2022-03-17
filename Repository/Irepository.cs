using System.Collections.Generic;

namespace Cowrk_Space_Mangment_System.Repository
{
    public interface Irepository <T,T1>
    {
        List<T> GetAll();
        int Delete(T1 id);
        T GetById(T1 id);
        int Insert(T item);
        int Update(T1 id, T item);
    }
}
