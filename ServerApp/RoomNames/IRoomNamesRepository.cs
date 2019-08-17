using System.Collections.Generic;

namespace ServerApp.RoomNames
{
    interface IRoomNamesRepository
    {
        /// <summary>
        /// Получить список комнат пользователя
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <returns>Список названий комнат</returns>
        List<RoomNames> Retrieve(string login);

        /// <summary>
        /// Получить список всех комнат
        /// </summary>
        /// <returns>Список названий комнат</returns>
        List<RoomNames> Retrieve();
    }
}
