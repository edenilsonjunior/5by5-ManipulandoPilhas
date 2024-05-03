/*
1- Dado duas pilhas (p1 e p2), que armazenam numeros inteiros, faça um programa que contenha as seguintes funcoes:
	A) Uma funcao para testar se as duas pilhas sao iguais em tamanho, caso nao forem, informe qual é a maior
	B) Uma funcao que forneca o maior ou menor e a media aritmetica dos elementos da pilha (separadamente, fazer as duas pilhas mas separadas)
	C) Uma funcao para transferir os elementos da pilha que o usuario informar, para uma terceira pilha, exemplo, (p1 para p3)
	D) Uma funcao para retornar a quantidade de elementos impares das pilhas (quantidade E mostrar os numeros)
	E) Uma funcao para retornar a quantidade de elementos pares das pilhas (quantidade E mostrar os numeros)

    Para a tratativa se caso o usuario nao digitar um numero, estarei usando o método TryParse
        try parse retorna um boolean se foi possivel converter o texto em string
        parametros:
         - string texto: a string que sera convertida em numero
         - out result: parametro que recebe o resultado da conversao
         * a palavra-chave out permite passar um argumento por referencia ao inves de passar seu valor *
*/

namespace ManipulandoPilhas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PilhaNumero p1 = new PilhaNumero();
            PilhaNumero p2 = new PilhaNumero();
            PilhaNumero p3 = new PilhaNumero();

            while (true)
            {
                int opcao = Menu();

                switch (opcao)
                {
                    case 1:
                        p1.Push(LerNumero());
                        break;
                    case 2:
                        p2.Push(LerNumero());
                        break;
                    case 3:
                        VerificarIgualdades(p1, p2);
                        break;
                    case 4:
                        GetMaiorMenorMedia(p1, "pilha 1");
                        GetMaiorMenorMedia(p2, "pilha 2");
                        break;
                    case 5:
                        TrocarPilhas(p1, p2, p3);
                        break;
                    case 6:
                        ExibirParesPilha(p1, "Pilha 1");
                        ExibirParesPilha(p2, "Pilha 2");
                        break;
                    case 7:
                        ExibirImparesPilha(p1, "Pilha 1");
                        ExibirImparesPilha(p2, "Pilha 2");
                        break;
                    case 8:
                        Console.WriteLine("Pilha 1");
                        p1.Print();

                        Console.WriteLine("Pilha 2");
                        p2.Print();

                        Console.WriteLine("Pilha 3");
                        p3.Print();
                        break;
                    case 0: // EXIT
                        Console.WriteLine("Saindo...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opcao inváida!");
                        break;
                }

                Console.WriteLine("===================================");
                Console.Write("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
            }

        }

        static int Menu()
        {
            Console.Clear();
            Console.WriteLine("======Pilha de numeros======");

            Console.WriteLine("Escolha uma opcao");
            Console.WriteLine("1- Adicionar um numero na pilha 1");
            Console.WriteLine("2- Adicionar um numero na pilha 2");
            Console.WriteLine("3- Verificar se as pilhas sao iguais em tamanho");
            Console.WriteLine("4- Maior, menor e media de cada pilha");
            Console.WriteLine("5- Transferir numeros de uma pilha para uma terceira");
            Console.WriteLine("6- Numeros Pares de cada pilha");
            Console.WriteLine("7- Numeros Impares de cada pilha");
            Console.WriteLine("8- Exibir todas as pilhas");
            Console.WriteLine("0- Sair");
            Console.Write("R: ");

            bool conversao = int.TryParse(Console.ReadLine(), out int option);

            if (!conversao)
            {
                Console.WriteLine("Voce deve digitar um numero!");
                Console.Write("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                return Menu();
            }

            return option;
        }

        static void VerificarIgualdades(PilhaNumero p1, PilhaNumero p2)
        {
            int sizeP1 = p1.GetTamanho();
            int sizeP2 = p2.GetTamanho();

            if (sizeP1 == sizeP2)
            {
                Console.WriteLine("As pilhas possuem o mesmo tamanho!");
            }
            else if (sizeP1 > sizeP2)
            {
                Console.WriteLine("A pilha p1 é maior do que a pilha p2!");
            }
            else
            {
                Console.WriteLine("A pilha p2 é maior do que a pilha p1!");
            }
        }

        static Numero LerNumero()
        {
            Console.WriteLine("======Leitura de numero======");
            Console.WriteLine("Digite o numero que deseja inserir na pilha:");
            Console.Write("R: ");

            // Se foi possivel converter, o numero resultante sera armazenado em "opcao"
            if (int.TryParse(Console.ReadLine(), out int opcao))
            {
                return new Numero(opcao);
            }
            else
            {
                Console.WriteLine("É preciso digitar um numero!");
                return LerNumero();
            }
        }

        static void GetMaiorMenorMedia(PilhaNumero pilha, string nomePilha)
        {
            Console.WriteLine("=================");
            Console.WriteLine($"-->Pilha escolhida: {nomePilha}");

            if (!pilha.IsEmpty())
            {
                Console.WriteLine($"-->Menor valor: {pilha.GetMenorNumero()}");
                Console.WriteLine($"-->Maior valor: {pilha.GetMaiorNumero()}");
                Console.WriteLine($"-->Media: {pilha.GetMedia()}");
            }
            else
            {
                Console.WriteLine("-->A pilha está vazia!");
            }
        }

        static void TrocarPilhas(PilhaNumero p1, PilhaNumero p2, PilhaNumero p3)
        {

            Console.WriteLine("Digite 1 ou 2 para escolher a respectiva pilha");
            Console.Write("R: ");

            bool resultadoTry = int.TryParse(Console.ReadLine(), out int opcao);

            if (!resultadoTry)
            {
                Console.WriteLine("Numero inválido!");
                Console.Write("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return;
            }

            if (opcao == 1)
            {
                if (p1.IsEmpty())
                {
                    Console.WriteLine("A pilha está vazia!, nao foi possivel transferir");
                    Console.Write("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                while (!p1.IsEmpty())
                {
                    Numero aux = p1.Pop();
                    p3.Push(aux);
                }
                Console.WriteLine("Estado da pilha 3:");
                p3.Print();
            }

            else if (opcao == 2)
            {
                if (p2.IsEmpty())
                {
                    Console.WriteLine("A pilha está vazia!, nao foi possivel transferir");
                    Console.Write("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                while (!p2.IsEmpty())
                {
                    Numero aux = p2.Pop();
                    p3.Push(aux);
                }

                Console.WriteLine("Estado da pilha 3:");
                p3.Print();
            }
        }

        static void ExibirParesPilha(PilhaNumero pilha, string nomePilha)
        {
            Console.WriteLine("=================");
            Console.WriteLine($"-->Pilha escolhida: {nomePilha}");

            if (!pilha.IsEmpty())
            {
                int qntPares = pilha.GetQntPares();
                int[] pares = pilha.GetPares();

                Console.WriteLine($"-->Quantidade de pares: {qntPares}");
                Console.Write($"-->");
                for (int i = 0; i < qntPares; i++)
                {
                    Console.Write($"{pares[i]} ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("-->A pilha está vazia!");
            }
        }

        static void ExibirImparesPilha(PilhaNumero pilha, string nomePilha)
        {
            Console.WriteLine("=================");
            Console.WriteLine($"-->Pilha escolhida: {nomePilha}");

            if (!pilha.IsEmpty())
            {
                int qntImpares = pilha.GetQntImpares();
                int[] impares = pilha.GetImpares();

                Console.WriteLine($"-->Quantidade de impares: {qntImpares}");
                Console.Write($"-->");
                for (int i = 0; i < qntImpares; i++)
                {
                    Console.Write($"{impares[i]} ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("-->A pilha está vazia!");
            }
        }
    }
}
