using System;
using System.IO;
using GroovyPics.Droid;
using GroovyPics.Services;
using SQLite;
using SQLite.Net.Platform.XamarinAndroid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqlConnectionHelperAndroid))]
namespace GroovyPics.Droid
{
    public class SqlConnectionHelperAndroid : ISqlConnectionHelper
    {
        public SqlConnectionHelperAndroid()
        {
        }

        public SQLiteConnection GetConnection()
        {
            var fileName = "GroovyDatabase.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);
            var connection = new SQLiteConnection( path,true);
            return connection;
        }
    }
}
