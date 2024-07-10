using Microsoft.AspNetCore.Identity;

namespace Test2.Data
{
    public class Employ : IdentityUser
    {

        public string? name { get; set; }
      //  public string name? { get; set; }
        //اخل يعلامة استفهام حتى يصير null
        public string? lastname { get; set; }
        public string? taxid { get; set; }
        public DateTime dateodbirth { get; set; }
        public DateTime datejoind { get; set; }
    }
}
