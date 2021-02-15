using System;

namespace ED2DataStructures.Trees.Binary.Implementation
{
	/// <summary>
	/// Implementação da Splay, que herda de BinaryTree.
	/// </summary>
	public class Splay : Binary
	{
		/// <summary>
		/// Construtor padrão. inicializa variáveis: altura(-1) 
		/// </summary>
		public Splay()
		{
			height = -1;
		}

		/// <summary>
		/// Método para Alterar a própria referência.
		/// </summary>
		/// <param name="tree">Nó para atualizar a referência atual</param>
		private void setThisRef(AbstractBinaryTree tree)
		{
			// Verifica se o nó atual já é igual ao nó passado.
			if(!this.Equals(tree))
			{
				// Cria um nó auxiliar
				Splay aux = new Splay();
				// Atualiza valores
				aux.KEY = KEY;
				aux.HEIGHT = HEIGHT;
				aux.setLeftChild(getLeftChild());
				aux.setRightChild(getRightChild());
				// Modifica a instância this, verificando se o valor do nó passado.
				switch(tree.KEY.VALUE.CompareTo(KEY.VALUE))
				{
						// Caso seja maior, o auxiliar vira filho a direita.
					case  1 : key = tree.KEY;
							  height = tree.HEIGHT;
							  setLeftChild(aux);
							  setRightChild(tree.getRightChild());
							  break;
					// Caso seja menor, o auxiliar vira filho a esquerda.
					case -1 : KEY = tree.KEY;
							  height = tree.HEIGHT;
							  setLeftChild(tree.getLeftChild());
							  setRightChild(aux);
							  break;
				}
			}
		}

		/// <summary>
		/// Método para buscar uma chave na estrutura
		/// </summary>
		/// <param name="key">Chave a ser buscada</param>
		/// <returns>Árvore contendo um nó com a chave, em caso de sucesso na busca,
		///  ou um nó com chave nula (nó onde a chave deveria estar)</returns>
		public override AbstractTree searchKey(Key key)
		{
			AbstractBinaryTree tree = null;
			if(KEY != null)
			{
				switch (key.VALUE.CompareTo(KEY.VALUE))
				{
					case 0 : tree = this;
						break;
					case 1 : tree = (AbstractBinaryTree)getRightChild().searchKey(key);
							 setThisRef(splayUpTree(this, tree.KEY));
						break;
					case -1: tree = (AbstractBinaryTree)getLeftChild().searchKey(key);
							 setThisRef(splayUpTree(this, tree.KEY));
						break;
				}
			}
			else
			{
				tree = this;
			}

			return tree;
		}

		public override bool insertKey(Key key)
		{
			bool result = false;
			if(KEY != null)
			{
				switch (key.VALUE.CompareTo(KEY.VALUE))
				{
					case 0 : result = false;
						break;
					case 1 : getRightChild().insertKey(key);
							 updateHeight(this);
							 break;
					case -1: getLeftChild().insertKey(key);
							 updateHeight(this);
							 break;
				}
			}
			else
			{
				this.KEY = key;
				this.setRightChild(new Splay());
				this.setLeftChild(new Splay());
				updateHeight(this);
				result = true;
			}
			return result;
		}

		public override bool deleteKey(Key key)
		{
			bool result = false;
			if(KEY != null)
			{
				switch (key.VALUE.CompareTo(KEY.VALUE))
				{
					case 0 : if( (getLeftChild().KEY == null) && (getRightChild().KEY == null) )
							 {
								 setLeftChild(null);
								 setRightChild(null);
								 HEIGHT = -1;
								 KEY = null;
							 }
							 else if(getLeftChild().KEY == null)
							 {
								 KEY = getRightChild().KEY;
								 HEIGHT = getRightChild().HEIGHT;
								 setRightChild(getRightChild().getRightChild());
								 setLeftChild(getLeftChild().getLeftChild());
							 }
							 else
							 {
								 Binary leftChild = (Binary) getLeftChild();
								 KEY = depperRightChild(ref leftChild);
							 }
						break;
					case 1 : getRightChild().deleteKey(key);
							 break;
					case -1: getLeftChild().deleteKey(key);
							 break;
				}
			}
			return result;
		}

		public AbstractBinaryTree splayUpTree(AbstractBinaryTree tree, Key key)
		{
			if(tree.KEY.VALUE.Equals(key.VALUE))
			{
			}
			if(tree.getLeftChild().KEY != null)
			{
				if (tree.getLeftChild().getLeftChild().KEY != null)
				{
					if(tree.getLeftChild().getLeftChild().KEY.VALUE.Equals(key.VALUE))
					{
						tree = zigZig(tree);
						return tree;
					}
				}
				if (tree.getLeftChild().getRightChild().KEY != null)
				{
					if(tree.getLeftChild().getRightChild().KEY.VALUE.Equals(key.VALUE))
					{
						tree = zagZig(tree);
						return tree;
					}
				}
				if (tree.getLeftChild().KEY.VALUE.Equals(key.VALUE))
				{
					tree = zig(tree);
					return tree;
				}
			}
			if(tree.getRightChild().KEY != null)
			{
			
				if(tree.getRightChild().getRightChild().KEY != null)
				{
					if(tree.getRightChild().getRightChild().KEY.VALUE.Equals(key.VALUE))
					{
						tree = zagZag(tree);
						return tree;
					}
				}
				if(tree.getRightChild().getLeftChild().KEY != null)
				{
					if(tree.getRightChild().getLeftChild().KEY.VALUE.Equals(key.VALUE))
					{
						tree = zigZag(tree);
						return tree;
					}
				}
				if(tree.getRightChild().KEY.VALUE.Equals(key.VALUE))
				{
					tree = zag(tree);
					return tree;
				}
			}
			return tree;
		}

		public AbstractBinaryTree zig( AbstractBinaryTree tree)
		{
			Splay aux = (Splay)tree;
			Splay leftChild = (Splay) tree.getLeftChild();
			Splay subTree2 = (Splay) leftChild.getRightChild();

			leftChild.setRightChild(tree);
			tree.setLeftChild(subTree2);

			updateHeight(tree);
			updateHeight(leftChild);

			return leftChild;
		}

		public AbstractBinaryTree zag( AbstractBinaryTree tree)
		{
			Splay aux = (Splay)tree;
			Splay rightChild = (Splay) tree.getRightChild();
			Splay subTree2 = (Splay) rightChild.getLeftChild();

			rightChild.setLeftChild(tree);
			tree.setRightChild(subTree2);

			updateHeight(tree);
			updateHeight(rightChild);
		
			return rightChild;
		}
					

		public AbstractBinaryTree zigZag(AbstractBinaryTree tree)
		{
			tree.setRightChild(zig((Splay)tree.getRightChild()));
			tree = zag(tree);
						
			return tree;
		}

		public AbstractBinaryTree zagZig(AbstractBinaryTree tree)
		{
			tree.setLeftChild(zag((Splay)tree.getLeftChild()));
			tree = zig(tree);
			
			return tree;
		}

		public AbstractBinaryTree zagZag(AbstractBinaryTree tree)
		{
			tree = zag(tree);
			tree = zag(tree);
			
			return tree;
		}

		public AbstractBinaryTree zigZig(AbstractBinaryTree tree)
		{

			tree = zig(tree);
			tree = zig(tree);

			return tree;
		}

		private int updateHeight(AbstractBinaryTree tree)
		{
			tree.HEIGHT = Math.Max(tree.getRightChild().HEIGHT,tree.getLeftChild().HEIGHT)+1;
			
			return tree.HEIGHT;
		}

	}
}
