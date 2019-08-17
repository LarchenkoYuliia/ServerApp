using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ServerApp
{
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Проверить зарегестрирован ли пользователь
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        public bool CheckUser(string login, string password)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var sqlRequest = String.Format(@"select top 1 ID from USERS where LOGIN = '{0}' and PASSWORD = '{1}'", 
                    login, password);

                using (var cmd = new SqlCommand(sqlRequest, connection))
                {
                    connection.Open();
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        if(dataReader.HasRows)
                        {
                            return true;
                        }

                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        public DataTable Retrieve()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var sqlRequest = @"SELECT * FROM USERS";

                using (var cmd = new SqlCommand(sqlRequest, connection))
                {
                    var dataTable = new DataTable();
                    connection.Open();
                    dataTable.Load(cmd.ExecuteReader());
                    return dataTable;
                }
            }
        }

        /// <summary>
        /// Получить данные о пользователе по идентификатору
        /// </summary>
        /// <param name="idUser">Идентификатор</param>
        /// <returns>Данные о пользователе</returns>
        public User Retrieve(int idUser)
        {
            using (SqlConnection connectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command =
                    string.Format(@"select * from USERS where ID = '{0}'", idUser);
                var user = new User();
                using (var cmd = new SqlCommand(command, connectionString))
                {
                    connectionString.Open();
                    var sqlDataReader = cmd.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        user = new User
                        {
                            UserID = sqlDataReader.GetFieldValue<int>(sqlDataReader.GetOrdinal("ID")),
                            UserLogin = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("LOGIN")),
                            UserName = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("NAME")),
                            UserPassword = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("PASSWORD")),
                            UserSurname = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("SURNAME"))
                        };
                    }
                }
                return user;
            }
        }

        /// <summary>
        /// Получить данные о пользователе по логину
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns>Данные о пользователе</returns>
        public User Retrieve(string login)
        {
            using (SqlConnection connectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command =
                    string.Format(@"select * from USERS where LOGIN = '{0}'", login);
                var user = new User();
                using (var cmd = new SqlCommand(command, connectionString))
                {
                    connectionString.Open();
                    var sqlDataReader = cmd.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        user = new User
                        {
                            UserID = sqlDataReader.GetFieldValue<int>(sqlDataReader.GetOrdinal("ID")),
                            UserLogin = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("LOGIN")),
                            UserName = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("NAME")),
                            UserPassword = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("PASSWORD")),
                            UserSurname = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("SURNAME"))
                        };
                    }
                }
                return user;
            }
        }

        /// <summary>
        /// Получить имя пользователя
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns>Имя пользователя</returns>
        public string RetrieveName(string login)
        {
            var userName = String.Empty;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var sqlRequest = String.Format(@"SELECT NAME FROM USERS where LOGIN = '{0}'", login);
                using (var cmd = new SqlCommand(sqlRequest, connection))
                {
                    connection.Open();
                    var sqlDataReader = cmd.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        userName = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("NAME"));
                    }
                }
            }
            return userName;
        }

        /// <summary>
        /// Добавить пользователя (для регистрации)
        /// </summary>
        /// <param name="user"></param>
        public bool Create(User user)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var success = false;
                var addUser =
                    string.Format(@"INSERT INTO USERS(ID, NAME, SURNAME, LOGIN, PASSWORD) VALUES(3,'{0}','{1}','{2}', '{3}')",
                    user.UserName, user.UserSurname, user.UserLogin, user.UserPassword);

                using (var cmd = new SqlCommand(addUser, conn))
                {
                    conn.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    success = true;
                }

                return success;
            }
        }

        /// <summary>
        /// Изменить данные пользователя
        /// </summary>
        /// <param name="login"></param>
        public bool UpdatePassword(string login)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {

                //todo: продумать изменения данных о пользователе, если это не только изменение пароля
                //проверить выполнение метода, не уверенна на счет HasRows


                var updateUser =
                    string.Format(@"UPDATE USERS SET PASSWORD = '{0}' where LOGIN = '{0}'", login);

                using (var cmd = new SqlCommand(updateUser, connection))
                {
                    connection.Open();
                    var sqlDataReader = cmd.ExecuteReader();
                    if(sqlDataReader.HasRows)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Удалить аккаунт
        /// </summary>
        /// <param name="login"></param>
        public void Delete(string login)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var deleteUser =
                    string.Format(@"DELETE FROM USERS WHERE LOGIN = '{0}'", login);
                using (var cmd = new SqlCommand(deleteUser, connection))
                {
                    connection.Open();
                    var sqlDataReader = cmd.ExecuteReader();
                }
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
