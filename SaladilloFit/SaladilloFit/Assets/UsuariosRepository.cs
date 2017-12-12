using SaladilloFit.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloFit.Assets
{
    public class UsuariosRepository
    {

        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn ;

        public UsuariosRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Usuarios>();
        }

        public async Task<List<Usuarios>> GetAllUsuarios()
        {
            List<Usuarios> lista = new List<Usuarios>();

            try
            {
                lista = await conn.Table<Usuarios>().ToListAsync();

            }
            catch (Exception ex)
            {
                StatusMessage = String.Format("Failed to retireve data. {0}", ex.Message);
                lista = new List<Usuarios>();
            }

            return lista;
        }

        public async Task AddNewUsuario(string dni, string nombre, string password, int horario, int edad, int altura, float peso, float imc, int objetivo, string tipo)
        {

            int result = 0;
            try
            {
                result = await conn.InsertAsync(new Usuarios() { Dni = dni, Nombre = nombre, Password = password, Horario = horario, Edad = edad, Altura = altura, Peso = peso, IMC = imc, Objetivo = objetivo, tipo = tipo });
            }
            catch (Exception ex)
            {

            }

        }


    }
}
