using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;
using Figgle;

namespace CPF_UTILS
{
    class Program
    {
        enum Menu { GerarCPF = 1, GerarCPFSenha6, GerarCPFSenha8, Sair }
        static void Main(string[] args)
        {
            bool sair = false;
            while(sair == false)
            {
                int quantidade = 0;
                Console.WriteLine(FiggleFonts.Doom.Render("CPF Utils"), Color.FromArgb(204, 0, 0));
                Console.WriteLine("Versão 1.3 - https://t.me/tititiorato", Color.FromArgb(204, 0, 0));
                Console.WriteLine("=====================================");
                Console.WriteLine("1 - Gerar CPF\n2 - Gerar CPF:Senha 6 digitos\n3 - Gerar CPF:Senha 8 digitos\n4 - Sair");
                int opInt = int.Parse(Console.ReadLine());
                Menu escolha = (Menu)opInt;

                switch (escolha)
                {
                    case Menu.GerarCPF:
                        quantidade = texto();
                        Utils.GerarCPF(quantidade);
                        break;
                    case Menu.GerarCPFSenha6:
                        quantidade = texto();
                        Utils.GerarCPFSENHA6(quantidade);
                        break;
                    case Menu.GerarCPFSenha8:
                        quantidade = texto();
                        Utils.GerarCPFSENHA8(quantidade);
                        break;
                    case Menu.Sair:
                        sair = true;
                        break;
                }

                 int texto()
                {
                    Console.WriteLine("Digite a Quantia de CPF que deseja gerar: ");
                    int quantia = int.Parse(Console.ReadLine());
                    return quantia;
                }
            }
        }
    }
}
