using SaladilloFit.Assets;
using SaladilloFit.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SaladilloFit
{
    public partial class MainPage : ContentPage
    {
        UsuariosRepository Usuarios { get; set; }
        LoginViewModel loginViewModel ;

        public MainPage(UsuariosRepository usuarios)
        {
            InitializeComponent();
            Usuarios = usuarios;
            loginViewModel = new LoginViewModel();
            BindingContext = loginViewModel;
            btnEntrar.Clicked += Login;
        }

        private void txtUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            string entryText = ((Entry)sender).Text;

            if (entryText.Length > 9)
            {
                ((Entry)sender).Text = entryText.Remove(9);
            }
        }

        private void Login(object sender, EventArgs e)
        {
            loginViewModel.ComprobarLoginAsync(Usuarios);
        }
    }
}
