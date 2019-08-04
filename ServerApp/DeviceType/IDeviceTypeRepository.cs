using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.DeviceType
{
    interface IDeviceTypeRepository
    {
        /// <summary>
        /// Получить список типов устройств
        /// </summary>
        /// <returns></returns>
        List<DeviceType> Retrieve();
    }
}
