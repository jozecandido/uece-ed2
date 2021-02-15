using System;

namespace ED2Util.Config
{
	/// <summary>
	/// Classe que tem as definições das árvores
	/// </summary>
	public class StructureType 
	{
		/// <summary>
		/// Enumerator com os nomes das árvores.
		/// </summary>
		public enum Trees {AVL, Binary, Splay, B};

		/// <summary>
		/// Propriedade para obter o tipo da AVL
		/// </summary>
		public static Trees AVL
		{
			get
			{
				return Trees.AVL;
			}
		}
		/// <summary>
		/// Propriedade para obter o tipo da Binaria.
		/// </summary>
		public static Trees BINARY
		{
			get
			{
				return Trees.Binary;
			}
		}
		/// <summary>
		/// Propriedade para obter o tipo da Splay
		/// </summary>
		public static Trees SPLAY
		{
			get
			{
				return Trees.Splay;
			}
		}
		/// <summary>
		/// Propriedade para obter o tipo da B
		/// </summary>
		public static Trees B
		{
			get
			{
				return Trees.B;
			}
		}
	}
}
