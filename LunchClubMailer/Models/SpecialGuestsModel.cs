using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace LunchClubMailer
{
    public class SpecialGuestsModel : INotifyPropertyChanged
    {

        private LunchClubFile file = LunchClubFile.GetFile();
        private LunchClubModel clubModel;
        private AddSpecialGuestModel addModel = new AddSpecialGuestModel();
        private EditSpecialGuestModel editModel = new EditSpecialGuestModel();
        public string additionalText { get; set; }
        public List<LunchClubGuest> guestList
        {
            get
            {
                return file.guests.ToList();
            }
        }
        public LunchClubGuest selectedGuest { get; set; }

        public SpecialGuestsModel(LunchClubModel clubModel)
        {
            this.clubModel = clubModel;
            addModel.requestClose += addModel_requestClose;
            editModel.requestClose += editModel_requestClose;
            if (file.additionalText != null) { additionalText = file.additionalText; }
            //PropertyChanged(this, new PropertyChangedEventArgs("guestList"));
        }


        #region Commands
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new DelegateCommand(param => this.AddGuest(param));
                }
                return _AddCommand;
            }
        }
        DelegateCommand _AddCommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (_DeleteCommand == null)
                {
                    _DeleteCommand = new DelegateCommand(param => this.DeleteGuest());
                }
                return _DeleteCommand;
            }
        }
        DelegateCommand _DeleteCommand;

        public ICommand EditCommand
        {
            get
            {
                if (_EditCommand == null)
                {
                    _EditCommand = new DelegateCommand(param => this.EditGuest());
                }
                return _EditCommand;
            }
        }
        DelegateCommand _EditCommand;

        public ICommand SendCommand
        {
            get
            {
                if (_SendCommand == null)
                {
                    _SendCommand = new DelegateCommand(param => this.SendEmailsWithGuests());
                }
                return _SendCommand;
            }
        }
        DelegateCommand _SendCommand;
        #endregion

        private void AddGuest(object guest)
        {
            addModel.Clear();
            AddSpecialGuest newGuestView = new AddSpecialGuest(addModel);
            newGuestView.Show();
            PropertyChanged(this, new PropertyChangedEventArgs("guestList"));
        }

        private void DeleteGuest()
        {
            if (selectedGuest != null)
            {
                file.guests.Remove(file.guests.First(m => m.name.Equals(selectedGuest.name)));
                file.Save();
                PropertyChanged(this, new PropertyChangedEventArgs("guestList"));
            }
            else
            {
                MessageBox.Show("Please select a guest to delete first.");
            }

        }

        private void EditGuest()
        {
            if (selectedGuest != null)
            {
                LunchClubGuest guest = file.guests.First(m => m.name.Equals(selectedGuest.name));
                editModel.name = guest.name;
                editModel.email = guest.email;
                editModel.phoneNumber = guest.phoneNumber;
                editModel.adminName = guest.adminName;
                editModel.adminEmail = guest.adminEmail;
                editModel.adminPhoneNumber = guest.adminPhoneNumber;
                editModel.diet = guest.diet;
                editModel.editGuest = guest;

                AddSpecialGuest newGuestView = new AddSpecialGuest(editModel);
                newGuestView.Show();
                PropertyChanged(this, new PropertyChangedEventArgs("guestList"));
            }
            else
            {
                MessageBox.Show("Please select a guest to edit first.");
            }
        }

        private void SendEmailsWithGuests()
        {
            file.additionalText = this.additionalText;
            file.Save();
            clubModel.SendEmails(true);
        }

        #region EventHandlers
        public event PropertyChangedEventHandler PropertyChanged;

        private void addModel_requestClose(object sender, EventArgs e)
        {
            PropertyChanged(this, new PropertyChangedEventArgs("guestList"));
        }

        private void editModel_requestClose(object sender, EventArgs e)
        {
            PropertyChanged(this, new PropertyChangedEventArgs("guestList"));
        }

        #endregion
    }
}
