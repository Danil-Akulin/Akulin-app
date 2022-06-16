using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace tthk_graz_app
{
    public class ContactRespository
    {
        private SQLiteConnection database;

        public ContactRespository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Contact>();
        }

        public List<Contact> GetItems()
        {
            return database.Table<Contact>().ToList();
        }

        public Contact GetItem(int id)
        {
            return database.Get<Contact>(id);
        }

        public int DeleteItem(int id)
        {
            return database.Delete<Contact>(id);
        }

        public int SaveItem(Contact contact)
        {
            if (contact.Id != 0)
            {
                database.Update(contact);
                return contact.Id;
            }
            else
            {
                return database.Insert(contact);
            }
        }
    }
}