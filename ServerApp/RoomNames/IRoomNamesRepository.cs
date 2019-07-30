using System.Collections.Generic;

namespace ServerApp
{
    interface IRoomNamesRepository
    {
        /// <summary>
        /// Получить список комнат пользователя
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        List<RoomNames> GetRooms(string login);
    }
}
