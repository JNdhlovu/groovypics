using System;
using SQLite;

namespace GroovyPics.Database.Entities
{
    public class ImageEntry
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string LocalUrl { get; set; }
        public DateTime CreatedAt { get; set; }
 
        public ImageEntry()
        {
        }
    }
}
