using System;
using System.Collections;
using ED2DataStructures.Trees;

namespace ED2DataStructures.Trees
{
	/// <summary>
	/// Classe abstrata que representa uma �rvore qualquer.
	/// </summary>
	public abstract class AbstractTree
	{
		/// <summary>
		/// M�todo para inserir uma chave na estrutura
		/// </summary>
		/// <param name="key">Chave do n�</param>
		/// <returns>Flag para sucesso/erro da opera��o</returns>
		public abstract bool insertKey(Key key);
		/// <summary>
		/// M�todo para deletar uma chave na estrutura
		/// </summary>
		/// <param name="key">Chave do n�</param>
		/// <returns>Flag para sucesso/erro da opera��o</returns>
		public abstract bool deleteKey(Key key);
		/// <summary>
		/// M�todo para buscar uma chave na estrutura
		/// </summary>
		/// <param name="key">Chave a ser buscada</param>
		/// <returns>�rvore contendo um n� com a chave, em caso de sucesso na busca,
		///  ou um n� com chave nula (n� onde a chave deveria estar)</returns>
		public abstract AbstractTree searchKey(Key key);
		/// <summary>
		/// M�todo para outras inicializa��es
		/// </summary>
		public virtual void init(int ordem){}
	}
}
