/* codigo é gerado quando o produto é cadastrado, ELE NÃO É MOSTRADO NO TERMINAL, o numero do codigo é de acordo com a ordem do cadastro ex:
primeiro produto cadastrado - codigo 1
Segundo produto cadastrado - codigo 2 
e assim por diante
*/

using System;

public class Produto
{
    public int Codigo;
    public string Descricao;
    public decimal PrecoCompra;
    public decimal PrecoVenda;
    public int Estoque;
}

class Program
{
    const int MAX_PRODUTOS = 500;

    static Produto[] produtos = new Produto[MAX_PRODUTOS];
    static int quantidadeProdutos = 0;
    static int proximoCodigo = 1;
  
    static void Main()
    {
        int opcao = 0;

        do
        {
            Console.Clear();
 
            Console.WriteLine("=================================");
            Console.WriteLine("Loja de Brinquedos");
            Console.WriteLine("=================================");
            Console.WriteLine("1 - Cadastrar Produto");
            Console.WriteLine("2 - Frente de Caixa");
            Console.WriteLine("3 - Consultar Estoque");
            Console.WriteLine("4 - Entrada de Produtos");
            Console.WriteLine("5 - Listagem de Produtos");
            Console.WriteLine("6 - Sair");
            Console.Write("Escolha uma opção: ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                CadastrarProduto();
                break;

                case 2:
                FrenteDeCaixa();
                break;

               case 3:
               ConsultarEstoque();
               break;

               case 4:
               EntradaProdutos();
               break;

               case 5:
               ListarProdutos();
               break;

               case 6:
               Console.WriteLine("Encerrando...");
               break;

               default:
               Console.WriteLine("Opção inválida.");
               break;
            }

            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        
        }while (opcao != 6);
    }

    static int BuscarProduto(int codigoBuscado)
    {
        for (int i = 0; i < quantidadeProdutos; i++)
        {
            if (produtos[i].Codigo == codigoBuscado)
            {
                return i;
            } 
        }
        return -1;
    }

    static void CadastrarProduto()
    {
        if (quantidadeProdutos >= MAX_PRODUTOS)
        {
            Console.WriteLine("Limite Maximo Atingido");
            return;
        }

        Produto produto = new Produto();

        produto.Codigo = proximoCodigo++;

        Console.Write("Descrição:");
        produto.Descricao = Console.ReadLine();

        Console.Write("Preço de Compra:");
        produto.PrecoCompra = decimal.Parse(Console.ReadLine());

        Console.Write("Preço de Venda:");
        produto.PrecoVenda = decimal.Parse(Console.ReadLine());

        Console.Write("Quantidade em Estoque:");
        produto.Estoque = int.Parse(Console.ReadLine());

        produtos[quantidadeProdutos] = produto;
        quantidadeProdutos++;

        Console.WriteLine("Produto cadastrado com sucesso");
    }

    static void FrenteDeCaixa()
    {
        decimal totalCompra = 0;
        while (true)
    {
        Console.Write("Código do produto (0 para finalizar): ");
        int codigo = int.Parse(Console.ReadLine());

        if (codigo == 0)
            break;

        int posicao = BuscarProduto(codigo);

        if (posicao == -1)
        {
            Console.WriteLine("Código inexistente.");
            continue;
        }

        Produto produto = produtos[posicao];

        if (produto.Estoque <= 0)
        {
            Console.WriteLine("Produto sem estoque.");
            continue;
        }

        produto.Estoque--;

        Console.WriteLine($"Código: {produto.Codigo}");
        Console.WriteLine($"Descrição: {produto.Descricao}");
        Console.WriteLine($"Preço de Venda: R$ {produto.PrecoVenda:F2}");

        totalCompra += produto.PrecoVenda;
    }

    Console.WriteLine($"Valor Total da Compra: R$ {totalCompra:F2}");
    }

  
    static void ConsultarEstoque()
    {
        Console.Write("Informe o código do produto: ");
        int codigo = int.Parse(Console.ReadLine());
        int posicao = BuscarProduto(codigo);

        if (posicao == -1)
        {
            Console.WriteLine("Código inexistente.");
            return;
        }

        Produto produto = produtos[posicao];

        Console.WriteLine("=== Dados do Produto ===");
        Console.WriteLine($"Código: {produto.Codigo}");
        Console.WriteLine($"Descrição: {produto.Descricao}");
        Console.WriteLine($"Preço de Compra: R$ {produto.PrecoCompra:F2}");
        Console.WriteLine($"Preço de Venda: R$ {produto.PrecoVenda:F2}");
        Console.WriteLine($"Estoque: {produto.Estoque}");
    }


    static void EntradaProdutos()
    { 
        Console.Write("Código do produto: ");
        int codigo = int.Parse(Console.ReadLine());
        int posicao = BuscarProduto(codigo);
        if (posicao == -1)
        {
            Console.WriteLine("Código inexistente.");
            return;
        }

        Produto produto = produtos[posicao];

        Console.Write("Quantidade adquirida: ");
        int quantidade = int.Parse(Console.ReadLine());

        Console.Write("Novo preço de compra: ");
        produto.PrecoCompra = decimal.Parse(Console.ReadLine());

        Console.Write("Novo preço de venda: ");
        produto.PrecoVenda = decimal.Parse(Console.ReadLine());

        produto.Estoque += quantidade;

        Console.WriteLine("Produto atualizado com sucesso!");
    }


    static void ListarProdutos()
    {
        if (quantidadeProdutos == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        Console.WriteLine("\n=== LISTA DE PRODUTOS ===");

        for (int i = 0; i < quantidadeProdutos; i++)
        {
            Produto produto = produtos[i];

            Console.WriteLine("----------------------------");
            Console.WriteLine($"Código: {produto.Codigo}");
            Console.WriteLine($"Descrição: {produto.Descricao}");
            Console.WriteLine($"Preço Compra: R$ {produto.PrecoCompra:F2}");
            Console.WriteLine($"Preço Venda: R$ {produto.PrecoVenda:F2}");
            Console.WriteLine($"Estoque: {produto.Estoque}");
        }
    }
}