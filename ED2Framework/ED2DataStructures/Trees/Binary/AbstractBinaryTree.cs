using System;
using ED2DataStructures.Trees;

namespace ED2DataStructures.Trees.Binary
{
	/// <summary>
	/// Classe abstrata que representa uma �rvore bin�ria, que herda de AbstractTree.
	/// </summary>
	public abstract class AbstractBinaryTree : AbstractTree	
	{

		/// <summary>
		/// Vari�vel protegida que representa o elemento da esquerda
		/// </summary>
		protected AbstractBinaryTree left;
		/// <summary>
		/// Vari�vel protegida que representa o elemento da direita
		/// </summary>
		protected AbstractBinaryTree right;
		/// <summary>
		/// Vari�vel protegida que armazena a altura da �rvore
		/// </summary>
		protected int height;
		/// <summary>
		/// Vari�vel protegida que armazena a chave do n�.
		/// </summary>
		protected Key key;

		/// <summary>
		/// Propriedade para obter ou alterar a altura da �rvore.
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
		/// Propriedade para obter ou alterar a chave da �rvore.
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
		/// M�todo para obter uma refer�ncia para o filho da esquerda.
		/// </summary>
		/// <returns>Filho esquerdo</returns>
		public AbstractBinaryTree getLeftChild()
		{
			return left;
		}
		/// <summary>
		/// M�todo para alterar a refer�ncia para o filho da esquerda.
		/// </summary>
		/// <param name="left">Novo filho.</param>
		public void setLeftChild(AbstractBinaryTree left)
		{
			this.left = left;
		}
		/// <summary>
		/// M�todo para obter a refer�ncia do filho da direita.
		/// </summary>
		/// <returns>Filho direito</returns>
		public AbstractBinaryTree getRightChild()
		{
			return right;
		}
		/// <summary>
		/// M�todo para alterar a refer�ncia do filho da direita.
		/// </summary>
		/// <param name="right"></param>
		public void setRightChild(AbstractBinaryTree right)
		{
			this.right = right;
		}
	}
}
