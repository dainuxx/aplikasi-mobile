using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using AppBM.Models;
using System.Collections.Generic;

namespace AppBM.Services
{
    public class Database
    {
        readonly SQLiteAsyncConnection db;
        public Database(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            
            db.CreateTableAsync<ListItem>();
            db.CreateTableAsync<ListUsers>();
        }

        // ListItem
        public Task<List<ListItem>> GetListAsync()
        {
            return db.Table<ListItem>().ToListAsync();
        }

        public Task<int> AddListAsync(ListItem list)
        {
            if (list.Id != 0)
            {
                // Update
                return db.UpdateAsync(list);
            }
            else
            {
                // Add
                return db.InsertAsync(list);
            }
        }

        public Task<int> UpdateListAsync(ListItem list)
        {
            return db.UpdateAsync(list);
        }

        public Task<int> DeleteListAsync(ListItem list)
        {
            return db.DeleteAsync(list);
        }
        // End List Item
        // ListUsers
        public Task<List<ListUsers>> GetUsersAsync()
        {
            return db.Table<ListUsers>().ToListAsync();
        }

        public Task<ListUsers> GetSpecificUsersAsync(string username, string password)
        { 
            return db.Table<ListUsers>().Where(i => i.Username == username && i.Password == password).FirstOrDefaultAsync();
        }

        public Task<int> AddUsersAsync(ListUsers list)
        {
            if (list.Id != 0)
            {
                //Update
                return db.UpdateAsync(list);
            }
            else
            {
                // Add
                return db.InsertAsync(list);
            }
        }

        public Task<int> UpdateUsersAsync(ListUsers list)
        {
            return db.UpdateAsync(list);
        }

        public Task<int> DeleteUsersAsync(ListUsers list)
        {
            return db.DeleteAsync(list);
        }
        //End ListUsers
    }
}
