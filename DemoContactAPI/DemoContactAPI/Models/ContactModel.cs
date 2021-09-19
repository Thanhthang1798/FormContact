using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoContactAPI.Models
{
    public class ContactModel
    {
        public long id { get; set; }
        public string name { get; set; }
        public string message { get; set; }
        public string phone { get; set; }
        public string ip { get; set; }
        public string createddate { get; set; }
    }
}
