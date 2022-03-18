using Cowrk_Space_Mangment_System.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cowrk_Space_Mangment_System.Repository
{
    public class RoomRepository: IRoomRepository
    {
        Context context;
        public RoomRepository(Context _context)
        {
            context = _context;
        }
        public List<Room> GetAll()
        {
            return context.Room.ToList();
        }

        public Room GetById(int id)
        {
            return context.Room.FirstOrDefault(room => room.ID == id);
        }

        public int Insert(Room room)
        {
            context.Room.Add(room);
            return context.SaveChanges();
        }

        public int Update(int id, Room room)
        {
            Room oldRoom = GetById(id);
            if (oldRoom != null)
            {
                oldRoom.Name = room.Name;
                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            Room oldRoom = GetById(id);
            context.Room.Remove(oldRoom);
            return context.SaveChanges();
        }
    }
}
