using System;
using System.IO;
using LTBLApplication.Droid;
using Xamarin.Forms;
using Environment = System.Environment;

[assembly: Dependency(typeof(SaveLoad))]
namespace LTBLApplication.Droid
{
    public class SaveLoad : ISaveLoad
    {
        public void Save(string _filename, string _text)
        {
            var path = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(path, _filename);
            File.WriteAllText(filePath, _text);
        }

        public string Load(string _filename)
        {
            try
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var filePath = Path.Combine(path, _filename);
                return File.ReadAllText(filePath);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}