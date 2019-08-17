using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ServerApp.RoomNames
{
    public class RoomNamesRepository : IRoomNamesRepository
    {
        /// <summary>
        /// Получить список комнат пользователя
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <returns>Список названий комнат</returns>
        public List<RoomNames> Retrieve(string login)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var sqlRequest =
                    string.Format(@"select * from rooms join users on users.id = rooms.userid join roomnames on rooms.id = roomnames.id WHERE login = '{0}'", login);
                using (var cmd = new SqlCommand(sqlRequest, connection))
                {
                    connection.Open();
                    var sqlDataReader = cmd.ExecuteReader();
                    var roomNames = new List<RoomNames>();
                    while (sqlDataReader.Read())
                    {
                        var roomName = new RoomNames
                        {
                            RoomNameId = sqlDataReader.GetFieldValue<int>(sqlDataReader.GetOrdinal("ID")),
                            RoomName = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("ROOMNAME"))
                        };
                    }

                    return roomNames;
                }
            }
        }

        public List<RoomNames> Retrieve()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var sqlRequest =
                    string.Format(@"select * from roomnames");
                using (var cmd = new SqlCommand(sqlRequest, connection))
                {
                    connection.Open();
                    var sqlDataReader = cmd.ExecuteReader();
                    var roomNameList = new List<RoomNames>();
                    while (sqlDataReader.Read())
                    {
                        var roomName = new RoomNames
                        {
                            RoomNameId = sqlDataReader.GetFieldValue<int>(sqlDataReader.GetOrdinal("id")),
                            RoomName = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("roomname"))
                        };
                        roomNameList.Add(roomName);
                    }

                    return roomNameList;
                }
            }
        }
    }
}
