using SaladilloFit.Assets;
using SaladilloFit.Model;
using SaladilloFit.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloFit.MVVM
{
    public class LoginViewModel : INotifyPropertyChanged
    {

        #region Atributos
        public string error = string.Empty;
        private const int MAX_LENGTH = 9;
        private string nickname;
        private string password;
        #endregion

        #region Propiedades

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

        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                if (nickname != value)
                {
                    if (value != null && value.Length <= 10)
                    {
                        nickname = value;
                    }
                    OnPropertyChanged("Nickname");
                }
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password != value)
                {
                    if (value != null && value.Length <= 10)
                    {
                        password = value;
                    }
                    OnPropertyChanged("Password");
                }
            }
        }
        #endregion

        #region Interfaz INotifyPropertyChanged
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

        #region Métodos

        public async void ComprobarLoginAsync(UsuariosRepository repository)
        {
            Usuarios usuarioLogin;
            if ((string.IsNullOrEmpty(Nickname) || Nickname.Length < MAX_LENGTH) && (string.IsNullOrEmpty(Password) || Password.Length < MAX_LENGTH))
            {
               Error = "Debe introducir Usuario y Contraseña.";
            }else if(string.IsNullOrEmpty(Nickname) || Nickname.Length < MAX_LENGTH)
            {
                Error = "Debe introducir Usuario (9 caracteres)";
            }else if(string.IsNullOrEmpty(Password) || Password.Length < MAX_LENGTH)
            {
                Error = "Debe introducir Contraseña (9 caracteres)";
            }
            else
            {
                List<Usuarios> usuarios = await repository.GetAllUsuarios();
                usuarioLogin = usuarios.SingleOrDefault(t => t.Dni == Nickname);

                if(usuarioLogin == null)
                {
                    Error = "El usuario no está dado de alta";
                }
                else
                {
                    if (!usuarioLogin.Password.Equals(Password))
                    {
                        Error = "Contraseña incorrecta";
                    }
                    else
                    {
                        if (usuarioLogin.tipo.Equals("gerente"))
                        {
                            App.Current.MainPage = new GerenteView(repository);
                        }
                        else
                        {
                            App.Current.MainPage = new UsuarioView(usuarioLogin, repository);
                        }
                    }
                }
            }
        }
        #endregion

    }
}
