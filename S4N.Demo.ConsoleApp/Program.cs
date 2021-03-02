using S4N.Demo.Domain;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace S4N.Demo.ConsoleApp
{
    class Program
    {
        private static Mundo Mundo;
        private static readonly string Ruta = "Archivos/";

        private static void Main(string[] args)
        {
            //Console.WriteLine(Regex.IsMatch("In04.txt", "In[0-9][0-9].txt"));
            InicializandoMundo();
            CargarArchivos();
            ImprimirMundo();
            HacerEntregas();
            ImprimirMundo();
        }

        private static void InicializandoMundo()
        {
            int num = 20;
            int cobertura = 10;
            Propietario propietario1 = new Propietario();
            propietario1.Id = 1;
            propietario1.Nombre = "Pepe Perez";
            propietario1.CreatedAt = DateTime.UtcNow;
            Propietario propietario2 = propietario1;
            List<Dron> drones = new List<Dron>();
            for (int index = 1; index <= num; ++index)
            {
                List<Dron> dronList = drones;
                Dron dron = new Dron();
                dron.Id = index;
                dron.Nombre = "Dron" + index.ToString("00");
                dron.CargaActual = 0;
                dron.CoordenadaActual = new Coordenada();
                dron.CreatedAt = DateTime.UtcNow;
                dronList.Add(dron);
            }
            Program.Mundo = new Mundo(new Local("Su Corrientazo A Domicilio", cobertura, drones, propietario2));
        }

        private static void CargarArchivos() => Mundo.Local.CargarArchivos(Program.Ruta);

        private static void HacerEntregas()
        {
            var dronesConRutas = Mundo.Local.GetDronesConCarga();

            foreach (var dron in dronesConRutas)
            {
                dron.RealizarEntregas();
            }
        }
        private static void ImprimirMundo()
        {
            System.Console.WriteLine("-----------------------------");
            Console.WriteLine("Local: " + Mundo.Local.Nombre);
            Console.WriteLine("Propietario: " + Mundo.Local.Propietario.Nombre);
            Console.WriteLine(string.Format("Número de Drone: {0}", Mundo.Local.Drones.Count));
            Console.WriteLine(string.Format("Número de Drones con Rutas: {0}", Mundo.Local.DronesConRuta));
        }
    }
}
