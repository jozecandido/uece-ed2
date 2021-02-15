using System;
using System.Collections;
using ED2DataStructures.Trees;

namespace ED2DataStructures.Trees
{
	/// <summary>
	/// Classe abstrata que representa uma árvore qualquer.
	/// </summary>
	public abstract class AbstractTree
	{
		/// <summary>
		/// Método para inserir uma chave na estrutura
		/// </summary>
		/// <param name="key">Chave do nó</param>
		/// <returns>Flag para sucesso/erro da operação</returns>
		public abstract bool insertKey(Key key);
		/// <summary>
		/// Método para deletar uma chave na estrutura
		/// </summary>
		/// <param name="key">Chave do nó</param>
		/// <returns>Flag para sucesso/erro da operação</returns>
		public abstract bool deleteKey(Key key);
		/// <summary>
		/// Método para buscar uma chave na estrutura
		/// </summary>
		/// <param name="key">Chave a ser buscada</param>
		/// <returns>Árvore contendo um nó com a chave, em caso de sucesso na busca,
		///  ou um nó com chave nula (nó onde a chave deveria estar)</returns>
		public abstract AbstractTree searchKey(Key key);
		/// <summary>
		/// Método para outras inicializações
		/// </summary>
		public virtual void init(int ordem){}
	}
}
