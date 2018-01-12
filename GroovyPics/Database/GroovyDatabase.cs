using System;
using System.Collections.Generic;
using System.Linq;
using GroovyPics.Database.Entities;
using GroovyPics.Services;
using SQLite;
using Xamarin.Forms;

namespace GroovyPics.Database
{
    public class GroovyDatabase
    {
        private SQLiteConnection _connection;

        public GroovyDatabase()
        {
           _connection = DependencyService.Get<ISqlConnectionHelper>().GetConnection();
            _connection.CreateTable<ImageEntry>();
        }

        public IEnumerable<ImageEntry> getImages()
        {
            return (from t in _connection.Table<ImageEntry>()
                    select t).ToList();
        }

        public ImageEntry getImage(int id)
        {
            return _connection.Table<ImageEntry>().FirstOrDefault(t => t.ID == id);
        }

        public void addImage(string url)
        {
            var image = new ImageEntry
            {
                LocalUrl = url,
                CreatedAt = DateTime.Now
            };

            _connection.Insert(image);
        }
    }
}
