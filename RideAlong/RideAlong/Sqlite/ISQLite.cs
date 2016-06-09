using System;
using SQLite.Net;

namespace RideAlong.Sqlite
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
