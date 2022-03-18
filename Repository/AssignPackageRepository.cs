using Cowrk_Space_Mangment_System.Models;
using System.Collections.Generic;
using System.Linq;
namespace Cowrk_Space_Mangment_System.Repository
{
    public class AssignPackageRepository:IAssignPackageRepository
    {
        Context context;
        public AssignPackageRepository(Context _context)
        {
            context = _context;
        }

        public List<AssignPackage> GetAll()
        {
            return context.AssignPackage.ToList();
        }

        public AssignPackage GetById(int id)
        {
            return context.AssignPackage.FirstOrDefault(AssignPackage => AssignPackage.ID == id);
        }

        public int Insert(AssignPackage assignPackage)
        {
            context.AssignPackage.Add(assignPackage);
            return context.SaveChanges();
        }

        public int Update(int id, AssignPackage assignPackage)
        {
            AssignPackage oldAssignPackage = GetById(id);
            if (oldAssignPackage != null)
            {

                oldAssignPackage.PackageID=assignPackage.PackageID;
                oldAssignPackage.ClientID=assignPackage.ClientID;
                oldAssignPackage.EndDate = assignPackage.EndDate;
                oldAssignPackage.StartDate= assignPackage.StartDate;
                oldAssignPackage.AvailableHours= assignPackage.AvailableHours;
                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            AssignPackage oldAssignPackage = GetById(id);
            context.AssignPackage.Remove(oldAssignPackage);
            return context.SaveChanges();
        }
    }
}
