using System;
using ED2DataStructures.Trees;

namespace ED2DataStructures.Trees.Binary
{
	/// <summary>
	/// Classe abstrata que representa uma árvore binária, que herda de AbstractTree.
	/// </summary>
	public abstract class AbstractBinaryTree : AbstractTree	
	{

		/// <summary>
		/// Variável protegida que representa o elemento da esquerda
		/// </summary>
		protected AbstractBinaryTree left;
		/// <summary>
		/// Variável protegida que representa o elemento da direita
		/// </summary>
		protected AbstractBinaryTree right;
		/// <summary>
		/// Variável protegida que armazena a altura da árvore
		/// </summary>
		protected int height;
		/// <summary>
		/// Variável protegida que armazena a chave do nó.
		/// </summary>
		protected Key key;

		/// <summary>
		/// Propriedade para obter ou alterar a altura da árvore.
		/// </summary>
		public int HEIGHT
		{
			get
			{
				return height;
			}
			set
			{
				height = value;
			}
		}
		/// <summary>
		/// Propriedade para obter ou alterar a chave da árvore.
		/// </summary>
		public Key KEY
		{
			get
			{
				return key;
			}
			set
			{
				key = value;
			}
		}

		/// <summary>
		/// Método para obter uma referência para o filho da esquerda.
		/// </summary>
		/// <returns>Filho esquerdo</returns>
		public AbstractBinaryTree getLeftChild()
		{
			return left;
		}
		/// <summary>
		/// Método para alterar a referência para o filho da esquerda.
		/// </summary>
		/// <param name="left">Novo filho.</param>
		public void setLeftChild(AbstractBinaryTree left)
		{
			this.left = left;
		}
		/// <summary>
		/// Método para obter a referência do filho da direita.
		/// </summary>
		/// <returns>Filho direito</returns>
		public AbstractBinaryTree getRightChild()
		{
			return right;
		}
		/// <summary>
		/// Método para alterar a referência do filho da direita.
		/// </summary>
		/// <param name="right"></param>
		public void setRightChild(AbstractBinaryTree right)
		{
			this.right = right;
		}
	}
}
