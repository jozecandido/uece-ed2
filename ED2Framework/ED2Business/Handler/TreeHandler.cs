using System;
using System.Collections;

using ED2Util.Config;
using ED2DataStructures.Factory;
using ED2DataStructures.Trees;

namespace ED2Business.Handler
{
	/// <summary>
	/// Summary description for TreeHandler.
	/// </summary>
	public class TreeHandler
	{
		/// <summary>
		/// Vari�vel privada para instancia �nica de TreeHandler
		/// </summary>
		private static TreeHandler instance;
		/// <summary>
		/// Vari�vel privada para criar as estruturas de dados;
		/// </summary>
		private AbstractTreeFactory factory;
		/// <summary>
		/// ArryaList que armazenar� as estruturas.
		/// </summary>
		private ArrayList trees;
		
		/// <summary>
		/// Construtor padr�o. Privado para garantir �nica inst�ncia.
		/// </summary>
		private TreeHandler()
		{
			// Inicializa factory de estruturas
			factory = AbstractTreeFactory.getInstance();
			// Inicializa array
			trees = new ArrayList();
		}

		/// <summary>
		/// Retorna a �nica instancia do manipulador.
		/// </summary>
		/// <returns>Inst�ncia do manipulador.</returns>
		public static TreeHandler getInstance()
		{
			// Verifica se inst�ncia � nula
			if(instance == null)
				// Caso seja nula, ela � criada.
				instance = new TreeHandler();
			// Retorna a inst�ncia.
			return instance;
		}

		/// <summary>
		/// M�todo para adicioanar uma �rvore ao manipulador.
		/// </summary>
		/// <param name="treeName">Tipo de �rvore a ser adicionada</param>
		public AbstractTree addTree(StructureType.Trees treeName, int ordem)
		{
			// Nova �rvore criada
			AbstractTree newTree = factory.createObject(treeName);
			// Inicializa ordem, caso precise.
			newTree.init(ordem);
			// Flag de inser��o.
			bool inserted = false;
			// Varre array para saber se j� existe
			foreach(AbstractTree tree in trees)
			{
				// Verifica se j� existe uma �rvore deste tipo no array
				if(tree.GetType().FullName.Equals(newTree.GetType().FullName))
				{
					// Caso haja, a antiga refer�ncia � removida.
					trees.Remove(tree);
					//  E a nova inserida.
					trees.Add(newTree);
					inserted = true;
					break;
				}
			}
			// Se n�o foi inserido, adciona.
			if(!inserted)
			{
				// Adiciona nova entidade.
				trees.Add(newTree);
			}
			return newTree;
		}

		/// <summary>
		/// M�todo para remover uma �rvore do manipulador.
		/// </summary>
		/// <param name="treeName">Tipo de �rvore a ser removida</param>
		public void removeTree(StructureType.Trees treeName)
		{
			// Verifica se o array cont�m elementos.
			if(trees.Count>0)
			{
				// Varre array para saber se j� existe
				foreach(AbstractTree tree in trees)
				{
					// Verifica se j� existe uma �rvore deste tipo no array
					if(tree.GetType().Equals(System.Type.GetType(ClassMap.getClass(treeName))))
					{
						// Remove o elemento.
						trees.Remove(tree);
						break;
					}
				}
			}
		}
		
		/// <summary>
		/// M�todo para inserir um valor nas �rvores.
		/// </summary>
		/// <param name="key">Chave a ser inserida.</param>
		public void insert(String key)
		{
			// Varre o array inserido em todas as estruturas.
			for(int i=0; i <trees.Count; i++)
			{
				AbstractTree tree = (AbstractTree) trees[i];
				// Insere a chave em uma determinada �rvore.
				tree.insertKey(new Key(key));
			}
		}
		/// <summary>
		/// M�todo para deletar um valor nas �rvores
		/// </summary>
		/// <param name="key">Chave a ser deletada.</param>
		public void delete(String key)
		{
			// Varre o array deletando em todas as estruturas.
			foreach(AbstractTree tree in trees)
			{
				// Deleta a chava em uma determinada �rvore.
				tree.deleteKey(new Key(key));
			}
		}
		/// <summary>
		/// M�todo para buscar um valor nas �rvores
		/// </summary>
		/// <param name="key"></param>
		public void search(String key)
		{
			// Varre o array buscando em todas as estruturas.
			foreach(AbstractTree tree in trees)
			{
				// Busca a chava em uma determinada �rvore.
				tree.searchKey(new Key(key));
			}
		}


	}
}
