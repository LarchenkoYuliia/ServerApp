namespace ServerApp
{
    /// <summary>
    /// Коридор
    /// </summary>
    public class Hall
    {
        /// <summary>
        /// Уникальный номер в базе данных
        /// </summary>
        public int HallId { get; set; }

        /// <summary>
        /// Уникальный номер устройства
        /// </summary>
        public int DeviceId { get; set; }
    }
}
