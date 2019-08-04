using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

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
            //todo: базу переделать так, чтобы добавить таблицу-справочник с названиями комнат 
            //и возвращать именно список названий комнат

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var sqlRequest =
                    string.Format(@"select roomNmame from rooms join users on users.userid = rooms.userid join roomnames on rooms.roomnamesid = roomnames.roomnamesid WHERE login = '{0}'", login);
                using (var cmd = new SqlCommand(sqlRequest, connection))
                {
                    connection.Open();
                    var sqlDataReader = cmd.ExecuteReader();
                    var rooms = new List<RoomNames>();
                    while (sqlDataReader.Read())
                    {
                        //var room = new Room
                        //{

                        //}
                    }

                    return rooms;
                }
            }
        }

        public List<RoomNames> Retrieve()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var sqlRequest =
                    string.Format(@"select roomname from roomnames");
                using (var cmd = new SqlCommand(sqlRequest, connection))
                {
                    connection.Open();
                    var sqlDataReader = cmd.ExecuteReader();
                    var roomNameList = new List<RoomNames>();
                    while (sqlDataReader.Read())
                    {
                        var roomName = new RoomNames
                        {
                            RoomNameId = sqlDataReader.GetFieldValue<int>(sqlDataReader.GetOrdinal("roomnameid")),
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
