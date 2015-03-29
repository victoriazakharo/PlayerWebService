using System;
using System.ComponentModel.DataAnnotations;

namespace PlayerWebService 
{

    [Serializable]
    public class PlayerViewModel
    {
        public string PlayerId { get; set; }

        public int Jersey { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Position { get; set; }

        [Display(Name = "Birth Day")]
        [DisplayFormat(DataFormatString = "{0:dd.M.yyyy}")]
        public DateTime Birthday { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        [Display(Name = "Birth City")]
        public string Birthcity { get; set; }

        [Display(Name = "Birth State")]
        public string Birthstate { get; set; }

    }
}