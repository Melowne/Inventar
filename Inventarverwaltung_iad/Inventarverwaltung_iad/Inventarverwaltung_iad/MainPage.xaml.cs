using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using Acr.UserDialogs;
using System.Diagnostics;

namespace Inventarverwaltung_iad
{
    public partial class MainPage : TabbedPage
    {
     
        
        public MainPage()
        {
           
            InitializeComponent();
            //   SqlCon.checkLogin("Meyer", "****");
            //  verwaltung.Content = new Verwaltung().getVerwaltung();
            // QuickResponse.Content = new QR_Reader().getQR();
            login();

        }

        private void login()
        {
            UserDialogs.Instance.Login(new LoginConfig
            {
                LoginPlaceholder = "Login",

                PasswordPlaceholder = "Password",
                OnAction = (x) =>
                {
                    SqlCon.checkLogin(x.LoginText, x.Password);
                    if (x.Ok)
                    {
                        try
                        {
                            verwaltung.Content = new Verwaltung().getVerwaltung();
                            QuickResponse.Content = new QR_Reader().getQR();
                        }
                        catch (Exception)
                        {
                            login();
                        }

                    }
                    else
                    {
                        System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                    }
                }
            });
        }
    
     
       
    }
}
