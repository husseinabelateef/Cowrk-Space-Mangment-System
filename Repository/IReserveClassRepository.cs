using System.Collections.Generic;
using Cowrk_Space_Mangment_System.Models;

namespace Cowrk_Space_Mangment_System.Repository
{
    public interface IReserveClassRepository : Irepository<RoomReserve , int>
    {
        public List<Room> AvailableRoom();
    }
}
