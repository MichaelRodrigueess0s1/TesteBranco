//using SQLite;
//using System.IO;
//using Xamarin.Forms;

//using TesteBranco.Droid.Data;

//[assembly: Dependency(typeof(Connection))]
//namespace TesteBranco.Droid.Data
//{
//    public class Connection : IConnection
//    {
//        public SQLiteAsyncConnection GetConection(string filename)
//        {
//            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
//            return new SQLiteAsyncConnection(Path.Combine(path, filename));
//        }
//    }
//}