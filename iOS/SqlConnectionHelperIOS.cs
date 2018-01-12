using System;
using System.IO;
using GroovyPics.iOS;
using GroovyPics.Services;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqlConnectionHelperIOS))]
namespace GroovyPics.iOS
{
    public class SqlConnectionHelperIOS : ISqlConnectionHelper
    {
        public SqlConnectionHelperIOS()
        {
        }

        public SQLiteConnection GetConnection()
        {
            var fileName = "GroovyDatabase.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);
            var connection = new SQLiteConnection( path,true);

            return connection;
        }
    }
}
