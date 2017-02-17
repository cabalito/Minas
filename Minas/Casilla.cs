using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minas
{
    class Casilla
    {
        private bool levantada;
        private bool esBomba;
        private int valor;

        public Casilla()
        {
            this.levantada = false;
            this.esBomba = false;
            this.valor = 0;
        }

        public override string ToString()
        {
            if (!levantada) return "X";
            else if (esBomba) return "B";
            else return "" + this.valor;
        }

        public void levanta()
        {
            this.levantada = true;
        }

        public void ponBomba()
        {
            this.esBomba = true;
        }

        public void sumaUno()
        {
            this.valor++;
        }

        internal bool hayBomba()
        {
            return this.esBomba;
        }

        internal int getValor()
        {
            return valor;
        }

        internal bool estaTapada()
        {
            return !levantada;
        }
    }
}
