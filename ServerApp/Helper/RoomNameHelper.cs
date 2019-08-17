using ServerApp.RoomNames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Helper
{
    public class RoomNameHelper
    {
        private IRoomNamesRepository _roomNamesRepository;

        public RoomNameHelper()
        {
            _roomNamesRepository = new RoomNamesRepository();
        }

        public List<RoomNames.RoomNames> Retrieve(string login)
        {
            return _roomNamesRepository.Retrieve(login);
        }

        public List<RoomNames.RoomNames> Retrieve()
        {
            return _roomNamesRepository.Retrieve();
        }
    }
}
