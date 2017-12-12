using SaladilloFit.Assets;
using SaladilloFit.Model;
using SaladilloFit.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaladilloFit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsuarioView : ContentPage
    {
        private UsuarioViewModel usuarioViewModel;
        private UsuariosRepository Repository { get; set; }

        public UsuarioView(Usuarios usuario, UsuariosRepository repository)
        {
            InitializeComponent();
            Repository = repository;
            usuarioViewModel = new UsuarioViewModel();
            BindingContext = usuarioViewModel;
            btnVolver.Clicked += Volver;
            usuarioViewModel.Fill(usuario);
        }

        private void Volver (object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage(Repository);
        }
    }
}