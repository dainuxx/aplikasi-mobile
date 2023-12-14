using System;
using SQLite;

namespace AppBM.Models
{
    public class ListUsers
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
