using ServerApp.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Helper
{
    public class DeviceHelper
    {
        private IDeviceRepository _deviceRepository;

        public DeviceHelper()
        {
            _deviceRepository = new DeviceRepository();
        }

        public List<Device.Device> Retrieve(int idRoomName)
        {
            return _deviceRepository.Retrieve(idRoomName);
        }
        
        public Device.Device RetrieveInfo(int deviceId)
        {
            return _deviceRepository.RetrieveInfo(deviceId);
        }
    }
}
