using System.Collections.Generic;

namespace ServerApp.Device
{
    interface IDeviceRepository
    {
        /// <summary>
        /// Получить список устройств комнаты
        /// </summary>
        /// <param name="idRoomName">Идентификатор комнаты</param>
        /// <returns>Список устройств</returns>
        List<Device> Retrieve(int idRoomName);

        /// <summary>
        /// Получить информацию по устройству
        /// </summary>
        /// <param name="deviceId">Идентификатор устройства</param>
        /// <returns>Устройство</returns>
        Device RetrieveInfo(int deviceId);
    }
}
