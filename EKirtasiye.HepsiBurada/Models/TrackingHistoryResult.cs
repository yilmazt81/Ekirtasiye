using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.HepsiBurada
{
    public class TrackingHistoryResult
    {
        public bool success { get; set; }
        public int code { get; set; }
        public int version { get; set; }
        public object message { get; set; }
        public TrackingHistory[] data { get; set; }
    }



    public class TrackingHistory
    {
        public DateTime createdDate { get; set; }
        public string trackingId { get; set; }
    }

}
