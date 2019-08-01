using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.RoomNames
{
    public class RoomNames
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int RoomNameId { get; set; }

        /// <summary>
        /// Название комнаты
        /// </summary>
        public string RoomName { get; set; }
    }
}
