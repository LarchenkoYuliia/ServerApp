using ServerApp.DeviceType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Helper
{
    public class DeviceTypeHelper
    {
        private IDeviceTypeRepository _deviceTypeRepository;

        public DeviceTypeHelper()
        {
            _deviceTypeRepository = new DeviceTypeRepository();
        }

        public List<DeviceType.DeviceType> Retrieve()
        {
            return _deviceTypeRepository.Retrieve();
        }
    }
}
