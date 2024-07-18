using System.ComponentModel.DataAnnotations;

namespace Test2.Models
{
    public class EmployListVM
    {
        public string id { get; set; }
        [Display(Name ="First name")]
        public string firstname { get; set; }
        [Display(Name = "Last name")]

        public string lastname { get; set; }
        [Display(Name = "date joind")]

        public string datejoind { get; set; }
        [Display(Name = "Email Adress")]

        public string Email { get; set; }

    }
}
