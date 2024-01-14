using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Threading.Tasks;
using AplicatieSala.Models;
using SQLiteNetExtensions.Attributes;
using AplicatieSala;

namespace AplicatieSala.Data
{
    public class ExerciseCount
    {
        readonly SQLiteAsyncConnection _database;
        public ExerciseCount(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ListaAplicatie>().Wait();
            _database.CreateTableAsync<Exercitiu>().Wait();
            _database.CreateTableAsync<ListaExercitii>().Wait();
        }
        public Task<int> SaveExercitiuAsync(Exercitiu Exercitiu)
        {
            if (Exercitiu.ID != 0)
            {
                return _database.UpdateAsync(Exercitiu);
            }
            else
            {
                return _database.InsertAsync(Exercitiu);
            }
        }
        public Task<int> DeleteExercitiuAsync(Exercitiu Exercitiu)
        {
            return _database.DeleteAsync(Exercitiu);
        }
        public Task<List<Exercitiu>> GetExercitiusAsync()
        {
            return _database.Table<Exercitiu>().ToListAsync();
        }
        public Task<int> SaveListaExercitiiAsync(ListaExercitii listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Exercitiu>> GetListaExercitiiAsync(int listaexercitiiid)
        {
            return _database.QueryAsync<Exercitiu>(
            "select P.ID, P.Description from Exercitiu P"
            + " inner join ListaExercitii LP"
            + " on P.ID = LP.ExercitiuID where LP.listaexercitiiid = ?",
            listaexercitiiid);
        }
        public Task<List<ListaAplicatie>> GetListaExercitiiAsync()
        {
            return _database.Table<ListaAplicatie>().ToListAsync();
        }
        public Task<int> SaveListaAplicatieAsync(ListaAplicatie shopList)
        {
            if (shopList.ID != 0)
            {
                return _database.UpdateAsync(shopList);
            }
            else
            {
                return _database.InsertAsync(shopList);
            }
        }

        public Task<int> DeleteListaAplicatieAsync(ListaAplicatie shopList)
        {
            return _database.DeleteAsync(shopList);
        }
    }
}
