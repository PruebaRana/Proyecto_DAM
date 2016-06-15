using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsSGBD.MisCS
{
    class Prueba : IEquatable<Prueba>
    {
        [Flags]
        public enum TipoBloque
        {
            BLOQUE = 1,
            HILO = 2,
            SENTENCIA = 4
        };

        public TipoBloque Bloque;

        public Prueba(TipoBloque aBloque)
        {
            this.Bloque = aBloque;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Prueba other)
        {
            throw new NotImplementedException();
        }
    }
}
