using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using RideAlong.Entities;
using SQLite.Net;

namespace RideAlong.Sqlite
{
    public class DARide
    {
        static object locker = new object();
        SQLiteConnection database;

        public DARide()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Ride>();
        }

        public IEnumerable<Ride> GetItems()
        {
            lock (locker)
            {
                return (from i in database.Table<Ride>() select i).ToList();
            }
        }

        public IEnumerable<Ride> GetItemOwner(string name)
        {
            return database.Query<Ride>("SELECT * FROM Ride WHERE Driver = ?", name);
        }

        public Ride GetItem(string id)
        {
            lock (locker)
            {
                return database.Table<Ride>().FirstOrDefault(x => String.Compare(x.ID, id) == 0);
            }
        }

        public int SaveItem(Ride item)
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
                return database.Delete<Ride>(id);
            }
        }
    }
}
