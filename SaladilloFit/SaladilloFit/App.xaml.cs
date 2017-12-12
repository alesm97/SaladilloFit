using SaladilloFit.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SaladilloFit
{
    public partial class App : Application
    {
        public UsuariosRepository Usuarios { get; set; }
        public ObjetivosRepository Objetivos { get; set; }
        public HorariosRepository Horarios { get; set; }

        public App(string filename)
        {
            InitializeComponent();

            Usuarios = new UsuariosRepository(filename);
            Objetivos = new ObjetivosRepository(filename);
            Horarios = new HorariosRepository(filename);

            MainPage = new MainPage(Usuarios);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
