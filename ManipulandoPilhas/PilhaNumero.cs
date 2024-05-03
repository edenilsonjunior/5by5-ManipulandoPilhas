using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace ManipulandoPilhas
{
    internal class PilhaNumero
    {
        Numero? topo;
        int tamanho;
        int qntPares;
        int qntImpares;

        public PilhaNumero()
        {
            topo = null;
            tamanho = 0;
            qntPares = 0;
            qntImpares = 0;
        }

        public void Push(Numero aux)
        {
            if (IsEmpty())
            {
                topo = aux;
            }
            else
            {
                aux.SetAnterior(topo);
                topo = aux;
            }

            if (aux.GetNumero() % 2 == 0)
                qntPares++;
            else
                qntImpares++;

            tamanho++;
        }

        public Numero? Pop()
        {
            Numero? removido = null;

            if (!IsEmpty())
            {
                removido = topo;
                topo = topo.GetAnterior();

                if (removido.GetNumero() % 2 == 0)
                    qntPares--;
                else
                    qntImpares--;

                tamanho--;
            }
            removido.SetAnterior(null);
            return removido;
        }

        public int[] GetPares()
        {
            int[] numerosPares = new int[qntPares];
            int indice = 0;
            Numero aux = topo;

            while (aux != null)
            {
                if (aux.GetNumero() % 2 == 0)
                {
                    numerosPares[indice++] = aux.GetNumero();
                }
                aux = aux.GetAnterior();
            }

            return numerosPares;
        }

        public int[] GetImpares()
        {
            int[] numerosImpares = new int[qntImpares];
            int indice = 0;
            Numero aux = topo;

            while (aux != null)
            {
                if (aux.GetNumero() % 2 != 0)
                {
                    numerosImpares[indice++] = aux.GetNumero();
                }
                aux = aux.GetAnterior();
            }

            return numerosImpares;
        }

        public float? GetMedia()
        {
            if (tamanho == 0)
            {
                return null;
            }

            float media;
            int sum = 0;
            int total = 0;

            Numero aux = topo;
            while (aux != null)
            {
                sum += aux.GetNumero();
                total++;
                aux = aux.GetAnterior();
            }

            media = sum / total;

            return media;
        }

        public int GetTamanho()
        {
            return tamanho;
        }

        public int GetQntPares()
        {
            return qntPares;
        }

        public int GetQntImpares()
        {
            return qntImpares;
        }

        public int? GetMenorNumero()
        {

            if (IsEmpty())
                return null;

            Numero aux = topo;
            int menor = topo.GetNumero();

            while (aux != null)
            {
                if (aux.GetNumero() < menor)
                    menor = aux.GetNumero();

                aux = aux.GetAnterior();
            }
            return menor;
        }

        public int? GetMaiorNumero()
        {

            if (IsEmpty())
                return null;

            Numero aux = topo;
            int maior = topo.GetNumero();

            while (aux != null)
            {
                if (aux.GetNumero() > maior)
                    maior = aux.GetNumero();

                aux = aux.GetAnterior();
            }
            return maior;
        }

        public bool IsEmpty()
        {
            return topo == null;
        }

        public void Print()
        {

            if (IsEmpty())
            {
                Console.WriteLine("-->Pilha vazia!");
            }
            else
            {
                Numero aux = topo;

                while (aux != null)
                {
                    Console.WriteLine($"--> {aux}");
                    aux = aux.GetAnterior();
                }
            }
        }

    }


}
