using System;

class NAutor {
  private Autor[] autores = new Autor[10];
  private int nt;

  public Autor[] Listar() {
    Autor[] t = new Autor[nt];
    Array.Copy(autores, t, nt);
    return t;
  }

  public Autor Listar(int id) {
    for (int i = 0; i < nt; i++)
      if (autores[i].GetId() == id) return autores[i];
    return null;  
  }

  public void Inserir(Autor t) {
    if (nt == autores.Length) {
      Array.Resize(ref autores, 2 * autores.Length);
    }
    autores[nt] = t;
    nt++;
  } 

  public void Atualizar(Autor t) {
    // Localizar no vetor o autor que possui o id informado no parametro Autor
    Autor t_atual = Listar(t.GetId());
    if (t_atual == null) return;
    // Alterar os dados do autor(a)
    t_atual.SetDescricao(t.GetDescricao());
  } 

  private int Indice(Autor t) {
    for (int i = 0; i < nt; i++)
      if (autores[i] == t) return i;
    return -1;      
  }

  public void Excluir(Autor t) {
    // Verifica se o autor(a) está cadastrado(a)
    int n = Indice(t);
    if (n == -1) return;
    for (int i = n; i < nt - 1; i++)
      autores[i] = autores[i + 1];
    nt--;
    // Recuperar a lista de livros do(a) autor(a)
    Livro[] ls = t.LivroListar();
    foreach(Livro l in ls) l.SetAutor(null); 
  } 

}