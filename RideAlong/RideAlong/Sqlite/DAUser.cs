using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using RideAlong.Entities;
using SQLite.Net;

namespace RideAlong.Sqlite
{
    public class DAUser
    {
        static object locker = new object();
        SQLiteConnection database;

        public DAUser()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<User>();
        }

        public IEnumerable<User> GetItems()
        {
            lock (locker)
            {
                return (from i in database.Table<User>() select i).ToList();
            }
        }

        public User GetItem(long id)
        {
            lock (locker)
            {
                return database.Table<User>().FirstOrDefault(x => x.ID == id);
            }
        }

        public int SaveItem(User item)
        {
            lock (locker)
            {
                return database.Insert(item);
            }
        }

        public int DeleteItem(string id)
        {
            lock (locker)
            {
                return database.Delete<User>(id);
            }
        }
    }
}
