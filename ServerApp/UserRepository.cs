using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ServerApp
{
    public class UserRepository : IUserRepository
    {
        public bool CheckUser(string login, string password)
        {
            var statusCheck = false;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var sqlRequest = String.Format(@"select login, password from users where login = '{0}' and password = '{1}'", 
                    login, password);

                using (var cmd = new SqlCommand(sqlRequest, conn))
                {
                    conn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        //todo: шото бесполезная штука
                        while (dr.Read())
                        {
                            statusCheck = true;
                        }
                        return statusCheck;
                    }
                }
            }
        }

        public DataTable GetAllUsers()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var sqlRequest = @"SELECT * FROM users";

                using (var cmd = new SqlCommand(sqlRequest, connection))
                {
                    var dataTable = new DataTable();
                    connection.Open();
                    dataTable.Load(cmd.ExecuteReader());
                    return dataTable;
                }
            }
        }

        public User GetUser(int idUser)
        {
            using (SqlConnection connectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command =
                    string.Format(@"select * from users where userid = '{0}'", idUser);
                var user = new User();
                using (var cmd = new SqlCommand(command, connectionString))
                {
                    connectionString.Open();
                    var sqlDataReader = cmd.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        user = new User
                        {
                            UserID = sqlDataReader.GetFieldValue<int>(sqlDataReader.GetOrdinal("UserId")),
                            UserLogin = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("Login")),
                            UserName = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("UserName")),
                            UserPassword = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("Password")),
                            UserSurname = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("UserSurname"))
                        };
                    }
                }
                return user;
            }
        }

        public User GetUser(string login)
        {
            using (SqlConnection connectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command =
                    string.Format(@"select * from users where login = '{0}'", login);
                var user = new User();
                using (var cmd = new SqlCommand(command, connectionString))
                {
                    connectionString.Open();
                    var sqlDataReader = cmd.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        user = new User
                        {
                            UserID = sqlDataReader.GetFieldValue<int>(sqlDataReader.GetOrdinal("UserId")),
                            UserLogin = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("Login")),
                            UserName = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("UserName")),
                            UserPassword = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("Password")),
                            UserSurname = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("UserSurname"))
                        };
                    }
                }
                return user;
            }
        }

        public string GetUserName(string login)
        {
            var userName = String.Empty;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var sqlRequest = String.Format(@"SELECT username FROM users where login = {0}", login);
                using (var cmd = new SqlCommand(sqlRequest, connection))
                {
                    connection.Open();
                    var sqlDataReader = cmd.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        userName = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("username"));
                    }
                }
            }
            return userName;
        }

        public bool AddUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var success = false;
                string addUser =
                    string.Format(@"INSERT INTO users(username, usersurname, login, password) VALUES('{0}','{1}','{2}', {3})",
                    user.UserName, user.UserSurname, user.UserLogin, user.UserPassword);

                using (SqlCommand cmd = new SqlCommand(addUser, conn))
                {
                    conn.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    success = true;
                }

                return success;
            }

        }

        public void Update(User user)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {

                //todo: продумать изменения данных о пользователе, если это не только изменение пароля
                //наполнения функционала отсутствует, запрос неверный


                var updateUser =
                    string.Format(@"UPDATE Managers SET Password = '{0}', FIO = '{1}', IsAdmin = {2} WHERE Login = '{3}'");

                using (SqlCommand cmd = new SqlCommand(updateUser, conn))
                {
                    conn.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                }
            }

        }

        public void Delete(string login)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var deleteUser =
                    string.Format(@"DELETE FROM Manager WHERE Login = '{0}'", login);
                using (SqlCommand cmd = new SqlCommand(deleteUser, connection))
                {
                    connection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                }
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
