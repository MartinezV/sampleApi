using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdsApi.Api.Classes
{
    public class ErrorInfoClass
    {
        public string REQUEST { get; set; }
        public string TYPE { get; set; }
        public string MESSAGE { get; set; }
        public DateTime TIME_DATE { get; set; }
    }
}