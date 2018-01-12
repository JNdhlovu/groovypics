using System;
using SQLite;

namespace GroovyPics.Services
{
    public interface ISqlConnectionHelper
    {
        SQLiteConnection GetConnection();
    }
}
