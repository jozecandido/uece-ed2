using System;
using System.Collections;
using ED2DataStructures.Trees;

namespace ED2DataStructures.Trees.Binary.Implementation
{
	/// <summary>
	/// Implementa��o da �rvore bin�ria, que herda de AbstractBinaryTree.
	/// </summary>
	public class Binary : AbstractBinaryTree
	{
		/// <summary>
		/// Construtor padr�o. inicializa vari�veis: altura(-1) e chave (nula).
		/// </summary>
		public Binary()
		{
			// Altura
			height = -1;
			//Chave
			key = null;
		}
		
		/// <summary>
		/// M�todo para inserir uma chave na estrutura.
		/// </summary>
		/// <param name="key">Chave do n�.</param>
		/// <returns>Flag para sucesso/erro da opera��o.</returns>
		public override bool insertKey(Key key)
		{
			// Vari�vel de retorno. Considerando erro na opera��o.
			bool result = false;
			// N� com o resultado da busca.
			Binary tree = (Binary) searchKey(key);
			// Verifica se a chave � nula. Caso sim, o n� ainda n�o existe e pode ser inserirdo.
			if(tree.KEY == null)
			{
				// Associa a nova chave ao n�.
				tree.KEY = key;
				// Instancia os filhos com chave nula.
				tree.setRightChild(new Binary());
				tree.setLeftChild (new Binary());
				// Atualiza altura.
				updateHeight(tree);
				// Flag indicando o sucesso da opera��o.
				result = true;
			}
			// Retorna a flag
			return result;
		}

		/// <summary>
		/// M�todo para deletar uma chave na estrutura.
		/// </summary>
		/// <param name="key">Chave do n�.</param>
		/// <returns>Flag para sucesso/erro da opera��o.</returns>
		public override bool deleteKey(Key key)
		{
			// Vari�vel de retorno. Considerando erro na opera��o.
			bool result = false;
			// N� com o resultado da busca.
			Binary tree = (Binary) searchKey(key);
			// Verifica se a chave � deiferente de nulo. Caso sim, o n� pode ser deletado.
			if(tree.KEY != null)
			{
				// O n� retornado � um n�-folha.
				if( (tree.getLeftChild().KEY == null) && (tree.getRightChild().KEY == null) )
				{
					// Deleta refer�ncia para os filhos.
					tree.setLeftChild(null);
					tree.setRightChild(null);
					// Anula a chave.
					tree.KEY = null;
				}
				// O n� retornado tem apenas filho a direita.
				else if(tree.getLeftChild().KEY == null)
				{
					// No atual recebe o filho a direita.
					tree = (Binary) tree.getRightChild();
				}
				// O n� retornado � um n� interno.
				else
				{
					// obt�m o filho a esquerda.
					Binary leftChild = (Binary)tree.getLeftChild();
					// N� atual recebe a chave do filho mais a direita do filho a esquerda.
					// O m�todo deleta a refer�ncia do n� folha.
					tree.KEY = depperRightChild(ref leftChild);
				}
				// Atualiza altura.
				updateHeight(tree);
				// Flag indicando o sucesso da opera��o.
				result = true;
			}
			// Restorna a flag.
			return result;
		}

		/// <summary>
		/// M�todo para buscar uma chave na estrutura
		/// </summary>
		/// <param name="key">Chave a ser buscada</param>
		/// <returns>�rvore contendo um n� com a chave, em caso de sucesso na busca,
		///  ou um n� com chave nula (n� onde a chave deveria estar)</returns>
		public override AbstractTree searchKey(Key key)
		{
			// �rvore a ser retornada.
			AbstractTree tree = null;
			// Verifica se a chave passada � nula.
			if(KEY != null)
			{
				// Compara o valor da chave passada com a do n� atual.
				switch (key.VALUE.CompareTo(KEY.VALUE))
				{
					// Caso seja igual, retorna a pr�pria refer�ncia.
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
			// Caso a chave seja nula, retorna a prorpia refer�ncia.
			else
			{
				tree = this;
			}
			// Retorna a �rvole
			return tree;
		}

		/// <summary>
		/// M�todo para obter o filho mais a direita de um n�.
		/// </summary>
		/// <param name="tree">N� onde se realizar� a busca.</param>
		/// <returns>Chave do filho mais a direita.</returns>
		protected Key depperRightChild(ref Binary tree)
		{
			// Chave para ser retornada.
			Key result = null;
			// Verifica se o n� atual tem filho a direita.
			if(tree.getRightChild().KEY != null)
			{
				// Busca no filho a direita.
				Binary rightChild = (Binary) tree.getRightChild();
				result = depperRightChild(ref rightChild);
			}
			// Caso n�o tenha filho a direita
			else
			{
				// O resultado recebe a chave do n� atual
				result = tree.KEY;
				// Refer�ncia do n� atua recebe filho a esquerda.
                tree = (Binary)tree.getLeftChild();
			}
			// Retorna chave encontrada.
			return result;
		}

		/// <summary>
		/// Met�do que atualiza a altura da �rvore.
		/// </summary>
		/// <param name="tree">�rvore que ser� atualizada.</param>
		/// <returns>Altura atualizada.</returns>
		protected int updateHeight(Binary tree)
		{
			tree.HEIGHT = Math.Max(tree.getRightChild().HEIGHT,tree.getLeftChild().HEIGHT)+1;
						
			return tree.HEIGHT;
		}

	}
}
