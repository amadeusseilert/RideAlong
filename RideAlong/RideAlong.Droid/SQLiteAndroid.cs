using System;
using RideAlong.Sqlite;
using SQLite.Net;
using System.IO;
using RideAlong.Resources;
using RideAlong.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_Android))]
namespace RideAlong.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        {
        }

        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = Settings.DbName;
            string documentsPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var path = Path.Combine(documentsPath, sqliteFilename);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLiteConnection(platform, path);

            return connection;
        }
    }
}