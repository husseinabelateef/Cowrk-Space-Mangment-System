using Cowrk_Space_Mangment_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace Cowrk_Space_Mangment_System.Repository
{
    public class LogingRepository : ILogingRepository
    {
        Context context;
        public LogingRepository(Context _context)
        {
            context = _context;
        }

        public List<Loging> GetAll()
        {
            return context.Loging.ToList();
        }

        public Loging GetById(int id)
        {
            return context.Loging.FirstOrDefault(Loging => Loging.Id == id);
        }

        public int Insert(Loging loging)
        {
            context.Loging.Add(loging);
            return context.SaveChanges();
        }

        public int Update(int id, Loging loging)
        {
            Loging oldLoging = GetById(id);
            if (oldLoging != null)
            {
                oldLoging.Login = loging.Login;
                oldLoging.LogOut=loging.LogOut;
                oldLoging.TotalHours = loging.TotalHours;
                oldLoging.Receptionst_Id=loging.Receptionst_Id;
                context.Entry(oldLoging).State = EntityState.Modified;
                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
        Loging oldLoging = GetById(id);
            context.Loging.Remove(oldLoging);
            return context.SaveChanges();
        }
        public Loging GetbyReceptionistId(string id)
        {
            Loging loging = context.Loging.
                FirstOrDefault(loging => loging.Receptionst_Id == id);
            return loging;
        }
    }
}
