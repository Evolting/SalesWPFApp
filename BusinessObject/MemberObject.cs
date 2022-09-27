using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class MemberObject
    {
        private int memberId;
        private string email;
        private string companyName;
        private string city;
        private string country;
        private string password;

        public MemberObject(int memberId, string email, string companyName, string city, string country, string password)
        {
            this.memberId = memberId;
            this.email = email;
            this.companyName = companyName;
            this.city = city;
            this.country = country;
            this.password = password;
        }

        public int MemberId { get => memberId; set => memberId = value; }
        public string Email { get => email; set => email = value; }
        public string CompanyName { get => companyName; set => companyName = value; }
        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }
        public string Password { get => password; set => password = value; }
    }
}
