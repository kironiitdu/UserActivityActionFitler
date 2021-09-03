using System;
using System.ComponentModel.DataAnnotations;

namespace UserActivityLog.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
    public class UserLog
    {
        [Key]
        public long ulogo_id { get; set; }
        public long user_id { get; set; }
        public string user_name { get; set; }
        public DateTime login_date { get; set; }
        public string login_time { get; set; }
        public string ip_address { get; set; }
        public string page_name { get; set; }
        public string controller { get; set; }
        public string http_verb { get; set; }
    }

}
