using System;
using System.Collections;

namespace ED2DataStructures.Trees.Binary.Implementation
{
	/// <summary>
	/// Implementa��o da �rvore AVL, que herda de Binary.
	/// </summary>
	public class AVL : Binary
	{
		/// <summary>
		/// Vari�vel privada que armazena o estado de balnceamento da �rvore.
		/// Balanceada: -1 (esquerda), 0, 1 (direita). Desbalanceada: -2 (esquerda), 2 (direita).
		/// </summary>
		private int balanced;

		/// <summary>
		/// Propriedade para obter ou alterar o estado de balanceamento da �rvore.
		/// </summary>
		public int BALANCED
		{
			get
			{
				return balanced;
			}
			set
			{
				balanced = value;
			}
		}

		/// <summary>
		/// Construtor padr�o. Inicializa vari�veis: altura (-1), balanceamento (0).
		/// </summary>
		public AVL()
		{
			// Altura
			height = -1;
			// Balanceamento
			balanced = 0;
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
			// Verifica se a chave passada � nula
			if(KEY != null)
			{
				// Compara o valor da chave passada com a do n� atual.
				switch (key.VALUE.CompareTo(KEY.VALUE))
				{
					// Caso seja igual, retorna a pr�pria refer�ncia.
					case 0 : result = false;
							 break;
					// Caso seja maior, realiza a inser��o no filho da direita.
					case 1 : getRightChild().insertKey(key);
							 // Realiza balanceamento e atualiza a refer�ncia atual.
							 setThisRef(balance(this));
							 break;
					// Caso seja menor, realiza a inser��o no filho da esquerda.
					case -1: getLeftChild().insertKey(key);
							 // Realiza balanceamento e atualiza a refer�ncia atual.
							 setThisRef( balance(this));
							 break;
				}
			}
			// Caso a chave seja nula, a nova chave � inserida no pr�prio n�.
			else
			{
				// Associa a nova chave ao n�.
				this.KEY = key;
				// Instancia os filhos com chave nula.
				this.setRightChild(new AVL());
				this.setLeftChild(new AVL());
				// Atualiza a altura e balanceamento.
				updateHeight(this);
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
			// Verifica se a chave passada � nula
			if(KEY != null)
			{
				// Compara o valor da chave passada com a do n� atual.
				switch (key.VALUE.CompareTo(KEY.VALUE))
				{
					// Caso seja igual, o n� ser� deletado.
					case 0 : if( (getLeftChild().KEY == null) && (getRightChild().KEY == null) ) //O n� retornado � um n�-folha.
							 {

								 // Deleta refer�ncia para os filhos.
								 setLeftChild(null);
								 setRightChild(null);
								 // Anula a chave.
								 key = null;
								 // Zera balanceamento.
								 balanced = 0;
								 // Altura com valor de n� nulo.
								 height = -1;
							 }
							 // O n� retornado tem apenas filho a direita.
							 else if(getLeftChild().KEY == null)
							 {
								 // Recebe a chave do filho a direita.
								 key = getRightChild().KEY;
								 // Recebe o estado de balanceamento do filho a direita.
								 balanced = ((AVL)getRightChild()).BALANCED;
								 // Recebe a altura do filho a direita.
								 height = getRightChild().HEIGHT;
								 // Recebe as refer�ncias dos filhos do filho a direita.
								 setRightChild(getRightChild().getRightChild());
								 setLeftChild(getLeftChild().getLeftChild());
							 }
							 // O n� retornado � um n� interno.
							 else
							 {
								 // obt�m o filho a esquerda.
								 AVL leftChild = (AVL) getLeftChild();
								 // N� atual recebe a chave do filho mais a direita do filho a esquerda.
								 // O m�todo deleta a refer�ncia do n� folha.
								 // O m�todo realiza o balanceamento da �vore at� o filho.
								 key = depperRightChild(ref leftChild);
								 // Realiza balanceamento e atualiza a refer�ncia atual.
								 setThisRef(balance(this));
							 }
							 break;
					// Caso seja maior, realiza a dele��o no filho da direita.
					case 1 : getRightChild().deleteKey(key);
							 // Realiza balanceamento e atualiza a refer�ncia atual.
							 setThisRef(balance(this));
							 break;
					// Caso seja menor, realiza a busca no filho da esquerda.
					case -1: getLeftChild().deleteKey(key);
							 // Realiza balanceamento e atualiza a refer�ncia atual.
							 setThisRef( balance(this));
							 break;
				}
			}
			// Retorna a flag
			return result;
		}
		/// <summary>
		/// M�todo para Alterar a pr�pria refer�ncia.
		/// </summary>
		/// <param name="tree">N� para atualizar a refer�ncia atual</param>
		private void setThisRef(AVL tree)
		{
			// Verifica se o n� atual j� � igual ao n� passado.
			if(!this.Equals(tree))
			{
				// Cria um n� auxiliar
				AVL aux = new AVL();
				// Atualiza valores
				aux.KEY = KEY;
				aux.HEIGHT = HEIGHT;
				aux.BALANCED = BALANCED;
				aux.setLeftChild(getLeftChild());
				aux.setRightChild(getRightChild());
				// Modifica a inst�ncia this, verificando se o valor do n� passado.
				switch(tree.KEY.VALUE.CompareTo(KEY.VALUE))
				{
					// Caso seja maior, o auxiliar vira filho a direita.
					case  1 : key = tree.KEY;
							  balanced = tree.BALANCED;
							  height = tree.HEIGHT;
							  setLeftChild(aux);
							  setRightChild(tree.getRightChild());
							  break;
					// Caso seja menor, o auxiliar vira filho a esquerda.
					case -1 : KEY = tree.KEY;
							  balanced = tree.BALANCED;
							  height = tree.HEIGHT;
							  setLeftChild(tree.getLeftChild());
							  setRightChild(aux);
							  break;
				}
			}
		}

		/// <summary>
		/// M�todo que verifica se a �rvore est� desbalanceada, e caso estaja, realiza balanceamento.
		/// </summary>
		/// <param name="tree">�rvore a ser balanceada.</param>
		/// <returns>�rvore j� balanceada.</returns>
		public AVL balance(AVL tree)
		{
			// Atualiza a altura do n� e verifica o estado de balanceamento.
			switch(updateHeight(tree))
			{
				// Est� desbalanceada a direita. Realiza rota��o no filho da direita.
				case  2: tree = rotateRight(tree);
						 break;
				// Est� desbalanceada a esquerda. Realiza rota��o no filho da esquerda.
				case -2: tree = rotateLeft(tree);
						 break;
			}
			// Retorna a �rvore j� balanceada.
			return tree;
		}

		/// <summary>
		/// Met�do que atualiza a altura da �rvore
		/// </summary>
		/// <param name="tree">�rvore a ser atualizada</param>
		/// <returns>Estado de balanceamento do n�.</returns>
		private int updateHeight(AVL tree)
		{
			// Chama m�todo da super-classe
			base.updateHeight(tree);
			// Atualiza estado de balanceamento.
			AVL avlTree = (AVL) tree;
			avlTree.BALANCED = getRightChild().HEIGHT - getLeftChild().HEIGHT;
			// Retorna estado de balanceamento.
			return avlTree.BALANCED;
		}
		
		/// <summary>
		/// Metodo para rotacionar o elemento a direita
		/// </summary>
		/// <param name="tree">elemento a ser rotacionado</param>
		/// <returns>�rvore balanceada</returns>
		public AVL rotateRight( AVL tree)
		{
			// Vari�vel auxiliar.
			AVL aux = tree;
			// Filho direito.
			AVL rightChild = (AVL) tree.getRightChild();
			// Filho esquerdo do filho a direita.
			AVL subTree2 = (AVL) rightChild.getLeftChild();
			// Rota��o
			rightChild.setLeftChild(tree);
			tree.setRightChild(subTree2);
			// Atualiza altura dos n�s
			updateHeight(tree);
			switch(updateHeight(rightChild))
			{
				// Caso a rota��o simples n�o funicone, � realizada uma rota��o dupla;
				case  2: rightChild.setLeftChild(rotateRight((AVL)rightChild.getLeftChild()));
						 rightChild = rotateLeft(rightChild);
						 break;
			}
			// �rvore balanceada.
			return rightChild;
		}

		/// <summary>
		/// Metodo para rotacionar o elemento a esquerda
		/// </summary>
		/// <param name="tree">Elemento a ser rotacionado</param>
		/// <returns>�rvore balanceada</returns>
		public AVL rotateLeft( AVL tree)
		{
			// Vari�vel auxiliar.
			AVL aux = tree;
			// Filho esquerdo.
			AVL leftChild = (AVL) tree.getLeftChild();
			// Filho direito do filho esquerdo.
			AVL subTree2 = (AVL) leftChild.getRightChild();
			// Rota��o
			leftChild.setRightChild(tree);
			tree.setLeftChild(subTree2);
			// Atualiza altura dos n�s
			updateHeight(tree);
			switch(updateHeight(leftChild))
			{
				// Caso a rota��o simples n�o funicone, � realizada uma rota��o dupla.
				case -2: leftChild.setRightChild(rotateLeft((AVL)leftChild.getRightChild()));
							leftChild = rotateRight(leftChild);
							break;
			}
			// �rvore balanceada.
			return leftChild;
		}

		/// <summary>
		/// M�todo para obter o filho mais a direita de um n�.
		/// </summary>
		/// <param name="tree">N� onde se realizar� a busca.</param>
		/// <returns>Chave do filho mais a direita.</returns>
		private Key depperRightChild(ref AVL tree)
		{
			// Chave para ser retornada.
			Key result = null;
			// Verifica se o n� atual tem filho a direita.
			if(tree.getRightChild().KEY != null)
			{
				// Busca no filho a direita.
				AVL rightChild = (AVL)tree.getRightChild();
				result = depperRightChild(ref rightChild);
				// Realiza balanceamento
				tree.setThisRef(balance(tree));
			}
			// Caso n�o tenha filho a direita
			else
			{
				// O resultado recebe a chave do n� atual
				result = tree.KEY;
				// Refer�ncia do n� atua recebe filho a esquerda.
				tree.KEY = tree.getLeftChild().KEY;
				tree.HEIGHT = tree.getLeftChild().HEIGHT;
				tree.BALANCED = ((AVL)tree.getLeftChild()).BALANCED;
				tree.setRightChild(tree.getLeftChild().getRightChild());
				tree.setLeftChild(tree.getLeftChild().getLeftChild());
			}
			// Retorna chave encontrada.
			return result;
		}
	}
}
