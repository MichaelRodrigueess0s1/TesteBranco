using SQLite;
using System;
using System.IO;
using Xamarin.Forms;
using TesteBranco.DataBase;
using TesteBranco.iOS.Data;



[assembly: Dependency(typeof(DataBase_IOS))]
namespace TesteBranco.iOS.Data
{
    public class DataBase_IOS : IDataBase
    {
        public SQLiteConnection GetConnection()
        {
            var nomeDB = Infrastructure.Constants.BaseAppConstants.DatabaseName;
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return new SQLiteConnection(Path.Combine(libFolder, nomeDB));
        }
   
    }
}