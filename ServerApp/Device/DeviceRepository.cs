using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ServerApp.Device
{
    public class DeviceRepository : IDeviceRepository
    {
        /// <summary>
        /// Получить информацию по устройству
        /// </summary>
        /// <param name="deviceId">Идентификатор устройства</param>
        /// <returns>Устройство</returns>
        public Device RetrieveInfo(int deviceId)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var sqlRequest =
                    string.Format(@"select * from devices WHERE devices.id = '{0}'", deviceId);
                using (var cmd = new SqlCommand(sqlRequest, connection))
                {
                    connection.Open();
                    var sqlDataReader = cmd.ExecuteReader();
                    var device = new Device();
                    while (sqlDataReader.Read())
                    {
                        device.DeviceId = sqlDataReader.GetFieldValue<int>(sqlDataReader.GetOrdinal("ID"));
                        device.DeviceName = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("Name"));
                        device.WarrantyExpirationDate = sqlDataReader.GetFieldValue<DateTime>(sqlDataReader.GetOrdinal("WARRANTYDATE"));
                        device.Model = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("Model"));
                    }

                    return device;
                }
            }
        }

        // <summary>
        /// Получить список устройств комнаты
        /// </summary>
        /// <param name="idRoomName">Идентификатор комнаты</param>
        /// <returns>Список устройств</returns>
        public List<Device> Retrieve(int idRoomName)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var sqlRequest =
                    string.Format(@"select * from devices join rooms on devices.id = rooms.deviceid join roomnames on rooms.roomnameid = roomnames.id WHERE roomnames.id = {0}", idRoomName);
                using (var cmd = new SqlCommand(sqlRequest, connection))
                {
                    connection.Open();
                    var sqlDataReader = cmd.ExecuteReader();
                    var deviceList = new List<Device>();
                    while (sqlDataReader.Read())
                    {
                        var device = new Device
                        {
                            DeviceId = sqlDataReader.GetFieldValue<int>(sqlDataReader.GetOrdinal("ID")),
                            DeviceName = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("Name")),
                            WarrantyExpirationDate = sqlDataReader.GetFieldValue<DateTime>(sqlDataReader.GetOrdinal("WARRANTYDATE")),
                            Model = sqlDataReader.GetFieldValue<string>(sqlDataReader.GetOrdinal("Model"))
                        };
                        deviceList.Add(device);
                    }

                    return deviceList;
                }
            }
        }
    }
}
