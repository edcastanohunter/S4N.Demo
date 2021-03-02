using S4N.Demo.Domain.Enums;
using S4N.Demo.SharedKernel;
using S4N.Demo.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4N.Demo.Domain
{
    public class Dron : BaseEntity
    {
        private int _RutaActual = 0;
        public const int MAX_CAPACITY = 3;

        public string Nombre { get; set; }

        public int CargaActual { get; set; }

        public Coordenada CoordenadaActual { get; set; }

        public List<string> Rutas { get; set; } = new List<string>();

        public int RutaActual => _RutaActual;
        public int RutasPendientes => Rutas.Count - RutaActual;

        public void RealizarEntregas()
        {
            var len = Rutas.Count;
            while (RutaActual < len)
            {
                HacerRuta();
            }
        }

        public void HacerRuta()
        {
            //bool valida = false;

            var ruta = Rutas[RutaActual].ToCharArray();
            var len = ruta.Length;

            for (int i = 0; i < len; i++)
            {
                var movStr = ruta[i];
                if (Enum.IsDefined(typeof(Movimiento), (int)movStr))
                {
                    var movimiento = (Movimiento)movStr;

                    switch (movimiento)
                    {
                        case Movimiento.Adelante:
                            MoverAdelante();
                            break;
                        case Movimiento.Derecha:
                            MoverDerecha();
                            break;
                        case Movimiento.Izquierda:
                            MoverIzquierda();
                            break;
                        default:
                            break;
                    }
                }
            }
            //valida = true;
            _RutaActual++;

            ReportarEntrega();
        }

        private void ReportarEntrega()
        {
            var ruta = $"Archivos/Out{Id.ToString("00")}.txt";
            var reporte = $"({CoordenadaActual.PosicionX},{CoordenadaActual.PosicionY}) dirección ${CoordenadaActual.Orientacion.ToString()}";

            FileManager.Instance.EscribirLineaArchivo(ruta, reporte);
        }

        private void MoverAdelante()
        {
            switch (CoordenadaActual.Orientacion)
            {
                case Orientacion.Occidente:
                    CoordenadaActual.PosicionX += 1;
                    break;
                case Orientacion.Norte:
                    CoordenadaActual.PosicionY += 1;
                    break;
                case Orientacion.Oriente:
                    CoordenadaActual.PosicionX -= 1;
                    break;
                case Orientacion.Sur:
                    CoordenadaActual.PosicionY += 1;
                    break;
                default:
                    break;
            }
        }

        private void MoverIzquierda()
        {
            switch (CoordenadaActual.Orientacion)
            {
                case Orientacion.Occidente:
                    CoordenadaActual.Orientacion = Orientacion.Sur;
                    break;
                case Orientacion.Norte:
                    CoordenadaActual.Orientacion = Orientacion.Occidente;
                    break;
                case Orientacion.Oriente:
                    CoordenadaActual.Orientacion = Orientacion.Norte;
                    break;
                case Orientacion.Sur:
                    CoordenadaActual.Orientacion = Orientacion.Oriente;
                    break;
                default:
                    break;
            }
        }

        private void MoverDerecha()
        {
            switch (CoordenadaActual.Orientacion)
            {
                case Orientacion.Occidente:
                    CoordenadaActual.Orientacion = Orientacion.Norte;
                    break;
                case Orientacion.Norte:
                    CoordenadaActual.Orientacion = Orientacion.Oriente;
                    break;
                case Orientacion.Oriente:
                    CoordenadaActual.Orientacion = Orientacion.Sur;
                    break;
                case Orientacion.Sur:
                    CoordenadaActual.Orientacion = Orientacion.Occidente;
                    break;
                default:
                    break;
            }
        }
    }
}
