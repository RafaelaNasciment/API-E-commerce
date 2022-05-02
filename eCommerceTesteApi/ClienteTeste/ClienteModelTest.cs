using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceTesteApi.ClienteTeste
{
     public class ClienteModelTest
     {
            public ClienteModelTest(string nome, bool ativo)
            {
                Id = Guid.NewGuid().ToString();
                Nome = nome;
                Ativo = ativo;
            }

            //[BsonId]
            public string Id { get; set; }

            public string Nome { get; set; }

            public bool Ativo { get; set; }
     }
}

