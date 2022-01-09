using System;

class NGenero {
  private Genero[] generos = new Genero[10];
  private int ng;

  public Genero[] Listar() {
    Genero[] g = new Genero[ng];
    Array.Copy(generos, g, ng);
    return g;
  }

  public Genero Listar(int id) {
    for (int i = 0; i < ng; i++)
      if (generos[i].GetId() == id) return generos[i];
    return null;  
  }

  public void Inserir(Genero g) {
    if (ng == generos.Length) {
      Array.Resize(ref generos, 2 * generos.Length);
    }
    generos[ng] = g;
    ng++;
  } 

  public void Atualizar(Genero g) {
    // Localizar no vetor o genero que possui o id informado no parametro Genero
    Genero g_atual = Listar(g.GetId());
    if (g_atual == null) return;
    // Alterar os dados do genero
    g_atual.SetDescricao(g.GetDescricao());
  } 

  private int Indice(Genero g) {
    for (int i = 0; i < ng; i++)
      if (generos[i] == g) return i;
    return -1;      
  }

  public void Excluir(Genero g) {
    // Verifica se o genero está cadastrada
    int n = Indice(g);
    if (n == -1) return;
    for (int i = n; i < ng - 1; i++)
      generos[i] = generos[i + 1];
    ng--;
    // Recuperar a lista de livros do genero
    Livro[] ls = g.LivroListar();
    foreach(Livro l in ls) l.SetGenero(null); 
  } 

}