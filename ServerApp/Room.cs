namespace ServerApp
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
        /// Уникальный номер ванной
        /// </summary>
        public int BadRoomId { get; set; }

        /// <summary>
        /// Уникальный номер коридора
        /// </summary>
        public int HallId { get; set; }

        /// <summary>
        /// Уникальный номер кухни
        /// </summary>
        public int KitchenId { get; set; }

        /// <summary>
        /// Уникальный номер гостинной
        /// </summary>
        public int LoungeId { get; set; }

        /// <summary>
        /// Уникальный номер ванной
        /// </summary>
        public int BathroomId { get; set; }
    }
}
