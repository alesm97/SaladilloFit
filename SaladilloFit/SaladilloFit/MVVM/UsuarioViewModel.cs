using SaladilloFit.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloFit.MVVM
{
    class UsuarioViewModel : INotifyPropertyChanged
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
        private string message;
        private string dni;
        private string horario;
        private string objetivo;
        private int edad;
        private string altura;
        private string peso;
        private float imc;
#endregion

        #region Propiedades
        public string WelcomeMessage
        {
            get
            {
                return message;
            }
            set
            {
                if (message != value)
                {
                    if (value != null)
                    {
                        message = value;
                    }
                    OnPropertyChanged("WelcomeMessage");
                }
            }
        }

        public string DNI
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
                    OnPropertyChanged("DNI");
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

        #region Métodos
        public void Fill(Usuarios usuario)
        {
            WelcomeMessage = "Bienvenido " + usuario.Nombre;
            DNI = usuario.Dni;

            //Se que no está bonito, pero me falta tiempo
            if (usuario.Horario == 1)
            {
                Horario = "Mañana";
            }else if(usuario.Horario == 2)
            {
                Horario = "Tarde";
            }else if(usuario.Horario == 3)
            {
                Horario = "Todo el día";
            }
            else
            {
                Horario = "Fines de semana";
            }

            if (usuario.Objetivo == 1)
            {
                Objetivo = "Adelgazar";
            }
            else if (usuario.Objetivo == 2)
            {
                Objetivo = "Definir";
            }
            else if (usuario.Objetivo == 3)
            {
                Objetivo = "Musculación";
            }
            else
            {
                Objetivo = "Mantenimiento";
            }

            Edad = usuario.Edad;
            Altura = usuario.Altura + " cm";
            Peso = usuario.Peso + " kg";
            IMC = usuario.IMC;
        }
#endregion


    }
}
