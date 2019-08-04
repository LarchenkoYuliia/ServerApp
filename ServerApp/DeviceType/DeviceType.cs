using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.DeviceType
{
    public class DeviceType
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int DeviceTypeId { get; set; }

        /// <summary>
        /// Наименовение типа устройства
        /// </summary>
        public string DeviceTypeName { get; set; }
    }
}
