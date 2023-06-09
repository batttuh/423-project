using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace back_side_Model.Models
{
    public class Advertisement
    {
        public int AdvertisementID { get; set; }
        public int FollowerUpperLimit { get; set; }
        public int FollowerBottomLimit { get; set; }
        public int ViewsBottomLimit { get; set; }
    }
}
