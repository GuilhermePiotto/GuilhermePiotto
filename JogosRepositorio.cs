using System;
using System.Collections.Generic;
using Guilherme.Jogos.Interfaces;

namespace Guilherme.Jogos
{
	public class JogosRepositorio : IRepositorio<Jogos>
	{
        private List<Jogos> listaJogo = new List<Jogos>();
		public void Atualiza(int id, Jogos objeto)
		{
			listaJogo[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaJogo[id].Excluir();
		}

		public void Insere(Jogos objeto)
		{
			listaJogo.Add(objeto);
		}

		public List<Jogos> Lista()
		{
			return listaJogo;
		}

		public int ProximoId()
		{
			return listaJogo.Count;
		}

		public Jogos RetornaPorId(int id)
		{
			return listaJogo[id];
		}
	}
}