using eCommerce.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace eCommerce.Services
{
    public class ProdutoService 
    {
        private readonly IMongoCollection<Produto> _produtos;

        public ProdutoService(IEcommerceDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _produtos = database.GetCollection<Produto>(settings.ProdutoCollectionName);
        }

        public ProdutoService()
        {
        }

        public List<Produto> Get() =>
            _produtos.Find(produto => true).ToList();

        public Produto Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            var result = _produtos.Find<Produto>(produto => produto.Id == id).FirstOrDefault();
            return result;
        }

        public Produto Create(Produto produto)
        {
            if (string.IsNullOrEmpty(produto.Nome) || string.IsNullOrEmpty(produto.Descricao) || (produto.Preco <= 0))
            {
                return null;
            }
            if(produto.Nome.Length > 50 || produto.Descricao.Length > 200)
            {
                return null;
            }

            _produtos.InsertOne(produto);
            return produto;
        }
        public Produto Update(string id, Produto produtoIn) 
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(produtoIn.Nome) || string.IsNullOrEmpty(produtoIn.Descricao) || (produtoIn.Preco <= 0))
            {
                return null;
            }
            if(produtoIn.Nome.Length > 50 || produtoIn.Descricao.Length > 200)
            {
                return null;
            }

            _produtos.ReplaceOne(produto => produto.Id == id, produtoIn);
            return produtoIn;
        }
        public DeleteResult Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            var delete = _produtos.DeleteOne(produto => produto.Id == id);
            return delete;
        }
    }
}
