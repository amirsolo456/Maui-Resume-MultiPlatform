using CommunityToolkit.Mvvm.ComponentModel;
using Resume.Maui.ViewModels.BaseViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Maui.Pages
{
    public partial class LoginViewModel :  SampleViewModel
    {
        private string _loginUsername;
        private string _loginPassword;
        public LoginViewModel()
        {
            
        }
        public string LoginUsername
        {
            get => this._loginUsername;
            set => this.UpdateValue(ref this._loginUsername, value);
        }

        public string LoginPassword
        {
            get => this._loginPassword;
            set => this.UpdateValue(ref this._loginPassword, value);
        }
     
    }
}
