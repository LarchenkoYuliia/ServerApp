using System;
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
        User Retrieve(int idUser);

        /// <summary>
        /// Получить данные о пользователе по логину
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns>Данные о пользователе</returns>
        User Retrieve(string login);

        /// <summary>
        /// Получить имя пользователя
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns>Имя пользователя</returns>
        string RetrieveName(string login);

        /// <summary>
        /// Проверить зарегестрирован ли пользователь
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        bool CheckUser(string login, string password);

        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        DataTable Retrieve();

        /// <summary>
        /// Добавить пользователя (для регистрации)
        /// </summary>
        /// <param name="user"></param>
        bool Create(User user);

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
