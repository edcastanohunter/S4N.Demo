using S4N.Demo.Domain.Enums;
using S4N.Demo.SharedKernel;

namespace S4N.Demo.Domain
{
    public class Coordenada : BaseEntity
    {
        public int PosicionX { get; set; }

        public int PosicionY { get; set; }

        public Orientacion Orientacion { get; set; }

        public Coordenada()
        {
            this.PosicionX = 0;
            this.PosicionY = 0;
            this.Orientacion = Orientacion.Norte;
        }

        public Coordenada(int posicionX, int posicionY, Orientacion orientacion)
        {
            this.PosicionX = posicionX;
            this.PosicionY = posicionY;
            this.Orientacion = orientacion;
        }
    }
}
