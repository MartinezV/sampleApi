using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdsApi.Api.Classes
{
    public class ProductInfoClass
    {
        
        public string SERIAL_NUM { get; set; }
        public string SKU { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public decimal? CUSTOMER_NUM { get; set; }
        public string ADDRESS_1 { get; set; }
        public string ADDRESS_2 { get; set; }
        public string ADDRESS_3 { get; set; }
        public string CITY { get; set; }
        public string STATE_PROV { get; set; }
        public string POSTAL_CODE { get; set; }
        public string COUNTRY { get; set; }
        public DateTime? SHIP_DATE { get; set; }
        public decimal? ORDER_NUM { get; set; }
        public string ACK_CODE { get; set; }
        public string ACK_MESSAGE { get; set; }
        public string ACK_DATE { get; set; }
        public string CONTACT_NAME { get; set; }
        public string CONTACT_EMAIL { get; set; }
        public decimal? LOCATION_ID { get; set; }
    }
}