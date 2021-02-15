using System;
using System.Reflection;
using ED2Util.Config;
using ED2DataStructures.Trees;

namespace ED2DataStructures.Factory
{
	/// <summary>
	/// Classe para criar uma �rvore.
	/// </summary>
	public class AbstractTreeFactory
	{
		/// <summary>
		/// Vari�vel privada para instancia �nica de AbstractTreeFactory
		/// </summary>
		private static AbstractTreeFactory instance;

		/// <summary>
		/// Construtor padr�o. Privado para garantir �nica inst�ncia.
		/// </summary>
		private AbstractTreeFactory()
		{
		}

		/// <summary>
		/// Retorna a �nica instancia do manipulador.
		/// </summary>
		/// <returns>Inst�ncia do manipulador.</returns>
		public static AbstractTreeFactory getInstance()
		{
			// Verifica se inst�ncia � nula
			if(instance == null)
				// Caso seja nula, ela � criada.
				instance = new AbstractTreeFactory();
			// Retorna a inst�ncia.
			return instance;
		}

		/// <summary>
		/// M�todo para criar por reflex�o a �rvore
		/// </summary>
		/// <param name="treeName">�rvore a ser criada</param>
		/// <returns>Nova �rvore</returns>
		public AbstractTree createObject(StructureType.Trees treeName)
		{
			// Vari�vel de retorno.
			AbstractTree tree;
			try
			{
				// Obtem o tipo da classe a ser criada.
				System.Type treeType = System.Type.GetType(ClassMap.getClass(treeName),  true);
				/// cria a inst�ncia da classe.
				tree = (AbstractTree) System.Activator.CreateInstance(treeType);
			}
			catch(TypeLoadException e)
			{
				throw new InvalidOperationException("Tipo n�o pode ser criado.", e);
			}
			return tree;
		}

	}
}
