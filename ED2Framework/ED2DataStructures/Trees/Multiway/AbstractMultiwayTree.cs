using System;
using System.Collections;
using ED2DataStructures.Trees;

namespace ED2DataStructures.Trees.Multiway
{
	/// <summary>
	/// Classe abstrata que representa uma �rvore multiways.
	/// </summary>
	public abstract class AbstractMultiwayTree : AbstractTree
	{
		/// <summary>
		/// Vari�vel protegida que armazena a ordem.
		/// </summary>
		protected int ordem;
		/// <summary>
		/// Vari�vel que armazena todas as chaves dos n�s
		/// </summary>
		protected ArrayList key;
		/// <summary>
		/// Vari�vel que armazena todos os ponteiros do n�
		/// </summary>
		protected ArrayList pointer;
		
		/// <summary>
		/// Propriedade para obter ou alterar as sub-�rvores.
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
		/// Propriedade para obter ou alterar as chaves da �rvore.
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
		/// Propriedade para obter ou alterar ordem da �rvore.
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
		/// Propriedade para obter a quantida m�xima de n�s da �rvore.
		/// </summary>
		public int MAXKEY
		{
			get
			{
				return ordem*2;
			}
		}
		/// <summary>
		/// Propriedade para obter quantida m�nima de n�s da �rvore.
		/// </summary>
		public int MINKEY
		{
			get
			{
				return ordem;
			}
		}
		/// <summary>
		/// Propriedade para obter a quantida m�xima de ponteiros da �rvore.
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
