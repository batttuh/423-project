

using back_side_Model.Models;

namespace back_side_Model.DTO
{
	 public class UserDTO
    {
    
        public int UserID { get; set; }

        

        public string Name { get; set; }

        public string e_mail { get; set; }
        //public int photo { get; set; }

        public string? NameSurname { get; set; }
        public string? TiktokAccount { get; set; }
        public string? InstagramAccount { get; set; }
        public int TiktokFollowerCount { get; set; }
        public int InstagramFollowerCount { get; set; }
        public UserDTO(int userID, string name, string e_mail, string? nameSurname, string? tiktokAccount, string? ınstagramAccount, int tiktokFollowerCount, int ınstagramFollowerCount)
        {
            UserID = userID;
            Name = name;
            this.e_mail = e_mail;
            NameSurname = nameSurname;
            TiktokAccount = tiktokAccount;
            InstagramAccount = ınstagramAccount;
            TiktokFollowerCount = tiktokFollowerCount;
            InstagramFollowerCount = ınstagramFollowerCount;
        }

    }
     public class UserTypeWithDTO
    {
    
        public int UserID { get; set; }

        

        public string Name { get; set; }

        public string e_mail { get; set; }
        //public int photo { get; set; }

        public string? NameSurname { get; set; }
        public string? TiktokAccount { get; set; }
        public string? InstagramAccount { get; set; }
        public int TiktokFollowerCount { get; set; }
        public int InstagramFollowerCount { get; set; }
        public UserType UserType { get; set; }
        public UserTypeWithDTO(int userID,
                               string name,
                               string e_mail,
                               string? nameSurname,
                               string? tiktokAccount,
                               string? ınstagramAccount,
                               int tiktokFollowerCount,
                               int ınstagramFollowerCount,
                                UserType userType
                               )
        {
            UserID = userID;
            Name = name;
            this.e_mail = e_mail;
            NameSurname = nameSurname;
            TiktokAccount = tiktokAccount;
            InstagramAccount = ınstagramAccount;
            TiktokFollowerCount = tiktokFollowerCount;
            InstagramFollowerCount = ınstagramFollowerCount;
            UserType=userType;
        }

    }
}