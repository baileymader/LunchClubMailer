using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LunchClubMailer.Models
{
    public class ImportExportModel
    {

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

        #region Commands
        public ICommand TemplateFileCommand
        {
            get
            {
                if (_TemplateFileCommand == null)
                {
                    _TemplateFileCommand = new DelegateCommand(param => this.TemplateFile());
                }
                return _TemplateFileCommand;
            }
        }
        DelegateCommand _TemplateFileCommand;

        public ICommand ImportFileCommand
        {
            get
            {
                if (_ImportFileCommand == null)
                {
                    _ImportFileCommand = new DelegateCommand(param => this.ImportFile());
                }
                return _ImportFileCommand;
            }
        }
        DelegateCommand _ImportFileCommand;

        public ICommand ExportFileCommand
        {
            get
            {
                if (_ExportFileCommand == null)
                {
                    _ExportFileCommand = new DelegateCommand(param => this.ExportFile());
                }
                return _ExportFileCommand;
            }
        }
        DelegateCommand _ExportFileCommand;

        #endregion

        private void TemplateFile()
        {
            //Launch a message box with info and ok/cancel buttons
            //Launch a save dialog tied to the file
        }     

        private void ImportFile()
        {
            //launch an open dialog
            //format check the file
            //put all of the data from the file into program
            //success message box
            OnRequestClose(null);
        }

        private void ExportFile()
        {
            //launch a save dialog
            //create file from data in program
            //save to location chosen
        }

    }

}
