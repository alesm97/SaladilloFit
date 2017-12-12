using SaladilloFit.Assets;
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
    public partial class GerenteView : ContentPage
    {
        private GerenteViewModel gerenteViewModel;
        private UsuariosRepository Repository { get; set; }

        public GerenteView(UsuariosRepository repository)
        {
            InitializeComponent();
            Repository = repository;
            gerenteViewModel = new GerenteViewModel();
            BindingContext = gerenteViewModel;
            btnAddUser.Clicked += AgregarUsuario;
            btnHome.Clicked += Volver;
            gerenteViewModel.RellenarDatos(Repository);
        }

        private void AgregarUsuario(object sender, EventArgs e)
        {
            gerenteViewModel.AgregarUsuarioAsync(Repository);
        }

        private void Volver(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage(Repository);
        }
    }
}