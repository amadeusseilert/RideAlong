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
                try
                {
                    return (from i in database.Table<Ride>() select i).ToList();
                }
                catch (SQLiteException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.StackTrace);
                    return null;
                }
                
            }
        }

        public IEnumerable<Ride> GetItemByDriver(string name)
        {
            lock (locker)
            {
                try
                {
                    return database.Query<Ride>("SELECT * FROM Ride WHERE driver = ?", name);
                }
                catch (SQLiteException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.StackTrace);
                    return null;
                }
            }
                     
        }

        public IEnumerable<Ride> GetItemByPassanger(string name)
        {
            lock (locker)
            {
                try
                {
                    return database.Query<Ride>("SELECT * FROM Ride WHERE driver != ?", name);
                }
                catch (SQLiteException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.StackTrace);
                    return null;
                }
            }

        }

        public Ride GetItem(int id)
        {
            lock (locker)
            {
                try
                {
                    return database.Table<Ride>().FirstOrDefault(x => x.id_db == id);
                }
                catch (SQLiteException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.StackTrace);
                    return null;
                }
                
            }
        }

        public Ride GetItemDynamoID(string id)
        {
            lock (locker)
            {
                try
                {
                    return database.Table<Ride>().FirstOrDefault(x => String.Compare(x.id, id) == 0);
                }
                catch (SQLiteException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.StackTrace);
                    return null;
                }

            }
        }

        public int SaveItem(Ride item)
        {
            lock (locker)
            {
                try
                {
                    return database.Insert(item);
                }
                catch (SQLiteException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.StackTrace);
                    return -1;
                }
                
            }
        }

        public int DeleteItem(string id)
        {
            lock (locker)
            {
                try
                {
                    return database.Delete<Ride>(id);
                }
                catch (SQLiteException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.StackTrace);
                    return -1;
                }
                
            }
        }
    }
}
