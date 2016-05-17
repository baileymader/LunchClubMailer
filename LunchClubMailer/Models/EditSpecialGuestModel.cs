using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace LunchClubMailer
{
    public class EditSpecialGuestModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string diet { get; set; }
        public string adminName { get; set; }
        public string adminPhoneNumber { get; set; }
        public string adminEmail { get; set; }

        public LunchClubGuest editGuest { get; set; }

        public string GoButtonTitle
        {
            get { return "Edit"; }
            set
            {
                //no op
            }
        }

        private LunchClubFile file = LunchClubFile.GetFile();

        public void EditGuest()
        {
            ValidateEmail ve = new ValidateEmail();

            if (name.Length == 0)
            {
                MessageBox.Show("Please enter a name.");
            }
            else if (!ve.IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email.");
            }
            else if (phoneNumber.Length < 5)
            {
                MessageBox.Show("Please enter a valid phone number");
            }
            else if (adminName.Length == 0)
            {
                MessageBox.Show("Please enter an admin name.");
            }
            else if (!ve.IsValidEmail(adminEmail))
            {
                MessageBox.Show("Please enter a valid admin email.");
            }
            else if (adminPhoneNumber.Length < 5)
            {
                MessageBox.Show("Please enter a valid admin phone number");
            }
            else
            {

                LunchClubGuest em = file.guests.First(m => m.name.Equals(editGuest.name));
                em.name = this.name;
                em.email = this.email;
                em.phoneNumber = this.phoneNumber;
                em.diet = this.diet;
                em.adminName = this.adminName;
                em.adminEmail = this.adminEmail;
                em.adminPhoneNumber = this.adminPhoneNumber;

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
                    _AddCommand = new DelegateCommand(param => this.EditGuest());
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
    }
}
    
