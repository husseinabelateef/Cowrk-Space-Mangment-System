using Cowrk_Space_Mangment_System.Models;
using System.Collections.Generic;
using System.Linq;
namespace Cowrk_Space_Mangment_System.Repository
{
    public class PackageRepository : IPackageRepository
    {
        Context context;
        public PackageRepository(Context _context)
        {
            context = _context;
        }

        public List<Package> GetAll()
        {
            return context.Package.ToList();
        }

        public Package GetById(int id)
        {
            return context.Package.FirstOrDefault(Package => Package.ID == id);
        }

        public int Insert(Package package)
        {
            context.Package.Add(package);
            return context.SaveChanges();
        }

        public int Update(int id, Package package)
        {
            Package oldpackage = GetById(id);
            if (oldpackage != null)
            {
               
                oldpackage.Price= package.Price;
                oldpackage.Offer = package.Offer;
                oldpackage.NumberOfHours = package.NumberOfHours;
                oldpackage.NumberOfDays = package.NumberOfDays;
                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            Package oldpackage = GetById(id);
            context.Package.Remove( oldpackage);
            return context.SaveChanges();
        }
    }
}