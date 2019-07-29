namespace ServerApp
{
    /// <summary>
    /// Гостинная
    /// </summary>
    public class Lounge
    {
        /// <summary>
        /// Уникальный номер в базе данных
        /// </summary>
        public int LoungeId { get; set; }

        /// <summary>
        /// Уникальный номер устройства
        /// </summary>
        public int DeviceId { get; set; }
    }
}
