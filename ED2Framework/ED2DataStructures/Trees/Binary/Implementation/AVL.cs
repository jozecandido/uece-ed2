using System;
using System.Collections;

namespace ED2DataStructures.Trees.Binary.Implementation
{
	/// <summary>
	/// Implementação da árvore AVL, que herda de Binary.
	/// </summary>
	public class AVL : Binary
	{
		/// <summary>
		/// Variável privada que armazena o estado de balnceamento da árvore.
		/// Balanceada: -1 (esquerda), 0, 1 (direita). Desbalanceada: -2 (esquerda), 2 (direita).
		/// </summary>
		private int balanced;

		/// <summary>
		/// Propriedade para obter ou alterar o estado de balanceamento da árvore.
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
		/// Construtor padrão. Inicializa variáveis: altura (-1), balanceamento (0).
		/// </summary>
		public AVL()
		{
			// Altura
			height = -1;
			// Balanceamento
			balanced = 0;
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
			// Verifica se a chave passada é nula
			if(KEY != null)
			{
				// Compara o valor da chave passada com a do nó atual.
				switch (key.VALUE.CompareTo(KEY.VALUE))
				{
					// Caso seja igual, retorna a própria referência.
					case 0 : result = false;
							 break;
					// Caso seja maior, realiza a inserção no filho da direita.
					case 1 : getRightChild().insertKey(key);
							 // Realiza balanceamento e atualiza a referência atual.
							 setThisRef(balance(this));
							 break;
					// Caso seja menor, realiza a inserção no filho da esquerda.
					case -1: getLeftChild().insertKey(key);
							 // Realiza balanceamento e atualiza a referência atual.
							 setThisRef( balance(this));
							 break;
				}
			}
			// Caso a chave seja nula, a nova chave é inserida no próprio nó.
			else
			{
				// Associa a nova chave ao nó.
				this.KEY = key;
				// Instancia os filhos com chave nula.
				this.setRightChild(new AVL());
				this.setLeftChild(new AVL());
				// Atualiza a altura e balanceamento.
				updateHeight(this);
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
			// Verifica se a chave passada é nula
			if(KEY != null)
			{
				// Compara o valor da chave passada com a do nó atual.
				switch (key.VALUE.CompareTo(KEY.VALUE))
				{
					// Caso seja igual, o nó será deletado.
					case 0 : if( (getLeftChild().KEY == null) && (getRightChild().KEY == null) ) //O nó retornado é um nó-folha.
							 {

								 // Deleta referência para os filhos.
								 setLeftChild(null);
								 setRightChild(null);
								 // Anula a chave.
								 key = null;
								 // Zera balanceamento.
								 balanced = 0;
								 // Altura com valor de nó nulo.
								 height = -1;
							 }
							 // O nó retornado tem apenas filho a direita.
							 else if(getLeftChild().KEY == null)
							 {
								 // Recebe a chave do filho a direita.
								 key = getRightChild().KEY;
								 // Recebe o estado de balanceamento do filho a direita.
								 balanced = ((AVL)getRightChild()).BALANCED;
								 // Recebe a altura do filho a direita.
								 height = getRightChild().HEIGHT;
								 // Recebe as referências dos filhos do filho a direita.
								 setRightChild(getRightChild().getRightChild());
								 setLeftChild(getLeftChild().getLeftChild());
							 }
							 // O nó retornado é um nó interno.
							 else
							 {
								 // obtém o filho a esquerda.
								 AVL leftChild = (AVL) getLeftChild();
								 // Nó atual recebe a chave do filho mais a direita do filho a esquerda.
								 // O método deleta a referência do nó folha.
								 // O método realiza o balanceamento da ávore até o filho.
								 key = depperRightChild(ref leftChild);
								 // Realiza balanceamento e atualiza a referência atual.
								 setThisRef(balance(this));
							 }
							 break;
					// Caso seja maior, realiza a deleção no filho da direita.
					case 1 : getRightChild().deleteKey(key);
							 // Realiza balanceamento e atualiza a referência atual.
							 setThisRef(balance(this));
							 break;
					// Caso seja menor, realiza a busca no filho da esquerda.
					case -1: getLeftChild().deleteKey(key);
							 // Realiza balanceamento e atualiza a referência atual.
							 setThisRef( balance(this));
							 break;
				}
			}
			// Retorna a flag
			return result;
		}
		/// <summary>
		/// Método para Alterar a própria referência.
		/// </summary>
		/// <param name="tree">Nó para atualizar a referência atual</param>
		private void setThisRef(AVL tree)
		{
			// Verifica se o nó atual já é igual ao nó passado.
			if(!this.Equals(tree))
			{
				// Cria um nó auxiliar
				AVL aux = new AVL();
				// Atualiza valores
				aux.KEY = KEY;
				aux.HEIGHT = HEIGHT;
				aux.BALANCED = BALANCED;
				aux.setLeftChild(getLeftChild());
				aux.setRightChild(getRightChild());
				// Modifica a instância this, verificando se o valor do nó passado.
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
		/// Método que verifica se a árvore está desbalanceada, e caso estaja, realiza balanceamento.
		/// </summary>
		/// <param name="tree">Árvore a ser balanceada.</param>
		/// <returns>Árvore já balanceada.</returns>
		public AVL balance(AVL tree)
		{
			// Atualiza a altura do nó e verifica o estado de balanceamento.
			switch(updateHeight(tree))
			{
				// Está desbalanceada a direita. Realiza rotação no filho da direita.
				case  2: tree = rotateRight(tree);
						 break;
				// Está desbalanceada a esquerda. Realiza rotação no filho da esquerda.
				case -2: tree = rotateLeft(tree);
						 break;
			}
			// Retorna a árvore já balanceada.
			return tree;
		}

		/// <summary>
		/// Metódo que atualiza a altura da árvore
		/// </summary>
		/// <param name="tree">Árvore a ser atualizada</param>
		/// <returns>Estado de balanceamento do nó.</returns>
		private int updateHeight(AVL tree)
		{
			// Chama método da super-classe
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
		/// <returns>Árvore balanceada</returns>
		public AVL rotateRight( AVL tree)
		{
			// Variável auxiliar.
			AVL aux = tree;
			// Filho direito.
			AVL rightChild = (AVL) tree.getRightChild();
			// Filho esquerdo do filho a direita.
			AVL subTree2 = (AVL) rightChild.getLeftChild();
			// Rotação
			rightChild.setLeftChild(tree);
			tree.setRightChild(subTree2);
			// Atualiza altura dos nós
			updateHeight(tree);
			switch(updateHeight(rightChild))
			{
				// Caso a rotação simples não funicone, é realizada uma rotação dupla;
				case  2: rightChild.setLeftChild(rotateRight((AVL)rightChild.getLeftChild()));
						 rightChild = rotateLeft(rightChild);
						 break;
			}
			// Árvore balanceada.
			return rightChild;
		}

		/// <summary>
		/// Metodo para rotacionar o elemento a esquerda
		/// </summary>
		/// <param name="tree">Elemento a ser rotacionado</param>
		/// <returns>Árvore balanceada</returns>
		public AVL rotateLeft( AVL tree)
		{
			// Variável auxiliar.
			AVL aux = tree;
			// Filho esquerdo.
			AVL leftChild = (AVL) tree.getLeftChild();
			// Filho direito do filho esquerdo.
			AVL subTree2 = (AVL) leftChild.getRightChild();
			// Rotação
			leftChild.setRightChild(tree);
			tree.setLeftChild(subTree2);
			// Atualiza altura dos nós
			updateHeight(tree);
			switch(updateHeight(leftChild))
			{
				// Caso a rotação simples não funicone, é realizada uma rotação dupla.
				case -2: leftChild.setRightChild(rotateLeft((AVL)leftChild.getRightChild()));
							leftChild = rotateRight(leftChild);
							break;
			}
			// Árvore balanceada.
			return leftChild;
		}

		/// <summary>
		/// Método para obter o filho mais a direita de um nó.
		/// </summary>
		/// <param name="tree">Nó onde se realizará a busca.</param>
		/// <returns>Chave do filho mais a direita.</returns>
		private Key depperRightChild(ref AVL tree)
		{
			// Chave para ser retornada.
			Key result = null;
			// Verifica se o nó atual tem filho a direita.
			if(tree.getRightChild().KEY != null)
			{
				// Busca no filho a direita.
				AVL rightChild = (AVL)tree.getRightChild();
				result = depperRightChild(ref rightChild);
				// Realiza balanceamento
				tree.setThisRef(balance(tree));
			}
			// Caso não tenha filho a direita
			else
			{
				// O resultado recebe a chave do nó atual
				result = tree.KEY;
				// Referência do nó atua recebe filho a esquerda.
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
