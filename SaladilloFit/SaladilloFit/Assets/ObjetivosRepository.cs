using SaladilloFit.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloFit.Assets
{
    public class ObjetivosRepository
    {

        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public ObjetivosRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Objetivos>().Wait();
        }

        public async Task<List<Objetivos>> GetAllObjetivos()
        {
            List<Objetivos> lista = new List<Objetivos>();

            try
            {
                lista = await conn.Table<Objetivos>().ToListAsync();

            }
            catch (Exception ex)
            {
                StatusMessage = String.Format("Failed to retireve data. {0}", ex.Message);
                lista = new List<Objetivos>();
            }

            return lista;
        }
    }
}
