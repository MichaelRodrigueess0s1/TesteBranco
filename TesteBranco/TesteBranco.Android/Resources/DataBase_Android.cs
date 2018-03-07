using SQLite;
using System.IO;
using TesteBranco.DataBase;
using TesteBranco.Droid.Data;



[assembly: Xamarin.Forms.Dependency(typeof(DataBase_Android))]
namespace TesteBranco.Droid.Data
{
    class DataBase_Android : IDataBase
    {
        public SQLiteConnection GetConnection()
        {
            var nomeDB = TesteBranco.Infrastructure.Constants.BaseAppConstants.DatabaseName;
            var pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var caminhoDB = Path.Combine(pasta, nomeDB);
            return new SQLiteConnection(caminhoDB);            
        }
    }
}