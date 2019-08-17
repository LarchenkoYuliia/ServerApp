using ServerApp.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Helper
{
    public class RoomHelper
    {
        private IRoomRepository _roomRepository;

        public RoomHelper()
        {
            _roomRepository = new RoomRepository();
        }

        public List<Room.Room> Retrieve(string login)
        {
            return _roomRepository.Retrieve(login);
        }
    }
}
