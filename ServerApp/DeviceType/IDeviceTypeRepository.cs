using System.Collections.Generic;

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
