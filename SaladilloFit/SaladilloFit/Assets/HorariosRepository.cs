using SaladilloFit.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloFit.Assets
{
    public class HorariosRepository
    {

        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public HorariosRepository (string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Horarios>().Wait();
        }

        public async Task<List<Horarios>> GetAllHorarios()
        {
            List<Horarios> lista = new List<Horarios>();

            try
            {
                lista = await conn.Table<Horarios>().ToListAsync();

            }
            catch (Exception ex)
            {
                StatusMessage = String.Format("Failed to retireve data. {0}", ex.Message);
                lista = new List<Horarios>();
            }

            return lista;
        }


    }
}
