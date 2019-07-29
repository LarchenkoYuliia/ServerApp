namespace ServerApp
{
    public class User
    {
        /// <summary>
        /// Уникальный номер пользователя
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string UserSurname { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string UserLogin { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string UserPassword { get; set; }
    }
}
