﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ServerApp.DeviceType
{
    public class DeviceTypeRepository : IDeviceTypeRepository
    {
        public List<DeviceType> Retrieve()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var sqlRequest = String.Format(@"select ID, TYPENAME from DEVICETYPES");
                var deviceTypeList = new List<DeviceType>();
                using (var cmd = new SqlCommand(sqlRequest, connection))
                {
                    connection.Open();
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        var deviceType = new DeviceType
                        {
                            DeviceTypeId = dataReader.GetFieldValue<int>(dataReader.GetOrdinal("ID")),
                            DeviceTypeName = dataReader.GetFieldValue<string>(dataReader.GetOrdinal("TYPENAME"))
                        };
                        deviceTypeList.Add(deviceType);
                    }
                }
                return deviceTypeList;
            }
        }
    }
}
