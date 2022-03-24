using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Linq;

class MainClass {
  private static NGenero ngenero = NGenero.Singleton;
  private static NAutor nautor = NAutor.Singleton;
  private static NLivro nlivro = NLivro.Singleton;
  private static NCliente ncliente = NCliente.Singleton;
  private static NVenda nvenda = NVenda.Singleton;

  
  private static Cliente clienteLogin = null;
  private static Venda clienteVenda = null;
  
  public static void Main() {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

    try {
      ngenero.Abrir();
      nautor.Abrir();
      nlivro.Abrir();
      ncliente.Abrir();
      nvenda.Abrir();
    }
    catch(Exception erro) {
      Console.WriteLine(erro.Message);
    }
    
    
    int ol = 0;
    int perfil = 0;
    Console.WriteLine ("----- Sebo Virtual de Livros ------");
    do {
      try {
        if (perfil == 0) {
          ol = 0;
          perfil = MenuUsuario();
        }

        if (perfil == 1) {
          ol = MenuVendedor();
          switch(ol) {
            case 1 : GeneroListar(); break;
            case 2 : GeneroInserir(); break;
            case 3 : GeneroAtualizar(); break;
            case 4 : GeneroExcluir(); break;
            case 5 : AutorListar(); break;
            case 6 : AutorInserir(); break;
            case 7 : AutorAtualizar(); break;
            case 8 : AutorExcluir(); break;
            case 9 : LivroListar(); break;
            case 10 : LivroInserir(); break;
            case 11 : LivroAtualizar(); break;
            case 12 : LivroExcluir(); break;
            case 13 : ClienteListar(); break;
            case 14 : ClienteInserir(); break;
            case 15 : ClienteAtualizar(); break;
            case 16 : ClienteExcluir(); break;
            case 17 : VendaListar(); break;
            case 99 : perfil = 0; break;
          }
        }

        if (perfil == 2 && clienteLogin == null) {
          ol = MenuClienteLogin();
          switch(ol) {
            case 1  : ClienteLogin(); break;
            case 99 : perfil = 0; break;
          }
        }
        if (perfil == 2 && clienteLogin != null) {
          ol = MenuClienteLogout();
          switch(ol) {
            case 1  : ClienteVendaListar(); break;
            case 2  : ClienteLivroListar(); break;
            case 3  : ClienteLivroInserir(); break;
            case 4  : ClienteCarrinhoVisualizar(); break;
            case 5  : ClienteCarrinhoLimpar(); break;
            case 6  : ClienteCarrinhoComprar(); break;
            case 99 : ClienteLogout(); break;
          }
        }
      }

      catch (Exception erro) {
        Console.WriteLine(erro.Message);
        ol = 100;
      }
    } while (ol != 0);
    try {
      ngenero.Salvar();
      nautor.Salvar();
      nlivro.Salvar();
      ncliente.Salvar();
      nvenda.Salvar();
    }
    catch(Exception erro) {
      Console.WriteLine(erro.Message);
    }
    Console.WriteLine ("Fim...");    
  }
  
  public static int MenuUsuario() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("1 - Entrar como Vendedor");
    Console.WriteLine("2 - Entrar como Cliente");
    Console.WriteLine("0 - Fim");
    Console.WriteLine("----------------------------------");
    Console.Write("Informe uma opção: ");
    int ol = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return ol; 
  }

  public static int MenuVendedor() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("1 - Genero - Listar");
    Console.WriteLine("2 - Genero - Inserir");
    Console.WriteLine("3 - Genero - Atualizar");
    Console.WriteLine("4 - Genero - Excluir");
    Console.WriteLine("5 - Autor - Listar");
    Console.WriteLine("6 - Autor - Inserir");
    Console.WriteLine("7 - Autor - Atualizar");
    Console.WriteLine("8 - Autor - Excluir");
    Console.WriteLine("9 - Livro - Listar");
    Console.WriteLine("10 - Livro - Inserir");
    Console.WriteLine("11 - Livro - Atualizar");
    Console.WriteLine("12 - Livro - Excluir");
    Console.WriteLine("13 - Cliente - Listar");
    Console.WriteLine("14 - Cliente - Inserir");
    Console.WriteLine("15 - Cliente - Atualizar");
    Console.WriteLine("16 - Cliente - Excluir");
    Console.WriteLine("17 - Cliente - Listar");
    Console.WriteLine("99 - Voltar");
    Console.WriteLine("0 - Fim");
    Console.WriteLine("----------------------------------");
    Console.Write("Informe uma opcao: ");
    int ol = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return ol; 
  }

  public static int MenuClienteLogin() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("01 - Login");
    Console.WriteLine("99 - Voltar");
    Console.WriteLine("0  - Fim");
    Console.WriteLine("----------------------------------");
    Console.Write("Informe uma opção: ");
    int ol = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return ol; 
  }

  public static int MenuClienteLogout() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("Bem vindo(a), " + clienteLogin.Nome);
    Console.WriteLine("----------------------------------");
    Console.WriteLine("01 - Listar minhas compras");
    Console.WriteLine("02 - Listar livros");
    Console.WriteLine("03 - Inserir um livro no carrinho");
    Console.WriteLine("04 - Visualizar o carrinho");
    Console.WriteLine("05 - Limpar o carrinho");
    Console.WriteLine("06 - Confirmar a compra");
    Console.WriteLine("99 - Logout");
    Console.WriteLine("0  - Fim");
    Console.WriteLine("----------------------------------");
    Console.Write("Informe uma opção: ");
    int ol = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return ol; 
  }







  public static void GeneroListar() {
    Console.WriteLine("----- Lista de Gêneros -----");
    Genero[] gs = ngenero.Listar();
    if (gs.Length == 0) {
      Console.WriteLine("Nenhum gênero cadastrado");
      return;
    }
    foreach(Genero g in gs) Console.WriteLine(g);
    Console.WriteLine();  
  }
  
  public static void GeneroInserir() {
    Console.WriteLine("----- Inserção de Gêneros -----");
    Console.Write("Informe um código para o gênero: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descricao = Console.ReadLine();
    // Instanciar a classe de Genero
    Genero g = new Genero(id, descricao);
    // Inserção do genero
    ngenero.Inserir(g);
  }
  public static void GeneroAtualizar() {
    Console.WriteLine("----- Atualização de Gêneros -----");
    GeneroListar();
    Console.Write("Informe um código para o gênero para alterar: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descricao = Console.ReadLine();
    // Instanciar a classe de Genero
    Genero g = new Genero(id, descricao);
    // Inserção do genero
    ngenero.Atualizar(g);
  }
  public static void GeneroExcluir() {
    Console.WriteLine("----- Exclusão de Generos -----");
    GeneroListar();
    Console.Write("Informe um código do gênero para excluir: ");
    int id = int.Parse(Console.ReadLine());
    // Procurar o genero com esse id
    Genero g = ngenero.Listar(id);
    // Exclui o genero do cadastro
    ngenero.Excluir(g);
  }


  public static void AutorListar() {
    Console.WriteLine("----- Lista de Autores -----");
    Autor[] ts = nautor.Listar();
    if (ts.Length == 0) {
      Console.WriteLine("Nenhum(a) autor(a) cadastrado(a)");
      return;
    }
    foreach(Autor t in ts) Console.WriteLine(t);
    Console.WriteLine();  
  }
  public static void AutorInserir() {
    Console.WriteLine("----- Inserção de Autores -----");
    Console.Write("Informe um código para o autor: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descricao = Console.ReadLine();
    // Instanciar a classe de Autor
    Autor t = new Autor(id, descricao);
    // Inserção do autor
    nautor.Inserir(t);
  }
  
  public static void AutorAtualizar() {
    Console.WriteLine("----- Atualização de Autores -----");
    AutorListar();
    Console.Write("Informe um código para o(a) autor(a) para alterar: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descricao = Console.ReadLine();
    // Instanciar a classe de Autor
    Autor t = new Autor(id, descricao);
    // Inserção do autor
    nautor.Atualizar(t);
  }
  public static void AutorExcluir() {
    Console.WriteLine("----- Exclusão de Autores -----");
    AutorListar();
    Console.Write("Informe um código do autor para excluir: ");
    int id = int.Parse(Console.ReadLine());
    // Procurar o(a) autor(a) com esse id
    Autor t = nautor.Listar(id);
    // Exclui o autor do cadastro
    nautor.Excluir(t);
  }






  public static void LivroListar() {
    Console.WriteLine("----- Lista de Livros -----");
    Livro[] ls = nlivro.Listar();
    if (ls.Length == 0) {
      Console.WriteLine("Nenhum livro cadastrado");
      return;
    }
    foreach(Livro l in ls) Console.WriteLine(l);
    Console.WriteLine();  
  }
  public static void LivroInserir() {
    Console.WriteLine("----- Inserção de Livros -----");
    Console.Write("Informe um código para o livro: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descricao = Console.ReadLine();
    Console.Write("Informe o estoque do livro: ");
    int quantidade = int.Parse(Console.ReadLine());
    Console.Write("Informe o preço do livro: ");
    double preco = double.Parse(Console.ReadLine());


    GeneroListar();
    Console.Write("Informe o código do genero do livro: ");
    int idgenero = int.Parse(Console.ReadLine());

    AutorListar();
    Console.Write("Informe o código do autor do livro: ");
    int idautor = int.Parse(Console.ReadLine());


    Genero g = ngenero.Listar(idgenero);    
   
    Autor t = nautor.Listar(idautor); 

    Livro l = new Livro(id, descricao, quantidade, preco, g, t);

    nlivro.Inserir(l);
  }
  public static void LivroAtualizar() {
    Console.WriteLine("----- Atualização de Livros -----");
    LivroListar();
    Console.Write("Informe o código do livro a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descricao = Console.ReadLine();
    Console.Write("Informe o estoque do livro: ");
    int quantidade = int.Parse(Console.ReadLine());
    Console.Write("Informe o preço do livro: ");
    double preco = double.Parse(Console.ReadLine());
    
    GeneroListar();
    Console.Write("Informe o código da genero do livro: ");
    int idgenero = int.Parse(Console.ReadLine());
    Genero g = ngenero.Listar(idgenero);

    AutorListar();
    Console.Write("Informe o código do autor do livro: ");
    int idautor = int.Parse(Console.ReadLine());
    Autor t = nautor.Listar(idautor);
    
    Livro l = new Livro(id, descricao, quantidade, preco, g, t);
    // Atualiza o livro
    nlivro.Atualizar(l);
  }
  public static void LivroExcluir() {
    Console.WriteLine("----- Exclusão de Livros -----");
    LivroListar();
    Console.Write("Informe o código do livro a ser excluído: ");
    int id = int.Parse(Console.ReadLine());
    // Procura o livro com esse id
    Livro l = nlivro.Listar(id);
    nlivro.Excluir(l);
  }


 public static void ClienteListar() {
    Console.WriteLine("----- Lista de Clientes -----");
    // Lista os clientes
    List<Cliente> cs = ncliente.Listar();
    if (cs.Count == 0) {
      Console.WriteLine("Nenhum cliente cadastrado");
      return;
    }
    foreach(Cliente c in cs) Console.WriteLine(c);
    Console.WriteLine();  
  }

  public static void ClienteInserir() {
    Console.WriteLine("----- Inserção de Clientes -----");
    Console.Write("Nome do(a) cliente: ");
    string nome = Console.ReadLine();
    Console.Write("Data de nascimento (dd/mm/aaaa): ");
    DateTime nasc = DateTime.Parse(Console.ReadLine());
    // Instancia a classe de cliente
    Cliente c = new Cliente { Nome = nome, Nascimento = nasc };
    // Insere o cliente
    ncliente.Inserir(c);
  }

  public static void ClienteAtualizar() {
    Console.WriteLine("----- Atualização de Clientes -----");
    GeneroListar();
    AutorListar();
    Console.Write("Código do cliente a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Nome do(a) cliente: ");
    string nome = Console.ReadLine();
    Console.Write("Data de nascimento (dd/mm/aaaa): ");
    DateTime nasc = DateTime.Parse(Console.ReadLine());
    // Instancia a classe de cliente
    Cliente c = new Cliente { Id = id, Nome = nome, Nascimento = nasc };
    // Atualiza o cliente
    ncliente.Atualizar(c);
  }

  public static void ClienteExcluir() {
    Console.WriteLine("----- Exclusão de Clientes -----");
    GeneroListar();
    AutorListar();
    Console.Write("Código do cliente a ser excluído: ");
    int id = int.Parse(Console.ReadLine());
    // Procura o cliente com esse id
    Cliente c = ncliente.Listar(id);
    // Exclui o cliente do cadastro
    ncliente.Excluir(c);
  }



  public static void VendaListar() { 
    Console.WriteLine("----- Lista de Vendas -----");
    // Listar as vendas cadastradas
    List<Venda> vs = nvenda.Listar();
    if (vs.Count == 0) {
      Console.WriteLine("Nenhuma venda cadastrada");
      return;
    }
    foreach(Venda v in vs) {
      Console.WriteLine(v);
      foreach (VendaItem item in nvenda.ItemListar(v))
        Console.WriteLine("  " + item);
    }    
    Console.WriteLine();

    var r1 = vs.Select(v => new {
      MesAno = v.Data.Month + "/" + v.Data.Year,
      Total  = v.Itens.Sum(vi => vi.Quantidade * vi.Preco)
    });

    foreach(var item in r1) Console.WriteLine(item);
    Console.WriteLine();

    var r2 = r1.GroupBy(item => item.MesAno,
      (key, items) => new {
        MesAno = key,
        Total = items.Sum(item => item.Total) });

    foreach(var item in r2) Console.WriteLine(item);
    Console.WriteLine();
  }


  

  public static void ClienteLogin() { 
    Console.WriteLine("----- Login do Cliente -----");
    ClienteListar();
    Console.Write("Informe o código do cliente para logar: ");
    int id = int.Parse(Console.ReadLine());
    // Procura o cliente com esse id
    clienteLogin = ncliente.Listar(id);
    clienteVenda = nvenda.ListarCarrinho(clienteLogin);
  }


  public static void ClienteLogout() { 
    Console.WriteLine("----- Logout do Cliente -----");
    if (clienteVenda != null) nvenda.Inserir(clienteVenda, true);
    clienteLogin = null;
    clienteVenda = null;
  }

  
  public static void ClienteVendaListar() { 
    Console.WriteLine("----- Minhas Compras -----");
    List<Venda> vs = nvenda.Listar(clienteLogin);
    if (vs.Count == 0) {
      Console.WriteLine("Nenhuma compra cadastrada");
      return;
    }
    foreach(Venda v in vs) {
      Console.WriteLine(v);
      foreach (VendaItem item in nvenda.ItemListar(v))
        Console.WriteLine("  " + item);
    }    
    Console.WriteLine();
  }
  
  public static void ClienteLivroListar() { 
    LivroListar();
  }
  
  public static void ClienteLivroInserir() { 
    LivroListar();
    Console.Write("Informe o código do livro a ser comprado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a quantidade: ");
    int quantidade = int.Parse(Console.ReadLine());
    Livro l = nlivro.Listar(id);
    if (l != null) {
      if (clienteVenda == null)
        clienteVenda = new Venda(DateTime.Now, clienteLogin);
      nvenda.ItemInserir(clienteVenda, quantidade, l);  
    }
  }
  
  public static void ClienteCarrinhoVisualizar() { 
    if (clienteVenda == null) {
      Console.WriteLine("Nenhum livro no carrinho");
      return;
    }
    List<VendaItem> itens = nvenda.ItemListar(clienteVenda);
    foreach(VendaItem item in itens) Console.WriteLine(item);
    Console.WriteLine();
  }
  
  public static void ClienteCarrinhoLimpar() { 
    if (clienteVenda != null)
      nvenda.ItemExcluir(clienteVenda);
  }
  
  public static void ClienteCarrinhoComprar() { 
    if (clienteVenda == null) {
      Console.WriteLine("Nenhum livro no carrinho");
      return;
    }
    nvenda.Inserir(clienteVenda, false);
    clienteVenda = null;
  }

}