using Cowrk_Space_Mangment_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cowrk_Space_Mangment_System.Repository
{
    public class ClientRepository : IClientRepository
    {
        Context context;
        public ClientRepository(Context _context)
        {
            context = _context;
        }
        public List<Client> GetAll()
        {
            return context.Client.ToList();
        }

        public Client GetById(int id)
        {
            return context.Client.FirstOrDefault(client =>client.ID  == id);
        }

        public int Insert(Client client)
        {
            context.Client.Add(client);
            context.SaveChanges();
            client.QR_Code = "NOOK" + client.ID.ToString();
            return context.SaveChanges();
        }

        public int Update(int id, Client client)
        {
            Client oldClient = GetById(id);
            if (oldClient != null)
            {
                oldClient.Name = client.Name;
                oldClient.Profession= client.Profession;
                oldClient.Faculty= client.Faculty;
                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            Client oldClient = GetById(id);
            context.Client.Remove(oldClient);
            return context.SaveChanges();
        }

        public Client getByQrco(string Qr)
        {
            return context.Client.FirstOrDefault(x => x.QR_Code == Qr);
        }
    }
}
