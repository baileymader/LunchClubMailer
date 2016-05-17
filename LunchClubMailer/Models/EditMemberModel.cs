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

    }
}
