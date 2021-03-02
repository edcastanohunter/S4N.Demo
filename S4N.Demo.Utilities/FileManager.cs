using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace S4N.Demo.Utilities
{
    public class FileManager
    {
        private static FileManager _instance;

        public static FileManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FileManager();
                return _instance;
            }
        }

        public List<FileInfo> LeerDeRuta(string ruta, string nombreArchivo)
        {
            string pattern = nombreArchivo + "[0-9][0-9].txt";
            ruta = Path.Combine(Environment.CurrentDirectory, ruta);
            return (new DirectoryInfo(ruta).GetFiles())
                .Where((s => Regex.IsMatch(s.Name, pattern))).ToList();
        }

        public List<string> LeerArchivo(FileInfo archivo)
        {
            List<string> stringList = new List<string>();
            if (archivo.Exists)
            {
                StreamReader streamReader = new StreamReader((Stream)archivo.Open(FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read));
                stringList = new List<string>((IEnumerable<string>)File.ReadAllLines(archivo.FullName));
            }
            return stringList;
        }

        public void EscribirLineaArchivo(string ruta, string reporte)
        {

            ruta = Path.Combine(Environment.CurrentDirectory, ruta);
            if (File.Exists(ruta))
            {
                using(StreamWriter outputFile = new StreamWriter(Path.Combine(ruta),append: true))
                {
                    outputFile.WriteLine(reporte);
                }
            }
            else
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(ruta)))
                {
                    outputFile.WriteLine(reporte);
                }
            }
        }
    }
}
