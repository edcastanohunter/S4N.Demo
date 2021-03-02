using S4N.Demo.Domain;
using System;

namespace S4N.Demo.ConsoleApp
{
    public class Mundo
    {
        public Local Local { get; set; }
        public Mundo(Local local) => this.Local = local ?? throw new ArgumentNullException(nameof(local));
    }
}
