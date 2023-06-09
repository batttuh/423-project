using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace back_side_Model.Models
{
    public class User
    {
        public int UserID { get; set; }
        public int UserType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PostID { get; set; }
        public string e_mail { get; set; }
        //public int photo { get; set; }
        public string NameSurname { get; set; }
        public string TiktokAccount { get; set; }
        public string InstagramAccount { get; set; }
        public int TiktokFollowerCount { get; set; }
        public int InstagramFollowerCount { get; set; }
    }
}
