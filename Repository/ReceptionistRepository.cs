using Cowrk_Space_Mangment_System.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cowrk_Space_Mangment_System.Repository
{
    public class ReceptionistRepository : IReceptionistRepository
    {
        Context context;
        public ReceptionistRepository(Context context)
        {
            this.context = context;
        }
        public List<Receptionist> GetAll()
        {
            return context.Receptionist.ToList();
        }

        public Receptionist GetById(int id)
        {
            return context.Receptionist.FirstOrDefault(r => r.Id == id);
        }

        public int Insert(Receptionist Receptionist)
        {
            context.Receptionist.Add(Receptionist);
            return context.SaveChanges();
        }

        public int Update(int id, Receptionist Receptionist)
        {

            Receptionist Old_Receptionist = GetById(id);
            if (Old_Receptionist != null)
            {
                Old_Receptionist.Id = Receptionist.Id;
                Old_Receptionist.Name = Receptionist.Name;
                Old_Receptionist.Username = Receptionist.Username;
                Old_Receptionist.Password = Receptionist.Password;
                Old_Receptionist.Email = Receptionist.Email;
                Old_Receptionist.Phone = Receptionist.Phone;
                Old_Receptionist.SalaryPerHour = Receptionist.SalaryPerHour;
                Old_Receptionist.TotalHours = Receptionist.TotalHours;
                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            Receptionist receptionist = GetById(id);
            context.Receptionist.Remove(receptionist);
            return context.SaveChanges();
        }
    }
}
