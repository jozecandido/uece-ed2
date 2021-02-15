using System;
using System.Collections;
using ED2DataStructures.Trees;

namespace ED2DataStructures.Trees.Binary.Implementation
{
	/// <summary>
	/// Implementação da árvore binária, que herda de AbstractBinaryTree.
	/// </summary>
	public class Binary : AbstractBinaryTree
	{
		/// <summary>
		/// Construtor padrão. inicializa variáveis: altura(-1) e chave (nula).
		/// </summary>
		public Binary()
		{
			// Altura
			height = -1;
			//Chave
			key = null;
		}
		
		/// <summary>
		/// Método para inserir uma chave na estrutura.
		/// </summary>
		/// <param name="key">Chave do nó.</param>
		/// <returns>Flag para sucesso/erro da operação.</returns>
		public override bool insertKey(Key key)
		{
			// Variável de retorno. Considerando erro na operação.
			bool result = false;
			// Nó com o resultado da busca.
			Binary tree = (Binary) searchKey(key);
			// Verifica se a chave é nula. Caso sim, o nó ainda não existe e pode ser inserirdo.
			if(tree.KEY == null)
			{
				// Associa a nova chave ao nó.
				tree.KEY = key;
				// Instancia os filhos com chave nula.
				tree.setRightChild(new Binary());
				tree.setLeftChild (new Binary());
				// Atualiza altura.
				updateHeight(tree);
				// Flag indicando o sucesso da operação.
				result = true;
			}
			// Retorna a flag
			return result;
		}

		/// <summary>
		/// Método para deletar uma chave na estrutura.
		/// </summary>
		/// <param name="key">Chave do nó.</param>
		/// <returns>Flag para sucesso/erro da operação.</returns>
		public override bool deleteKey(Key key)
		{
			// Variável de retorno. Considerando erro na operação.
			bool result = false;
			// Nó com o resultado da busca.
			Binary tree = (Binary) searchKey(key);
			// Verifica se a chave é deiferente de nulo. Caso sim, o nó pode ser deletado.
			if(tree.KEY != null)
			{
				// O nó retornado é um nó-folha.
				if( (tree.getLeftChild().KEY == null) && (tree.getRightChild().KEY == null) )
				{
					// Deleta referência para os filhos.
					tree.setLeftChild(null);
					tree.setRightChild(null);
					// Anula a chave.
					tree.KEY = null;
				}
				// O nó retornado tem apenas filho a direita.
				else if(tree.getLeftChild().KEY == null)
				{
					// No atual recebe o filho a direita.
					tree = (Binary) tree.getRightChild();
				}
				// O nó retornado é um nó interno.
				else
				{
					// obtém o filho a esquerda.
					Binary leftChild = (Binary)tree.getLeftChild();
					// Nó atual recebe a chave do filho mais a direita do filho a esquerda.
					// O método deleta a referência do nó folha.
					tree.KEY = depperRightChild(ref leftChild);
				}
				// Atualiza altura.
				updateHeight(tree);
				// Flag indicando o sucesso da operação.
				result = true;
			}
			// Restorna a flag.
			return result;
		}

		/// <summary>
		/// Método para buscar uma chave na estrutura
		/// </summary>
		/// <param name="key">Chave a ser buscada</param>
		/// <returns>Árvore contendo um nó com a chave, em caso de sucesso na busca,
		///  ou um nó com chave nula (nó onde a chave deveria estar)</returns>
		public override AbstractTree searchKey(Key key)
		{
			// Árvore a ser retornada.
			AbstractTree tree = null;
			// Verifica se a chave passada é nula.
			if(KEY != null)
			{
				// Compara o valor da chave passada com a do nó atual.
				switch (key.VALUE.CompareTo(KEY.VALUE))
				{
					// Caso seja igual, retorna a própria referência.
					case 0 : tree = this;
							 break;
					// Caso seja maior, realiza a busca no filho da direita.
					case 1 : tree = getRightChild().searchKey(key);
							 break;
					// Caso seja menor, realiza a busca no filho da esquerda.
					case -1: tree = getLeftChild().searchKey(key);
							 break;
				}
			}
			// Caso a chave seja nula, retorna a prorpia referência.
			else
			{
				tree = this;
			}
			// Retorna a árvole
			return tree;
		}

		/// <summary>
		/// Método para obter o filho mais a direita de um nó.
		/// </summary>
		/// <param name="tree">Nó onde se realizará a busca.</param>
		/// <returns>Chave do filho mais a direita.</returns>
		protected Key depperRightChild(ref Binary tree)
		{
			// Chave para ser retornada.
			Key result = null;
			// Verifica se o nó atual tem filho a direita.
			if(tree.getRightChild().KEY != null)
			{
				// Busca no filho a direita.
				Binary rightChild = (Binary) tree.getRightChild();
				result = depperRightChild(ref rightChild);
			}
			// Caso não tenha filho a direita
			else
			{
				// O resultado recebe a chave do nó atual
				result = tree.KEY;
				// Referência do nó atua recebe filho a esquerda.
                tree = (Binary)tree.getLeftChild();
			}
			// Retorna chave encontrada.
			return result;
		}

		/// <summary>
		/// Metódo que atualiza a altura da árvore.
		/// </summary>
		/// <param name="tree">Árvore que será atualizada.</param>
		/// <returns>Altura atualizada.</returns>
		protected int updateHeight(Binary tree)
		{
			tree.HEIGHT = Math.Max(tree.getRightChild().HEIGHT,tree.getLeftChild().HEIGHT)+1;
						
			return tree.HEIGHT;
		}

	}
}
