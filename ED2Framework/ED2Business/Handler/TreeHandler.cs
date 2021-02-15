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
		/// Variável privada para instancia única de TreeHandler
		/// </summary>
		private static TreeHandler instance;
		/// <summary>
		/// Variável privada para criar as estruturas de dados;
		/// </summary>
		private AbstractTreeFactory factory;
		/// <summary>
		/// ArryaList que armazenará as estruturas.
		/// </summary>
		private ArrayList trees;
		
		/// <summary>
		/// Construtor padrão. Privado para garantir única instância.
		/// </summary>
		private TreeHandler()
		{
			// Inicializa factory de estruturas
			factory = AbstractTreeFactory.getInstance();
			// Inicializa array
			trees = new ArrayList();
		}

		/// <summary>
		/// Retorna a única instancia do manipulador.
		/// </summary>
		/// <returns>Instância do manipulador.</returns>
		public static TreeHandler getInstance()
		{
			// Verifica se instância é nula
			if(instance == null)
				// Caso seja nula, ela é criada.
				instance = new TreeHandler();
			// Retorna a instância.
			return instance;
		}

		/// <summary>
		/// Método para adicioanar uma árvore ao manipulador.
		/// </summary>
		/// <param name="treeName">Tipo de árvore a ser adicionada</param>
		public AbstractTree addTree(StructureType.Trees treeName, int ordem)
		{
			// Nova árvore criada
			AbstractTree newTree = factory.createObject(treeName);
			// Inicializa ordem, caso precise.
			newTree.init(ordem);
			// Flag de inserção.
			bool inserted = false;
			// Varre array para saber se já existe
			foreach(AbstractTree tree in trees)
			{
				// Verifica se já existe uma árvore deste tipo no array
				if(tree.GetType().FullName.Equals(newTree.GetType().FullName))
				{
					// Caso haja, a antiga referência é removida.
					trees.Remove(tree);
					//  E a nova inserida.
					trees.Add(newTree);
					inserted = true;
					break;
				}
			}
			// Se não foi inserido, adciona.
			if(!inserted)
			{
				// Adiciona nova entidade.
				trees.Add(newTree);
			}
			return newTree;
		}

		/// <summary>
		/// Método para remover uma árvore do manipulador.
		/// </summary>
		/// <param name="treeName">Tipo de árvore a ser removida</param>
		public void removeTree(StructureType.Trees treeName)
		{
			// Verifica se o array contém elementos.
			if(trees.Count>0)
			{
				// Varre array para saber se já existe
				foreach(AbstractTree tree in trees)
				{
					// Verifica se já existe uma árvore deste tipo no array
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
		/// Método para inserir um valor nas árvores.
		/// </summary>
		/// <param name="key">Chave a ser inserida.</param>
		public void insert(String key)
		{
			// Varre o array inserido em todas as estruturas.
			for(int i=0; i <trees.Count; i++)
			{
				AbstractTree tree = (AbstractTree) trees[i];
				// Insere a chave em uma determinada árvore.
				tree.insertKey(new Key(key));
			}
		}
		/// <summary>
		/// Método para deletar um valor nas árvores
		/// </summary>
		/// <param name="key">Chave a ser deletada.</param>
		public void delete(String key)
		{
			// Varre o array deletando em todas as estruturas.
			foreach(AbstractTree tree in trees)
			{
				// Deleta a chava em uma determinada árvore.
				tree.deleteKey(new Key(key));
			}
		}
		/// <summary>
		/// Método para buscar um valor nas árvores
		/// </summary>
		/// <param name="key"></param>
		public void search(String key)
		{
			// Varre o array buscando em todas as estruturas.
			foreach(AbstractTree tree in trees)
			{
				// Busca a chava em uma determinada árvore.
				tree.searchKey(new Key(key));
			}
		}


	}
}
