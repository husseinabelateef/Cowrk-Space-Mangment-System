﻿using Cowrk_Space_Mangment_System.Models;

namespace Cowrk_Space_Mangment_System.Repository
{
    public interface IRoomRepository :Irepository<Room,int>
    {
        public Room GetByName(string Name);
    }
}
