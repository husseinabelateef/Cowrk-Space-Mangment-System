using Cowrk_Space_Mangment_System.Models;
using System;

namespace Cowrk_Space_Mangment_System.Repository
{
    public interface IClientRepository: Irepository<Client,int>
    {
        public Client getByQrco(string Qr);
    }
}
