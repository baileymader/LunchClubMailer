using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchClubMailer
{
    public class LunchClubMember
    {
      // Here for XML Serializer to read
      public LunchClubMember() { }

      // Here to make my life easier
      public LunchClubMember(String name, String email, String phoneNumber)
      {
        this.name = name;
        this.email = email;
        this.phoneNumber = phoneNumber;
      }

        public string name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string diet { get; set; }
    }
}
