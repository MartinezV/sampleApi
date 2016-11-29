using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdsApi.Api.Classes
{
    public class FlashInfoClass
    {
        public string SERIAL_NUMBER { get; set; }
        public string CUSTOMER_NUMBER { get; set; }
        public DateTime FLASH_DATE { get; set; }
        public string VEHICLE_MAKE { get; set; }
        public string VEHICLE_MODEL { get; set; }
        public string VEHICLE_YEAR { get; set; }
        public string USER_FLASH_UNIT { get; set; }
        public IList<UpgradesInfoClass> UPGRADE { get; set; }
    }
}