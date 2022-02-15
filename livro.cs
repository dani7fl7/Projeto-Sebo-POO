using System;

class Livro {
  private int id;
  private string descricao;
  private int quantidade;
  private double preco;
  private Genero genero;
  private Autor autor;
  public Livro(int id, string descricao, int quantidade, double preco) {
    this.id = id;
    this.descricao = descricao;
    this.quantidade = quantidade > 0 ? quantidade : 0;
    this.preco = preco > 0 ? preco : 0;
  }


  public Livro(int id, string descricao, int quantidade, double preco, Genero genero, Autor autor) : this(id, descricao, quantidade, preco) {
    this.genero = genero;
    this.autor = autor;
  }
  public void SetId(int id) {
    this.id = id;
  }
  public void SetDescricao(string descricao) {
    this.descricao = descricao;
  }
  public void SetQuantidade(int quantidade) {
    this.quantidade = quantidade > 0 ? quantidade : 0;
  }
  public void SetPreco(double preco) {
    this.preco = preco > 0 ? preco : 0;
  }
  public void SetGenero(Genero genero) {
    this.genero = genero;
  }


  public void SetAutor(Autor autor) {
    this.autor = autor;
  }



  public int GetId() {
    return id;
  }
  public string GetDescricao() {
    return descricao;
  }
  public int GetQuantidade() {
    return quantidade;
  }
  public double GetPreco() {
    return preco;
  }
  public Genero GetGenero() {
    return genero;
  }


  public Autor GetAutor() {
    return autor;
  }


  public override string ToString() {
    if (genero == null)
      return id + " - " + descricao + " - Estoque: " + quantidade + " - Preço: " + preco.ToString("0.00") + " - " + autor.GetDescricao();
    if (autor == null)
      return id + " - " + descricao + " - Estoque: " + quantidade + " - Preço: " + preco.ToString("0.00") + " - " + genero.GetDescricao();
    else  
      return id + " - " + descricao + " - Estoque: " + quantidade + " - Preço: " + preco.ToString("0.00") + " - " + autor.GetDescricao() + " - " + genero.GetDescricao();   
  }



  
}