using S4N.Demo.SharedKernel;
using S4N.Demo.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4N.Demo.Domain
{
    public class Local : BaseEntity
    {
        public string Nombre { get; set; }

        public int Cobertura { get; set; }

        public List<Dron> Drones { get; set; }

        public Propietario Propietario { get; set; }

        public Local(string nombre, int cobertura, List<Dron> drones, Propietario propietario)
        {
            this.Nombre = string.IsNullOrEmpty(nombre) ? "Nuevo Local" : nombre;
            this.Cobertura = cobertura <= 0 ? 10 : cobertura;
            this.Drones = drones ?? throw new ArgumentNullException(nameof(drones));
            this.Propietario = propietario ?? throw new ArgumentNullException(nameof(propietario));
        }

        public int DronesConRuta => this.Drones.Where<Dron>((Func<Dron, bool>)(dron => dron.Rutas.Count > 0)).Count<Dron>();

        public bool CargarArchivos(string Ruta)
        {
            foreach (FileInfo archivo in FileManager.Instance.LeerDeRuta(Ruta, "In"))
            {
                int dronId = StringManager.Instance.ExtraerNumero(archivo.Name);
                this.Drones.Where<Dron>((Func<Dron, bool>)(dron => dron.Id == dronId)).First<Dron>().Rutas = FileManager.Instance.LeerArchivo(archivo);
            }
            return true;
        }
    }
}
