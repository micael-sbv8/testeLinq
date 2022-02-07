// See https://aka.ms/new-console-template for more information
using System.Linq;
using TesteLinq.Entitie;

Console.WriteLine("TESTE DE CONSULTAS LINQ");
Console.WriteLine("");

var listProduto = new List<Produto>()
{
    new Produto { Id = 1, Nome = "Celula", Preco = 1500.00, CategoriaId = 1 },
    new Produto { Id = 2, Nome = "geladeira", Preco = 3000.00, CategoriaId = 1 },
    new Produto { Id = 3, Nome = "sofa", Preco = 1500.00, CategoriaId = 2 },
    new Produto { Id = 4, Nome = "cama", Preco = 4000.00, CategoriaId = 2 },
    new Produto { Id = 5, Nome = "tv", Preco = 3500.00, CategoriaId = 1 },
    new Produto { Id = 6, Nome = "arroz", Preco = 20.00, CategoriaId = 3 },
    new Produto { Id = 7, Nome = "feijão", Preco = 15.00, CategoriaId = 3 }
};

var listCategoria = new List<Categoria>()
{
    new Categoria { Id = 1, Nome = "Eletronico" },
    new Categoria { Id = 2, Nome = "Moveis"},
    new Categoria { Id = 3, Nome = "Mercado"}
};
//-------selecionando produtos maiores que 3000 ordenando por categoriaId
/*var result = from prod1 in listProduto
             where prod1.Preco >= 3000.00
             orderby prod1.CategoriaId
             select prod1;*/

//------selecionar produtos ordenar por preço e depois agrupar pela categoria----------
/*var result = from prod in listProduto
             orderby prod.Preco
             select prod;

var resultado = result.GroupBy(x => x.CategoriaId).ToList();
*/
//-------------------------------------------------------------

//-------selecionando produto e categoria pelo idcategoria, ordenando pelo cat nome e criando objeto anonimo
var result = from prod in listProduto
             join cat in listCategoria
             on prod.CategoriaId equals cat.Id
             orderby cat.Nome
             select new { Produto = prod, Categoria = cat };

//foreach(var cat in result)
//{
    //Console.WriteLine(cat.Key);
    foreach (var prod in result) 
    {
        Console.WriteLine($"Produto: {prod.Produto.Nome} | Categoria: {prod.Categoria.Nome}");
    }
//}
