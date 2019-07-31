using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ServerApp.Room
{
    public class RoomRepository : IRoomRepository
    {
        /// <summary>
        /// Получить перечень комнат пользователя
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <returns>Список комнат</returns>
        public List<Room> GetUserRooms(string login)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var sqlRequest =
                    string.Format(@"select * from rooms join users on rooms.userid = users.userid where users.login = '{0}'", login);
                using (var cmd = new SqlCommand(sqlRequest, connection))
                {
                    connection.Open();
                    var sqlDataReader = cmd.ExecuteReader();
                    var roomsList = new List<Room>();
                    while (sqlDataReader.Read())
                    {
                        var room = new Room
                        {
                            RoomId = sqlDataReader.GetFieldValue<int>(sqlDataReader.GetOrdinal("roomid")),
                            UserId = sqlDataReader.GetFieldValue<int>(sqlDataReader.GetOrdinal("userid")),
                            DeviceId = sqlDataReader.GetFieldValue<int>(sqlDataReader.GetOrdinal("deviceid")),
                            RoomNameId = sqlDataReader.GetFieldValue<int>(sqlDataReader.GetOrdinal("roomnameid")),
                        };
                        roomsList.Add(room);
                    }

                    return roomsList;
                }
            }
        }
    }
}
