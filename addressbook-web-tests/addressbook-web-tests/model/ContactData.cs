using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    //public class ContactData, , IComparable<ContactData>
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;

        public ContactData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode();
        }

        public override string ToString()
        {
            return "firstname" + FirstName + " " + "lastname" + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (other.FirstName == FirstName)
            {
                return string.Compare(LastName, other.LastName);
            }

            return string.Compare(FirstName, other.FirstName);
        }

        public string DetailData { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Title { get; set; }
       
        public string NickName { get; set; }
        
        public string MiddleName { get; set; }
        
        public string Company { get; set; }
        
        public string Address { get; set; }
        
        public string AllPhones
        {
            get
            {
                if (allPhones !=null)
                {
                    return allPhones;
                }else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }

            set {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone =="")
            {
                return "";
            }
            return Regex.Replace(phone,"[ -()]","")+"\r\n";
            //  phone.Replace("", "").Replace("-", "").Replace("(", "").Replace(")", "")
        }

        public string HomePhone { get; set; }

        public string WorkPhone { get; set; }

        public string MobilePhone { get; set; }


        public string Fax { get; set; }
        
        public string Email { get; set; }
        
        public string Email2 { get; set; }
        
        public string Email3 { get; set; }
        
        public string HomePage { get; set; }
        
    }
}
