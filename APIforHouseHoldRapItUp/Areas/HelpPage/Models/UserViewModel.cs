using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIforHouseHoldRapItUP.Areas.HelpPage.Models
{
    public class UserViewModel
    {
        public ObjectId _id;
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string state { get; set; }
        public string city { get; set; }

    }
}