using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Timers;
using System.Drawing;
using Console = Colorful.Console;
using Figgle;


namespace Gerador_CPF
{
	class Program
	{

		enum Menu { Gerar = 1, CPFSENHA6, CPFSENHA8, Sair }
		static void Main(string[] args)
		{

			Console.WriteLine(FiggleFonts.Doom.Render("CPF Utils"), Color.FromArgb(204, 0, 0));
			Console.WriteLine("Versão 1.2 - https://t.me/tititiorato", Color.FromArgb(204, 0, 0));
			Console.WriteLine("=====================================");

			int contador = 1;
			bool sair = false;

			Random sleep = new Random();
			int delay = sleep.Next(5, 10);


			while (sair == false)
			{
				Console.WriteLine("1 - Gerar CPF\n2 - Gerar CPF:SENHA 6 Digitos\n3 - Gerar CPF:SENHA 8 Digitos\n4 - Sair");
				int opint = int.Parse(Console.ReadLine());
				Menu escolha = (Menu)opint;
				switch (escolha)
				{
					case Menu.Gerar:
						Console.Clear();
						Console.WriteLine("Digite a quantia de CPFS: ");
						int quantia = int.Parse(Console.ReadLine());
						Console.Clear();
						Console.WriteLine("Gerando CPF");
						Console.WriteLine("======================");
						while (contador < quantia)
						{
							Thread[] threads = new Thread[100];
							for (int i = 0; i < threads.Length; i++)
							{
								Thread thread = new Thread(GerandoRapido);
								threads[i] = thread;
							}
							foreach (var item in threads)
							{
								item.Start();
								Thread.Sleep(delay);
							}
						}
						Console.Clear();
						break;
					case Menu.CPFSENHA6:
						Console.Clear();
						Console.WriteLine("Digite a quantia de CPFS: ");
						quantia = int.Parse(Console.ReadLine());
						Console.Clear();
						Console.WriteLine("Gerando CPF_SENHA");
						Console.WriteLine("======================");
						while (contador < quantia)
						{
							Thread[] threads = new Thread[100];
							for (int i = 0; i < threads.Length; i++)
							{
								Thread thread = new Thread(GerandoRapidoCPFSENHA6);
								threads[i] = thread;
							}
							foreach (var item in threads)
							{
								item.Start();
								Thread.Sleep(delay);
							}
						}
						Console.Clear();
						break;
					case Menu.CPFSENHA8:
						Console.Clear();
						Console.WriteLine("Digite a quantia de CPFS: ");
						quantia = int.Parse(Console.ReadLine());
						Console.Clear();
						Console.WriteLine("Gerando CPF_SENHA");
						Console.WriteLine("======================");
						while (contador < quantia)
						{
							Thread[] threads = new Thread[100];
							for (int i = 0; i < threads.Length; i++)
							{
								Thread thread = new Thread(GerandoRapidoCPFSENHA8);
								threads[i] = thread;
							}
							foreach (var item in threads)
							{
								item.Start();
								Thread.Sleep(delay);
							}
						}
						Console.Clear();
						break;
					case Menu.Sair:
						sair = true;
						break;
				}
			}
			void ExibindoCPF(string cpf)
			{
				Console.Write("[", Color.Lavender);
				Console.Write(contador, Color.Red);
				Console.Write("]", Color.Lavender);
				Console.WriteLine(cpf);
			}
			void SalvarCPF(string cpf)
			{
				try
				{
					StreamWriter salvarcpf = File.AppendText("CPFS.txt");
					salvarcpf.WriteLine(cpf);
					salvarcpf.Close();
					contador = contador + 1;
				}
				catch (Exception e)
				{
					Thread.Sleep(delay);
				}
			}
			void SalvarCPFSENHA6(string cpf)
			{
				try
				{
					StreamWriter salvarcpf = File.AppendText("CPFS_SENHA_6.txt");
					salvarcpf.WriteLine(cpf);
					salvarcpf.Close();
					contador = contador + 1;
				}
				catch (Exception e)
				{
					Thread.Sleep(delay);
				}
			}
			
			void SalvarCPFSENHA8(string cpf)
			{
				try
				{
					StreamWriter salvarcpf = File.AppendText("CPFS_SENHA_8.txt");
					salvarcpf.WriteLine(cpf);
					salvarcpf.Close();
					contador = contador + 1;
				}
				catch (Exception e)
				{
					Thread.Sleep(delay);
				}
			}

			void GerandoRapido()
			{
				string cpf = Utils.GerarCPF();
				ExibindoCPF(cpf);
				SalvarCPF(cpf);
			}

			void GerandoRapidoCPFSENHA6()
			{
				string cpf = Utils.GerarCPF();
				string senha = cpf.Substring(0, 6);
				cpf += ":" + senha;
				ExibindoCPF(cpf);
				SalvarCPFSENHA6(cpf);
			}

			void GerandoRapidoCPFSENHA8()
			{
				string cpf = Utils.GerarCPF();
				string senha = cpf.Substring(0, 8);
				cpf += ":" + senha;
				ExibindoCPF(cpf);
				SalvarCPFSENHA8(cpf);
			}
		}
	}
}
