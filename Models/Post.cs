﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace back_side_Model.Models
{
    public class Post
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PostID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [ForeignKey("Advertisement")]
        public int AdvertisementID { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }
        [Required]
        public int Quota { get; set; }
        [Required]
        public double PricePerPerson { get; set; }

        public Advertisement? Advertisement { get; set; }
        public User User { get; set; }
    }
      public class PostCreate{
            
         public string Title { get; set; }
     
        public string Description { get; set; }
        public int Quota { get; set; }
        public double PricePerPerson { get; set; }

        public AdvertisementCreate? AdvertisementCreate { get; set; }
    }

    public class PostUpdate
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Quota { get; set; }
        public double PricePerPerson { get; set; }
    }
}

