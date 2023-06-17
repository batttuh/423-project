using back_side_Model.Models;

namespace back_side_Model.DTO{
      public class PostDTODashboard
    {
 
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
 
        public int Quota { get; set; }
        public double PricePerPerson { get; set; }

        public Advertisement? Advertisement { get; set; }
    }
    public class GetAllPostDTO
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Quota { get; set; }
        public double PricePerPerson { get; set; }
        public Advertisement? Advertisement { get; set; }
        public UserTypeWithDTO? User { get; set; }
    }


    
}