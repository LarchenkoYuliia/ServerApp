using System;

namespace ServerApp.Device
{
    /// <summary>
    /// Устройство
    /// </summary>
    public class Device
    {
        /// <summary>
        /// Уникальный номер усройства
        /// </summary>
        public int DeviceId { get; set; }

        /// <summary>
        /// Название устройства
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// Дата истечения гарантии устройства
        /// </summary>
        public DateTime WarrantyExpirationDate { get; set; }

        /// <summary>
        /// Модель устройства
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Тип устройства
        /// </summary>
        public string DeviceTypeId { get; set; }
    }
}
