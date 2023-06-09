using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace back_side_Model.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AdvertisementID { get; set; }
        public int Quota { get; set; }
        public int PricePerPerson { get; set; }
    }
}
