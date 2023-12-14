using SQLite;
using System;

namespace AppBM.Models
{
    public class ListItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
