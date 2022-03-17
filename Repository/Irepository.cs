using System.Collections.Generic;

namespace Cowrk_Space_Mangment_System.Repository
{
    public interface Irepository <T>
    {
        List<T> GetAll();
        int Delete(int id);
        T GetById(int id);
        int Insert(T item);
        int Update(int id, T item);
    }
}
