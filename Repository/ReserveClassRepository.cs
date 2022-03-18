using System.Collections.Generic;
using System.Linq;
using Cowrk_Space_Mangment_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Cowrk_Space_Mangment_System.Repository
{
    public class ReserveClassRepository : IReserveClassRepository
    {
        readonly private Context context;
        public ReserveClassRepository(Context context)
        {
            this.context = context;
        }

        public List<Room> AvailableRoom()
        {
            return context.RoomReserve.Where(d => d.End_Time < System.DateTime.Now).Include(D => D.Room).Select(d => d.Room).ToList();
        }

        public int Delete(int id)
        {
            context.RoomReserve.Remove(GetById(id));
            return context.SaveChanges();
        }

        public List<RoomReserve> GetAll()
        {
            return context.RoomReserve.ToList();
        }

        public RoomReserve GetById(int id)
        {
            return context.RoomReserve.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(RoomReserve item)
        {
            context.RoomReserve.Add(item);
            return context.SaveChanges();
        }

        public int Update(int id, RoomReserve item)
        {
           RoomReserve roomReserve = GetById(id);
            if(roomReserve != null)
            {
                roomReserve.Rooom_Id = item.Rooom_Id;
                roomReserve.Reservation_Id = item.Reservation_Id;
                roomReserve.End_Time = item.End_Time;
                context.RoomReserve.Update(roomReserve);
            }
            return context.SaveChanges();
        }
    }
}
