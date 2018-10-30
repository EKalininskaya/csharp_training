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
        private string detailData;

        public ContactData()
        {
        }

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

        public string DetailData
        { get
            {
                if (detailData != null)
                {
                    return detailData;
                }
                else
                {
                    var rn = "\r\n";
                    var result = string.Empty;

                    if (!string.IsNullOrEmpty(FirstName))
                    {
                        result += FirstName;
                    }

                    if (!string.IsNullOrEmpty(LastName))
                    {
                        result += " " + LastName;
                    }

                    result += rn;

                    if (!string.IsNullOrEmpty(Address))
                    {
                        result += Address;
                    }

                    result += rn+rn;

                    if (!string.IsNullOrEmpty(HomePhone))
                    {
                        result += "H:" + HomePhone;
                    }

                    result += rn;
                    if (!string.IsNullOrEmpty(MobilePhone))
                    {
                        result += "M:" + MobilePhone;
                    }
                    result += rn;

                    if (!string.IsNullOrEmpty(WorkPhone))
                    {
                        result += "W:" + WorkPhone;
                    }

                    return result.Trim();

                    //return $"{FirstName} {LastName}{rn}{Address}{rn}{rn}H: {HomePhone}{rn}M: {MobilePhone}{rn}W: {WorkPhone}".Trim();
                   
                    /*return (FirstName +" " + LastName +"\r\n"+ Address
                    +"\r\n\r\n" + "H: " + HomePhone + "\r\n" + "M: " + MobilePhone + "\r\n" + "W: " + WorkPhone).Trim();*/
                }
            }
            set
            {
                detailData = value;
            }
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
