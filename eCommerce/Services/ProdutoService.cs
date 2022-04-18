using eCommerce.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace eCommerce.Services
{
    public class ProdutoService 
    {
        private readonly IMongoCollection<Produto> _produtos;

        public ProdutoService(IProdutoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _produtos = database.GetCollection<Produto>(settings.ProdutoCollectionName);
        }
        
        //Get All
        public List<Produto> Get() =>
            _produtos.Find(produto => true).ToList();

        //GetById

        public Produto Get(int id) =>
            _produtos.Find<Produto>(produto => produto.Id == id).FirstOrDefault();

        //Criando um novo

        public Produto Create (Produto produto)
        {
            _produtos.InsertOne(produto);
            return produto;
        }

        //Atualizando

        public void Update(int id, Produto produtoIn) =>
            _produtos.ReplaceOne(produto => produto.Id == id, produtoIn);

        //Deletar ou remover um produto

        public void Remove(Produto produtoIn) =>
            _produtos.DeleteOne(produto => produto.Id == produtoIn.Id);

        public void Remove(int id) =>
            _produtos.DeleteOne(produto => produto.Id == id);

    }
}
