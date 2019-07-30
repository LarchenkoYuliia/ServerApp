using System;
using System.Collections.Generic;
using System.Data;

namespace ServerApp
{
    interface IUserRepository : IDisposable
    {
        /// <summary>
        /// Получить данные о пользователе по идентификатору
        /// </summary>
        /// <param name="idUser">Идентификатор</param>
        /// <returns>Данные о пользователе</returns>
        User GetUser(int idUser);

        /// <summary>
        /// Получить данные о пользователе по логину
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns>Данные о пользователе</returns>
        User GetUser(string login);

        /// <summary>
        /// Получить имя пользователя
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns>Имя пользователя</returns>
        string GetUserName(string login);

        /// <summary>
        /// Проверить зарегестрирован ли пользователь
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        bool CheckUser(string login, string password);

        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        DataTable GetAllUsers();

        /// <summary>
        /// Добавить пользователя (для регистрации)
        /// </summary>
        /// <param name="user"></param>
        bool AddUser(User user);

        /// <summary>
        /// Изменить данные пользователя
        /// </summary>
        /// <param name="login"></param>
        bool UpdatePassword(string login);

        /// <summary>
        /// Удалить аккаунт
        /// </summary>
        /// <param name="login"></param>
        void Delete(string login);
    }
}
