using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulandoPilhas
{
    internal class Numero
    {

        int num;
        Numero? anterior;

        public Numero(int num)
        {
            this.num = num;
            anterior = null;
        }

        public void SetAnterior(Numero anterior)
        {
            this.anterior = anterior;
        }

        public Numero? GetAnterior()
        {
            return anterior;
        }

        public int GetNumero()
        {
            return num;
        }

        public override string? ToString()
        {
            return num.ToString();
        }
    }
}
