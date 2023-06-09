using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace back_side_Model.Models
{
    public class Application
    {
        public int ApplicationID { get; set; }
        public int UserID { get; set; }
        public int PostID { get; set; }
        public string ShareURL { get; set; }
    }
}
