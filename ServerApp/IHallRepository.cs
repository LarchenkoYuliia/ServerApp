using System;
using System.Collections.Generic;

namespace ServerApp
{
    interface IHallRepository : IDisposable
    {
        /// <summary>
        /// Получить список устройств коридора
        /// </summary>
        /// <param name="hallId">Идентификатор</param>
        /// <returns>Список устройств</returns>
        List<Device> GetDevices(int hallId);
    }
}
