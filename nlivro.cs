using System;

class NLivro {
  private Livro[] livros = new Livro[10];
  private int nl;

  public Livro[] Listar() {
    Livro[] l = new Livro[nl];
    Array.Copy(livros, l, nl);
    return l;
  }

  public Livro Listar(int id) {
    for (int i = 0; i < nl; i++)
      if (livros[i].GetId() == id) return livros[i];
    return null;  
  }

  public void Inserir(Livro l) {
    if (nl == livros.Length) {
      Array.Resize(ref livros, 2 * livros.Length);
    }
    livros[nl] = l;
    nl++;
    // Recuperar a Genero do livro que está sendo inserido
    Genero g = l.GetGenero();
    if (g != null) g.LivroInserir(l);

    // Recuperar a Genero do livro que está sendo inserido
    Autor t = l.GetAutor();
    if (t != null) t.LivroInserir(l);


  } 

}