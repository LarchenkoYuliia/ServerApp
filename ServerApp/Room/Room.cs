namespace ServerApp.Room
{
    /// <summary>
    /// Комната
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Уникальный номер в базе данных
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// Номер пользователя
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Уникальный идентификатор наименования комнаты
        /// </summary>
        public int RoomNameId { get; set; }

        /// <summary>
        /// Уникальный идентификатор устройства
        /// </summary>
        public int DeviceId { get; set; }
    }
}
