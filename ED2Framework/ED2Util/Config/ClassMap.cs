using System;

namespace ED2Util.Config
{
	/// <summary>
	/// Classe que mapeia as estruturas de dados.
	/// </summary>
	public class ClassMap
	{
		/// <summary>
		/// Vari�vel privada que mapeia a �rvore AVL.
		/// </summary>
		private static string avl = "ED2DataStructures.Trees.Binary.Implementation.AVL";
		/// <summary>
		/// Vari�vel privada que mapeia a �rvore B.
		/// </summary>
		private static string b = "ED2DataStructures.Trees.Multiway.Implementation.B";
		/// <summary>
		/// Vari�vel privada que mapeia a �rvore Binaria.
		/// </summary>
		private static string binary = "ED2DataStructures.Trees.Binary.Implementation.Binary";
		/// <summary>
		/// Vari�vel privada que mapeia a �rvore Splay.
		/// </summary>
		private static string splay = "ED2DataStructures.Trees.Binary.Implementation.Splay";

		/// <summary>
		/// Propriedade para obter a classe da �rvore AVL.
		/// </summary>
		public static string AVL
		{
			get
			{
				return avl;
			}
		}
		/// <summary>
		/// Propriedade para obter a classe da �rvore B.
		/// </summary>
		public static string B
		{
			get
			{
				return b;
			}
		}
		/// <summary>
		/// Propriedade para obter a classe da �rvore Binaria.
		/// </summary>
		public static string BINARY
		{
			get
			{
				return binary;
			}
		}
		/// <summary>
		/// Propriedade para obter a classe da �rvore Splay.
		/// </summary>
		public static string SPLAY
		{
			get
			{
				return splay;
			}
		}

		/// <summary>
		/// M�todo para obter o mapeamento de uma classe, passando o nome da �rvore.
		/// </summary>
		/// <param name="treeName">Nome da �rvore</param>
		/// <returns>mapa da classe</returns>
		public static string getClass(StructureType.Trees treeName)
		{
			// Verifica o qual � o nome da �rvore. 
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
			// Retorno padr�o.
			return ClassMap.BINARY;
		}
	}
}
