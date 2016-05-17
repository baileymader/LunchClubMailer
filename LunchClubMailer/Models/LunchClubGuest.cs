using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchClubMailer
{
    public class LunchClubGuest: LunchClubMember
    {
        public LunchClubGuest() { }

        public string adminName { get; set; }
        public string adminEmail { get; set; }
        public string adminPhoneNumber { get; set; }
        public bool isAttending { get; set; }
    }
}
