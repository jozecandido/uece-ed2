using System;
using System.Collections;
using ED2DataStructures.Trees;



namespace ED2DataStructures.Trees.Multiway.Implementation
{
	/// <summary>
	/// Implementa��o da �rvore AVL, que herda de Binary.
	/// </summary>
	public class B: AbstractMultiwayTree
	{

		/// <summary>
		/// Vari�vel privada que mant�m a refer�ncia da raiz.
		/// </summary>
		private static B root;
		/// <summary>
		/// Vari�vel privada que mant�m a quantidade de n�veis da �rvore.
		/// </summary>
		private static int nivel;
		/// <summary>
		/// Vari�vel privada que indica o estouro da quantidade de chaves em �ma p�gina.
		/// </summary>
		private static bool _estouro;

		/// <summary>
		/// Proproedade para obter ou alterar a quantidade de n�veis da �rvore.
		/// </summary>
		public override int NIVEL
		{
			get
			{
				return nivel;
			}
			set
			{
				nivel = value;
			}
		}
		
		/// <summary>
		/// Construtor padr�o. Inicializa as vari�veis: array de chaves e array de ponteiros.
		/// </summary>
		public B()
		{
			// Chaves
			key = new ArrayList();//Coloca +1 pra poder inserir e nao dar ooverflow
			// Ponteiros
			pointer = new ArrayList();
		}

		/// <summary>
		/// Metodo para inicializar os par�metros: ordem, nivel e root
		/// </summary>
		/// <param name="O"></param>
		public override void init(int ordem)
		{
			// Root
			root = new B();
			// Ordem
			this.ordem = ordem;
			// N�vel
			nivel = -1;
		}

		/// <summary>
		/// M�todo para inserir uma chave na estrutura
		/// </summary>
		/// <param name="key">Chave do n�</param>
		/// <returns>Flag para sucesso/erro da opera��o</returns>
		public override bool insertKey(Key key)
		{
			// Insere pelo root;
			return insertKey(key,root);
		}
		/// <summary>
		/// M�todo para inserir uma chave na estrutura
		/// </summary>
		/// <param name="key">Chave do n�</param>
		/// <returns>Flag para sucesso/erro da opera��o</returns>
		public override bool deleteKey(Key key)
		{
			// Deleta pelo root;
			return deleteKey(key,root);
		}
		/// <summary>
		/// M�todo para buscar uma chave na estrutura
		/// </summary>
		/// <param name="key">Chave a ser buscada</param>
		/// <returns>�rvore contendo um n� com a chave, em caso de sucesso na busca,
		///  ou um n� com chave nula (n� onde a chave deveria estar)</returns>
		public override AbstractTree searchKey(Key key)
		{
			// Busca pelo root;
			return searchKey(key, root);
		}
		

		/// <summary>
		/// M�todo para inserir, de forma ordenada, a chave em um n�.
		/// </summary>
		/// <param name="k">Chave a ser inserida</param>
		/// <param name="_subarvore">sub-�rvore onde ser� inserido</param>
		/// <returns>Flag para sucesso/erro da opera��o</returns>
		private bool insertKey(Key k,B subarvore)
		{
			// Verificar se arvore vazia 
			if (subarvore.key.Count.Equals(0))
			{
				// Insere o prmeiro elemento da raiz
				subarvore.key.Insert(0,k);
			}
			else 
			{	
				//Procura no no atual e retorna o indice onde a chave est� ou deveria estar
				int find = subarvore.searchNo(k,subarvore.key);
				
				if (!k.VALUE.Equals( ((Key)subarvore.key[find]).VALUE))
				{
					//Verifica se n�o tem ponteiros para n�s de outro n�vel
					if(subarvore.pointer.Count.Equals(0))
					{
						// Insere de ordenadamente no n�.
						insereOrdenadoNo(k, subarvore);
						// Indica que n�o houve estouro.
						_estouro = false;
					}
					else if(k.VALUE.CompareTo(((Key)subarvore.key[find]).VALUE) < 0 ) 
					{
						insertKey(k,(B)subarvore.pointer[find]);
						// Verifica Filho
						if (_estouro)
						{
							// Adiciona todos os elemtos da arvore q tem menos q o m�nimo
							int x = 0;
							while ( x < ((B)subarvore.pointer[find]).key.Count)
							{
								insereOrdenadoNo((Key)((B)subarvore.pointer[find]).key[x],subarvore);
								x++;
							}//while
							x = 1;
							int i = find;
							//adiciona os ponteiros
							while ( x < (((B)subarvore.pointer[find]).pointer.Count) )
							{
								subarvore.pointer.Insert(++i,((B)subarvore.pointer[find]).pointer[x]);
								x++;
							}
							//a primeira posi��o coloco por ultimo pra nao perder os poneitos pros outros
							//Primeiro removo e depois insiro
							subarvore.pointer.Insert(find,((B)subarvore.pointer[find]).pointer[0]);
							subarvore.pointer.RemoveAt(find+1);
						}//if
						_estouro = false;
					}//else if
					else if 
						(k.VALUE.CompareTo(((Key)subarvore.key[find]).VALUE)> 0)
					{
						//Procura no n� da direita referenciado pelo ponteiro da direita
						insertKey(k,(B)subarvore.pointer[find+1]);
						//verificar filho
						if (_estouro)//((B)subarvore.pointer[find+1]).key.Count < MINKEY )
						{
							//adiciona todos os elemtos da arvore q tem menos q o m�nimo
							int x = 0;
							while ( x < ((B)subarvore.pointer[find+1]).key.Count)
							{
								insereOrdenadoNo((Key)((B)subarvore.pointer[find+1]).key[x],subarvore);
								x++;
							}//while
							//x = 1 para a posicao aero nao se perder e ser adicionada depois
							x = 1;
							int i = find+1;
							//adiciona os ponteiros
							while ( x < (((B)subarvore.pointer[find+1]).pointer.Count) )
							{
								subarvore.pointer.Insert(++i,((B)subarvore.pointer[find+1]).pointer[x]);
								x++;
							}
							//a primeira posi��o coloco por ultimo pra nao perder os poneitos pros outros
							//Primeiro removo e depois insiro
							subarvore.pointer.Insert(find+1,((B)subarvore.pointer[find+1]).pointer[0]);
							subarvore.pointer.RemoveAt(find+2);
						}//if
						_estouro = false;
					}//else if

					//Verifica se deu overflow
					if (subarvore.key.Count > MAXKEY)
					{
						//balanceamento
						_estouro = estouro(subarvore);
						nivel++;
					}

				}//if
			}//else
			return true;
		}//insertB

		/// <summary>
		/// M�todo para deletar a chave na estrutura.
		/// </summary>
		/// <param name="k">Chave a ser deletada</param>
		/// <param name="_subarvore">sub-�rvore onde ser� deletada</param>
		/// <returns>Flag para sucesso/erro da opera��o</returns>
		private bool deleteKey(Key k, B subarvore)
		{
			//Verificar se arvore vazia 
			if (!subarvore.key.Count.Equals(0))
			{	
				//Procura no no atual e retorna o indice onde a chave est� ou deveria estar
				int find = subarvore.searchNo(k,subarvore.key);

				switch 
					(k.VALUE.CompareTo(((Key)subarvore.key[find]).VALUE))
				{
					case 0:
						//Casos em que o n� achado possui filhos
						if ( subarvore.pointer.Count != 0)
						{
							//elemento mais a direita do filho a esquerda
							Key _morerigth = findMoreRigth((B)subarvore.pointer[find]);

							//Substitui o elemento a ser deletado pelo mais a direita do filho a esquerda
							subarvore.key.RemoveAt(find);
							subarvore.key.Insert(find, _morerigth);

							//Deleta o mais a direita do filho a esquerda
							deleteKey((Key)_morerigth, ((B)subarvore.pointer[find]));	
							redistribuction(find, subarvore);
					
						}//if
						else //Casos em que o n� achado N�O possui filhos
						{
							subarvore.key.RemoveAt(find);
						}//else

						break;

					case 1:
						if (subarvore.pointer.Count>0)
						{
							//Procura no n� da direita referenciado pelo ponteiro da direita
							deleteKey(k,(B)subarvore.pointer[find+1]);
							redistribuction(find, subarvore);
						}
						break;
					case -1:
						if (subarvore.pointer.Count>0)
						{
							deleteKey(k,(B)subarvore.pointer[find]);
							redistribuction(find, subarvore);
						}
						break;
				}//switch
			}//if no diferente de vazio
			return true;
		}//deleteB

		//M�todos para manter as propriedades das �rvores
		#region

		/// <summary>
		/// Metodo para reestruturar a �rvore ap�s um underflow.
		/// </summary>
		/// <param name="find">Posi��o em que houve o underflow</param>
		/// <param name="subarvore">Arvore onde houve o underflow</param>
		private void redistribuction(int find, B subarvore)
		{
			// Verifica se o filho da esquerda tem um n�mero m�nimo de chaves
			// menos que o limite, e o da direita maior.
			if(((B)subarvore.pointer[find]).key.Count < MINKEY && 
				((B)subarvore.pointer[find+1]).key.Count > MINKEY)
			{
				// Adiciona a primeira chave do n� filho da direita no pai.
				((B)subarvore.pointer[find]).key.Add(subarvore.key[find]);
				// Verifica se o n� filho da esquerda tem filhos
				if (((B)subarvore.pointer[find]).pointer.Count > 0 )
				{
					// Passa a chave para irm�o da esquerda.
					((B)subarvore.pointer[find]).pointer.Add(((B)subarvore.pointer[find+1]).pointer[0]);
					((B)subarvore.pointer[find+1]).pointer.RemoveAt(0);
				}
				// Insere a chave no pai.
				subarvore.key.Insert(find,((B)subarvore.pointer[find+1]).key[0]);
				// Remove elemento que foi para o pai.
				subarvore.key.RemoveAt(find+1);
				((B)subarvore.pointer[find+1]).key.RemoveAt(0);
			}
			// Verifica se o filho da direita tem um n�mero m�nimo de chaves
			// menos que o limite, e o da direita maior.
			else if(((B)subarvore.pointer[find]).key.Count > MINKEY && 
				((B)subarvore.pointer[find+1]).key.Count < MINKEY)
			{
				// Adiciona a primeira chave do n� filho da direita no pai.
				((B)subarvore.pointer[find+1]).key.Insert(0,subarvore.key[find]);
				// Verifica se o n� filho da direita tem filhos
				if (((B)subarvore.pointer[find+1]).pointer.Count > 0 )
				{
					// Passa a chave para irm�o da direita.
					((B)subarvore.pointer[find+1]).pointer.Insert(0,((B)subarvore.pointer[find]).pointer[((B)subarvore.pointer[find]).pointer.Count-1]);
					((B)subarvore.pointer[find]).pointer.RemoveAt(((B)subarvore.pointer[find]).pointer.Count-1);
				}
				// Insere a chave no pai.
				subarvore.key.Insert(find,((B)subarvore.pointer[find]).key[((B)subarvore.pointer[find]).key.Count-1]);
				// Remove elemento que foi para o pai.
				subarvore.key.RemoveAt(find+1);
				((B)subarvore.pointer[find]).key.RemoveAt(((B)subarvore.pointer[find]).key.Count-1);
			}
			// Verifica se a quantidade de chaves da esquerda � menor que a ordem e n�o-nulo,
			// e o da direita � maior que o m�nimo.
			else if ( (find > 1 )&&
				((B)subarvore.pointer[find]).key.Count<MINKEY && 
				(!((B)subarvore.pointer[find-1]).Equals(null) && ((B)subarvore.pointer[find-1]).key.Count > MINKEY))
			{
				// Insere na primeira posi��o do filho a direita a chave do p�gina,
				// e preence o local com o �ltimo elemento do filho a esquerda.
				((B)subarvore.pointer[find]).key.Insert(0,(subarvore.key[find-1]));
				subarvore.key.Insert(find-1,((B)subarvore.pointer[find-1]).key[((B)subarvore.pointer[find-1]).key.Count-1]);
				subarvore.key.RemoveAt(find);
				((B)subarvore.pointer[find-1]).key.RemoveAt(((B)subarvore.pointer[find-1]).key.Count-1);
			}
			// Verifica se o filho a esquerda � igual ao m�nimo e se o filho a direta �
			// menor que o m�nimo, ou se o filho a direita � igual ao m�nimo e se o filho
			// a esquerda � menor que o m�nimo. 
			else if(((B)subarvore.pointer[find]).key.Count == MINKEY && 
				((B)subarvore.pointer[find+1]).key.Count < MINKEY
				||((B)subarvore.pointer[find]).key.Count<MINKEY && 
				((B)subarvore.pointer[find+1]).key.Count==MINKEY)
			{
				// Concatena os filhos com o elemento do pai
				((B)subarvore.pointer[find]).key.Add(subarvore.key[find]);
				
				// Adiciona os ponteiros novamente.
				for (int i = 0;i<((B)subarvore.pointer[find+1]).key.Count;i++)
				{
					((B)subarvore.pointer[find]).key.Add(((B)subarvore.pointer[find+1]).key[i]);
				}
				// Adiciona os ponteiros do outro n�
				for (int i = 0;i<((B)subarvore.pointer[find+1]).pointer.Count;i++)
				{
					((B)subarvore.pointer[find]).pointer.Add(((B)subarvore.pointer[find+1]).pointer[i]);
				}
				// Remove a chave que desceu para os filhos
				subarvore.key.RemoveAt(find);
				subarvore.pointer.RemoveAt(find+1);
				// Se for igual ao root, a p�gina pode ter o no. de chaves igual a 1.
				if(subarvore.Equals(root) && subarvore.key.Count == 0)
				{
					// Insere elementos no root.
					root.key.InsertRange(0,((B)subarvore.pointer[find]).key);
					root.pointer.InsertRange(find,((B)subarvore.pointer[find]).pointer);
					//remove a ultima posicao que era a inicial e foi empurrada pra frente
					root.pointer.RemoveAt(root.pointer.Count-1);
				}
			}//if
		}//redistribuction
		
		/// <summary>
		/// Metodo para reestruturar a �rvore ap�s um overflow.
		/// </summary>
		/// <param name="no">P�gina onde houve o overflow</param>
		private bool estouro(B no)
		{
			// Quantidade de chaves da pagina
			int count = no.key.Count;
			// Cria novas refer�ncias
			B newPageEsquerda = new B();
			B newPageDireita = new B();
			//Preenche os dois novos n�s
			newPageEsquerda.key.AddRange(no.key.GetRange(0,no.key.Count/2));
			newPageDireita.key.AddRange(no.key.GetRange((no.key.Count+1)/2,no.key.Count-(no.key.Count+1)/2));
			//Adiciona no n� atual o elemento vai subir e coloca na primeira posi��o
			no.key[0] = no.key[no.key.Count/2];
			no.key.RemoveRange(1,no.key.Count-1);
			// Verifica se se h� ponteiros
			if (!no.pointer.Count.Equals(0))
			{
				// Adi��o dos ponteiros nas novas refer�ncias criadas.
				for (int i=0; i <= newPageEsquerda.key.Count; i++)
				{
					newPageEsquerda.pointer.Add(no.pointer[i]);
					newPageDireita.pointer.Add(no.pointer[newPageEsquerda.key.Count + 1 + i ]);
				}
				// Remove todos os ponteiros do n� pai
				no.pointer.RemoveRange(0,no.pointer.Count);
			}
			// O pai passa a refer�nciar as duas p�ginas
			no.pointer.Add(newPageEsquerda);
			no.pointer.Add(newPageDireita);

			return true;

		}//Estouro

		/// <summary>
		/// M�todo que busca a chave mais a direita do filho a esquerda.
		/// </summary>
		/// <param name="subarvore">Pagina onde se busca</param>
		/// <returns>Chave procurada</returns>
		private Key findMoreRigth(B subarvore)
		{
			// Vari�vel de retorno.
			Key more_rigth = null;
			//verifica se tem filhos a direita
			if(subarvore.pointer.Count != 0)
			{
				more_rigth = findMoreRigth((B)subarvore.pointer[subarvore.pointer.Count-1]);
			}
			else
			{
				more_rigth = (Key)subarvore.key[subarvore.key.Count -1];
			}
			return more_rigth;
		
		}

		#endregion

		private AbstractTree searchKey(Key k, AbstractTree _subarvore )
		{
			B subarvore = (B)_subarvore;
			AbstractTree retorno = null;

			//Verificar se arvore vazia 
			if (!subarvore.key.Count.Equals(0))
			{	
				//Procura no no atual e retorna o indice onde a chave est� ou deveria estar
				int find = subarvore.searchNo(k,subarvore.key);

				switch (k.VALUE.CompareTo(((Key)subarvore.key[find]).VALUE))
				{
					case 0:
						retorno = this;
						break;
					case 1:
						if (subarvore.pointer.Count>0)
						{
							//Procura no n� da direita referenciado pelo ponteiro da direita
							retorno = searchKey((Key)k,(AbstractTree)subarvore.pointer[find+1]);
						}
						break;
					case -1:
						if (subarvore.pointer.Count>0)
						{
							retorno = searchKey((Key)k,(AbstractTree)subarvore.pointer[find]);
						}
						break;
				}//switch
			}//if no diferente de vazio
			return retorno;
		
		}
		//*********   M�todos para dentro dos N�s   **********\\
		#region

		//Procura dentro do array usando o m�todo de buscas Pesquisa Bin�ria
		private int searchNo(Key k, ArrayList key)
		{
			bool find = false;
			int begin = 0;
			int end = key.Count-1;
			int half = end/2;
			int retorno = 0;

			while (begin <= end && !find )
			{

				half = (end+begin)/2;
			
				int compval = k.VALUE.CompareTo(((Key)key[half]).VALUE);
				
				if (compval == 0)
				{
					find = true;
					retorno =  half;//retorna o indice onde se encontra a chave desejada - Chave j� existe
					break;
				}
				else if (compval > 0)
				{
					begin = half + 1;
				}
				else 
				{
					end = half - 1;
				}
				
			}//while

			if(find == false )
			{
				retorno = half;//retorna a ultima posicao chegada.
			}
			return retorno;

		}//SerchNo

		
		// Insere uma chave na p�gina de forma ordenada
		private void insereOrdenadoNo(Key key , B no)
		{
			//a insercao ocorre do final para o inicio
			int i = no.key.Count -1;

			while (i>=0)
			{
				Key k = (Key)key;
				int compval = k.VALUE.CompareTo(((Key)no.key[i]).VALUE);

				if(compval == 0)
				{
					break;//n�o reinsere
				}
				else if(compval > 0)
				{
					no.key.Insert(i+1,key);
					break;//sai do while
				}
				else 
				{
					i--;
					if (i==-1)
					{
						no.key.Insert(i+1,key);
					}
				}
			}//while
		}//unsereOrdenadoNo
		#endregion
	}
}
