using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jint;
using System.IO;
using System.Threading;
using Figgle;
using Console = Colorful.Console;
using System.Drawing;

namespace CPF_UTILS
{
    class Utils
    {
        public static void GerarCPF(int quantia)
        {
            var cpfFunction = File.ReadAllText("cpf.js");
            var javascript = new Engine();
            javascript.Execute(cpfFunction);

            int i = 1;

            while (i <= quantia){
                string cpf = javascript.Invoke("gerarCPF").ToString();
                
                try
                {
                    StreamWriter salvarcpf = File.AppendText("CPF.txt");
                    salvarcpf.WriteLine(cpf);
                    Console.Write("[", Color.Lavender);
                    Console.Write(i, Color.Red);
                    Console.Write("]", Color.Lavender);
                    Console.WriteLine(cpf);
                    salvarcpf.Close();
                    i = i + 1;
                }
                catch(Exception e)
                {
                    Thread.Sleep(10);
                }
                
                
                
            }
            Console.WriteLine("Aperte ENTER para retornar ao menu");
            Console.ReadLine();
            Console.Clear();
        }

        public static void GerarCPFSENHA6(int quantia)
        {
            var cpfFunction = File.ReadAllText("cpf.js");
            var javascript = new Engine();
            javascript.Execute(cpfFunction);

            int i = 1;

            while (i <= quantia)
            {
                string cpf = javascript.Invoke("gerarCPF").ToString();
                

                try
                {
                    StreamWriter salvarcpf = File.AppendText("CPF_SENHA6.txt");
                    string senha = cpf.Substring(0, 6);
                    string cpfsenha6 = cpf += ":" + senha;
                    salvarcpf.WriteLine(cpfsenha6);
                    Console.Write("[", Color.Lavender);
                    Console.Write(i, Color.Red);
                    Console.Write("]", Color.Lavender);
                    Console.WriteLine(cpfsenha6);
                    salvarcpf.Close();
                    i = i + 1;
                }
                catch (Exception e)
                {
                    Thread.Sleep(10);
                }


               
            }
            Console.WriteLine("Aperte ENTER para retornar ao menu");
            Console.ReadLine();
            Console.Clear();
        }

        public static void GerarCPFSENHA8(int quantia)
        {
            var cpfFunction = File.ReadAllText("cpf.js");
            var javascript = new Engine();
            javascript.Execute(cpfFunction);

            int i = 1;

            while (i <= quantia)
            {
                string cpf = javascript.Invoke("gerarCPF").ToString();


                try
                {
                    StreamWriter salvarcpf = File.AppendText("CPF_SENHA8.txt");
                    string senha = cpf.Substring(0, 8);
                    string cpfsenha8 = cpf += ":" + senha;
                    salvarcpf.WriteLine(cpfsenha8);
                    Console.Write("[", Color.Lavender);
                    Console.Write(i, Color.Red);
                    Console.Write("]", Color.Lavender);
                    Console.WriteLine(cpfsenha8);
                    salvarcpf.Close();
                    i = i + 1;
                }
                catch (Exception e)
                {
                    Thread.Sleep(10);
                }



            }
            Console.WriteLine("Aperte ENTER para retornar ao menu");
            Console.ReadLine();
            Console.Clear();
        }

    }
}
