using System;
using System.Collections;
using ED2DataStructures.Trees;

namespace ED2DataStructures.Trees.Multiway
{
	/// <summary>
	/// Classe abstrata que representa uma árvore multiways.
	/// </summary>
	public abstract class AbstractMultiwayTree : AbstractTree
	{
		/// <summary>
		/// Variável protegida que armazena a ordem.
		/// </summary>
		protected int ordem;
		/// <summary>
		/// Variável que armazena todas as chaves dos nós
		/// </summary>
		protected ArrayList key;
		/// <summary>
		/// Variável que armazena todos os ponteiros do nó
		/// </summary>
		protected ArrayList pointer;
		
		/// <summary>
		/// Propriedade para obter ou alterar as sub-árvores.
		/// </summary>
		public ArrayList POINTERS
		{
			get
			{
				return pointer;
			}
			set
			{
				pointer = value;
			}
		}
		/// <summary>
		/// Propriedade para obter ou alterar as chaves da árvore.
		/// </summary>
		public ArrayList KEYS
		{
			get
			{
				return key;
			}
			set
			{
				key = value;
			}
		}
		/// <summary>
		/// Propriedade para obter ou alterar ordem da árvore.
		/// </summary>
		public int ORDEM
		{
			get
			{
				return ordem;
			}
			set
			{
				ordem = value;
			}
		}
		/// <summary>
		/// Propriedade para obter a quantida máxima de nós da árvore.
		/// </summary>
		public int MAXKEY
		{
			get
			{
				return ordem*2;
			}
		}
		/// <summary>
		/// Propriedade para obter quantida mínima de nós da árvore.
		/// </summary>
		public int MINKEY
		{
			get
			{
				return ordem;
			}
		}
		/// <summary>
		/// Propriedade para obter a quantida máxima de ponteiros da árvore.
		/// </summary>
		public int MAXPOINTER
		{
			get
			{
				return ordem*2+1;
			}
		}
		public abstract int NIVEL
		{
			get;
			set;
		}
		
	}
}
