using System;
using System.Reflection;
using ED2Util.Config;
using ED2DataStructures.Trees;

namespace ED2DataStructures.Factory
{
	/// <summary>
	/// Classe para criar uma árvore.
	/// </summary>
	public class AbstractTreeFactory
	{
		/// <summary>
		/// Variável privada para instancia única de AbstractTreeFactory
		/// </summary>
		private static AbstractTreeFactory instance;

		/// <summary>
		/// Construtor padrão. Privado para garantir única instância.
		/// </summary>
		private AbstractTreeFactory()
		{
		}

		/// <summary>
		/// Retorna a única instancia do manipulador.
		/// </summary>
		/// <returns>Instância do manipulador.</returns>
		public static AbstractTreeFactory getInstance()
		{
			// Verifica se instância é nula
			if(instance == null)
				// Caso seja nula, ela é criada.
				instance = new AbstractTreeFactory();
			// Retorna a instância.
			return instance;
		}

		/// <summary>
		/// Método para criar por reflexão a árvore
		/// </summary>
		/// <param name="treeName">Árvore a ser criada</param>
		/// <returns>Nova árvore</returns>
		public AbstractTree createObject(StructureType.Trees treeName)
		{
			// Variável de retorno.
			AbstractTree tree;
			try
			{
				// Obtem o tipo da classe a ser criada.
				System.Type treeType = System.Type.GetType(ClassMap.getClass(treeName),  true);
				/// cria a instância da classe.
				tree = (AbstractTree) System.Activator.CreateInstance(treeType);
			}
			catch(TypeLoadException e)
			{
				throw new InvalidOperationException("Tipo não pode ser criado.", e);
			}
			return tree;
		}

	}
}
