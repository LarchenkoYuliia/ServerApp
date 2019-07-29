namespace ServerApp
{   /// <summary>
    /// Ванная комната
    /// </summary>
    public class Bathroom
    {
        /// <summary>
        /// Уникальный номер в базе данных
        /// </summary>
        public int BathroomId { get; set; }

        /// <summary>
        /// Уникальный номер устройства
        /// </summary>
        public int DeviceId { get; set; }
    }
}
