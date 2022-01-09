using System;

class Genero {
  private int id;
  private string descricao;
  private Livro[] livros = new Livro[10];
  private int nl;
  public Genero(int id, string descricao) {
    this.id = id;
    this.descricao = descricao;
  }
  public void SetId(int id) {
    this.id = id;
  }
  public void SetDescricao(string descricao) {
    this.descricao = descricao;
  }
  public int GetId() {
    return id;
  }
  public string GetDescricao() {
    return descricao;
  }
  public Livro[] LivroListar() {
    Livro[] g = new Livro[nl];
    Array.Copy(livros, g, nl);
    return g;
  }
  public void LivroInserir(Livro l) {
    if (nl == livros.Length) {
      Array.Resize(ref livros, 2 * livros.Length);
    }
    livros[nl] = l;
    nl++;
  }
  public override string ToString() {
    return id + " - " + descricao + " - Nº livros: " + nl;
  }
}