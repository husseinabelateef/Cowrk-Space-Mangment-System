using Cowrk_Space_Mangment_System.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cowrk_Space_Mangment_System.Repository
{
    public class AdminRepository : IAdminRepository
    {

        Context context;
        public AdminRepository(Context _context)
        {
            context = _context;
        }
        public List<Admin> GetAll()
        {
            List<Admin> list = context.Admin.ToList();
            return list;
        }

        public Admin GetById(int id)
        {
            return context.Admin.FirstOrDefault(admin => admin.ID == id);
        }

        public int Insert(Admin admin)
        {
            context.Admin.Add(admin);
            return context.SaveChanges();
        }

        public int Update(int id, Admin admin)
        {
            Admin oldAdmin = GetById(id);
            if (oldAdmin != null)
            {
                oldAdmin.Name = oldAdmin.Name;
                oldAdmin.Email = oldAdmin.Email;
                oldAdmin.Username=oldAdmin.Username;
                oldAdmin.password = oldAdmin.password;
                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            Admin oldAdmin = GetById(id);
            context.Admin.Remove(oldAdmin);
            return context.SaveChanges();
        }
      
    }
}
