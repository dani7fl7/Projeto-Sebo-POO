using System;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System.Linq;


class NGenero {
  private NGenero() {}
  static NGenero obj = new NGenero();
  public static NGenero Singleton { get => obj; }
    
  private Genero[] generos = new Genero[10];
  private int ng;


  public void Abrir() {
    Arquivo<Genero[]> f = new Arquivo<Genero[]>();
    generos = f.Abrir("./generos.xml");
    ng = generos.Length;
  }

  public void Salvar() {
    Arquivo<Genero[]> f = new Arquivo<Genero[]>();
    f.Salvar("./generos.xml", Listar());
  }
  

  public Genero[] Listar() {
    return 
      generos.Take(ng).OrderBy(obj => obj.GetDescricao()).ToArray();
  }

  public Genero Listar(int id) {
    /*for (int i = 0; i < ng; i++)
      if (generos[i].GetId() == id) return generos[i];
    return null;  */
    var r = generos.Where(obj => obj.GetId() == id);
    if (r.Count() == 0) return null;
    return r.First();
  }

  public void Inserir(Genero g) {
    if (ng == generos.Length) {
      Array.Resize(ref generos, 2 * generos.Length);
    }
    generos[ng] = g;
    ng++;
  } 

  public void Atualizar(Genero g) {
    Genero g_atual = Listar(g.GetId());
    if (g_atual == null) return;
    g_atual.SetDescricao(g.GetDescricao());
  } 

  private int Indice(Genero g) {
    for (int i = 0; i < ng; i++)
      if (generos[i] == g) return i;
    return -1;      
  }

  public void Excluir(Genero g) {
    int n = Indice(g);
    if (n == -1) return;
    for (int i = n; i < ng - 1; i++)
      generos[i] = generos[i + 1];
    ng--;
    Livro[] ls = g.LivroListar();
    foreach(Livro l in ls) l.SetGenero(null); 
  } 

}