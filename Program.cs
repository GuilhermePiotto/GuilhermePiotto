using System;

namespace Guilherme.Jogos
{
    class Program
    {
        static JogoRepositorio repositorio = new JogoRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarJogos();
						break;
					case "2":
						InserirJogo();
						break;
					case "3":
						AtualizarJogo();
						break;
					case "4":
						ExcluirJogo();
						break;
					case "5":
						VisualizarJogo();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirJogo()
		{
			Console.Write("Digite o id do jogo: ");
			int indiceJogo = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceJogo);
		}

        private static void VisualizarJogo()
		{
			Console.Write("Digite o id do jogo: ");
			int indiceJogo = int.Parse(Console.ReadLine());

			var jogo = repositorio.RetornaPorId(indiceJogo);

			Console.WriteLine(jogo);
		}

        private static void AtualizarJogo()
		{
			Console.Write("Digite o id do jogo: ");
			int indiceJogo = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do jogo: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de lançamento: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do jogo: ");
			string entradaDescricao = Console.ReadLine();

			Jogo atualizaJogo = new Serie(id: indiceJogo,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceJogo, atualizaJogo);
		}
        private static void ListarJogo()
		{
			Console.WriteLine("Listar jogo");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum jogo cadastrado.");
				return;
			}

			foreach (var jogo in lista)
			{
                var excluido = jogo.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", jogo.retornaId(), jogo.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirJogo()
		{
			Console.WriteLine("Inserir novo jogo");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do jogo: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de lançamento: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do jogo: ");
			string entradaDescricao = Console.ReadLine();

			Jogo novoJogo = new Jogo(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novoJogo);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Jogos a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar jogos");
			Console.WriteLine("2- Inserir novo jogo");
			Console.WriteLine("3- Atualizar jogo");
			Console.WriteLine("4- Excluir jogo");
			Console.WriteLine("5- Visualizar jogo");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
