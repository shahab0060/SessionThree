using SessionThree.Context;
using SessionThree.Droid.Context;
using Xamarin.Forms;
using Environment = System.Environment;

[assembly: Dependency(typeof(DbMethods))]
namespace SessionThree.Droid.Context
{
    public class DbMethods : IContext
    {
        public string GetDbPath(string dbName)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(folderPath, dbName);
        }
    }
}