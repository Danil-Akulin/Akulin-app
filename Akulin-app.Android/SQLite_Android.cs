using System;
using System.IO;
using Xamarin.Forms;

namespace tthk_graz_app.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }

        public string GetDatabasePath(string filename)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, filename);
            return path;
        }
    }
}