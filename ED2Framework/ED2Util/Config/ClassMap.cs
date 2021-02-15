using System;

namespace ED2Util.Config
{
	/// <summary>
	/// Classe que mapeia as estruturas de dados.
	/// </summary>
	public class ClassMap
	{
		/// <summary>
		/// Variável privada que mapeia a árvore AVL.
		/// </summary>
		private static string avl = "ED2DataStructures.Trees.Binary.Implementation.AVL";
		/// <summary>
		/// Variável privada que mapeia a árvore B.
		/// </summary>
		private static string b = "ED2DataStructures.Trees.Multiway.Implementation.B";
		/// <summary>
		/// Variável privada que mapeia a árvore Binaria.
		/// </summary>
		private static string binary = "ED2DataStructures.Trees.Binary.Implementation.Binary";
		/// <summary>
		/// Variável privada que mapeia a árvore Splay.
		/// </summary>
		private static string splay = "ED2DataStructures.Trees.Binary.Implementation.Splay";

		/// <summary>
		/// Propriedade para obter a classe da árvore AVL.
		/// </summary>
		public static string AVL
		{
			get
			{
				return avl;
			}
		}
		/// <summary>
		/// Propriedade para obter a classe da árvore B.
		/// </summary>
		public static string B
		{
			get
			{
				return b;
			}
		}
		/// <summary>
		/// Propriedade para obter a classe da árvore Binaria.
		/// </summary>
		public static string BINARY
		{
			get
			{
				return binary;
			}
		}
		/// <summary>
		/// Propriedade para obter a classe da árvore Splay.
		/// </summary>
		public static string SPLAY
		{
			get
			{
				return splay;
			}
		}

		/// <summary>
		/// Método para obter o mapeamento de uma classe, passando o nome da árvore.
		/// </summary>
		/// <param name="treeName">Nome da árvore</param>
		/// <returns>mapa da classe</returns>
		public static string getClass(StructureType.Trees treeName)
		{
			// Verifica o qual é o nome da árvore. 
			switch(treeName)
			{
				// Caso seja a AVL.
				case StructureType.Trees.AVL : return avl;
				// Caso seja a B.
				case StructureType.Trees.B : return b;
				// Caso seja a Bnaria.
				case StructureType.Trees.Binary : return binary;
				// Caso seja a Splay.
				case StructureType.Trees.Splay : return splay;
			}
			// Retorno padrão.
			return ClassMap.BINARY;
		}
	}
}
