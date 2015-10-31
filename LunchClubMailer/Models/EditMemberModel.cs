using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Globalization;

namespace LunchClubMailer.Models
{
    public class EditMemberModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string diet { get; set; }

        public LunchClubMember editMember { get; set; }

        public string GoButtonTitle
        {
            get { return "Edit"; }
            set
            {
                //no op
            }
        }

        private LunchClubFile file = LunchClubFile.GetFile();

        public void EditMember()
        {
            if (name.Length == 0)
            {
                MessageBox.Show("Please enter a name.");
            }
            else if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email.");
            }
            else if (phoneNumber.Length < 5)
            {
                MessageBox.Show("Please enter a valid phone number");
            }
            else if (file.members.FirstOrDefault(m => m.name.Equals(name)) != null)
            {
                MessageBox.Show("Member already exists under this name. If this is a new person, add a middle initial or department.");
            }
            else
            {

                LunchClubMember em = file.members.First(m => m.name.Equals(editMember.name));
                em.name = name;
                em.email = email;
                em.phoneNumber = phoneNumber;
                em.diet = diet;

                file.Save();
                OnRequestClose(null);
            }
        }

        public void Clear()
        {
            name = string.Empty;
            email = string.Empty;
            phoneNumber = string.Empty;
            diet = string.Empty;
        }

        #region Commands
        public ICommand GoCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new DelegateCommand(param => this.EditMember());
                }
                return _AddCommand;
            }
        }
        DelegateCommand _AddCommand;
        #endregion

        #region EventHandlers
        public event EventHandler requestClose;

        protected virtual void OnRequestClose(EventArgs e)
        {
            EventHandler handler = requestClose;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        #region ValidateEmail
        bool invalid = false;

        public bool IsValidEmail(string strIn)
        {
            invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names. 
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format. 
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }


        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }
        #endregion
    }
}
