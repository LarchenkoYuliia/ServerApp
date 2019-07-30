using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace ServerApp
{
    public class RoomNamesRepository : IRoomNamesRepository
    {
        public List<RoomNames> GetRooms(string login)
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
    }
}
