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
                try
                {
                    return (from i in database.Table<User>() select i).ToList();
                }
                catch (SQLiteException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.StackTrace);
                    return null;
                }
                
            }
        }

        public User GetItem(int id)
        {
            lock (locker)
            {
                try
                {
                    return database.Table<User>().FirstOrDefault(x => x.id_db == id);
                }  catch (SQLiteException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.StackTrace);
                    return null;
                }
            
            }
        }

        public User GetItemFacebookId(long id)
        {
            lock (locker)
            {
                try
                {
                    return database.Table<User>().FirstOrDefault(x => x.id == id);
                }
                catch (SQLiteException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.StackTrace);
                    return null;
                }

            }
        }

        public int SaveItem(User item)
        {
            lock (locker)
            {
                try
                {
                    return database.Insert(item);
                } catch (SQLiteException e)
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
                    return database.Delete<User>(id);
                } catch (SQLiteException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.StackTrace);
                    return -1;
                }
                
            }
        }
    }
}
