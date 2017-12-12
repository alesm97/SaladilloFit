using SaladilloFit.Assets;
using SaladilloFit.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloFit.MVVM
{
    class GerenteViewModel : INotifyPropertyChanged
    {

        #region Interfaz Binding
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Atributos
        private string nombre;
        private string dni;
        private string horario;
        private string objetivo;
        private int edad;
        private string altura;
        private string peso;
        private float imc;
        private string error;
        #endregion

        #region Propiedades
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if (nombre != value)
                {
                    if (value != null)
                    {
                        nombre = value;
                    }
                    OnPropertyChanged("Nombre");
                }
            }
        }

        public string Error
        {
            get
            {
                return error;
            }
            set
            {
                if (error != value)
                {
                    if (value != null)
                    {
                        error = value;
                    }
                    OnPropertyChanged("Error");
                }
            }
        }

        public string Dni
        {
            get
            {
                return dni;
            }
            set
            {
                if (dni != value)
                {
                    if (value != null)
                    {
                        dni = value;
                    }
                    OnPropertyChanged("Dni");
                }
            }
        }

        public string Horario
        {
            get
            {
                return horario;
            }
            set
            {
                if (horario != value)
                {
                    if (value != null)
                    {
                        horario = value;
                    }
                    OnPropertyChanged("Horario");
                }
            }
        }

        public string Objetivo
        {
            get
            {
                return objetivo;
            }
            set
            {
                if (objetivo != value)
                {
                    if (value != null)
                    {
                        objetivo = value;
                    }
                    OnPropertyChanged("Objetivo");
                }
            }
        }

        public int Edad
        {
            get
            {
                return edad;
            }
            set
            {
                if (edad != value)
                {
                    if (value != null)
                    {
                        edad = value;
                    }
                    OnPropertyChanged("Edad");
                }
            }
        }

        public string Altura
        {
            get
            {
                return altura;
            }
            set
            {
                if (altura != value)
                {
                    if (value != null)
                    {
                        altura = value;
                    }
                    OnPropertyChanged("Altura");
                }
            }
        }

        public string Peso
        {
            get
            {
                return peso;
            }
            set
            {
                if (peso != value)
                {
                    if (value != null)
                    {
                        peso = value;
                    }
                    OnPropertyChanged("Peso");
                }
            }
        }

        public float IMC
        {
            get
            {
                return imc;
            }
            set
            {
                if (imc != value)
                {
                    if (value != null)
                    {
                        imc = value;
                    }
                    OnPropertyChanged("IMC");
                }
            }
        }

        #endregion

        #region Metodos

        public async void AgregarUsuarioAsync(UsuariosRepository repository)
        {
            if(!string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(Dni) && !string.IsNullOrEmpty(Horario) && !string.IsNullOrEmpty(Altura) && !string.IsNullOrEmpty(Peso) && !string.IsNullOrEmpty(Objetivo))
            {
                await repository.AddNewUsuario(Dni,Nombre,Dni,int.Parse(Horario),Edad,int.Parse(Altura),int.Parse(Peso),(int.Parse(Peso)/(int.Parse(Altura)*int.Parse(Altura))),int.Parse(Objetivo),"usuario");
            }
            else
            {
                Error = "Debe introducir todos los datos";
            }
        }

        public void RellenarDatos(UsuariosRepository repository)
        {
            Task<List<Usuarios>> lista = repository.GetAllUsuarios();

        }

        #endregion

    }
}
