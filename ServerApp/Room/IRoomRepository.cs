using System.Collections.Generic;

namespace ServerApp.Room
{
    interface IRoomRepository
    {
        /// <summary>
        /// Получить перечень комнат пользователя
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <returns>Список комнат</returns>
        List<Room> GetUserRooms(string login);
    }
}
