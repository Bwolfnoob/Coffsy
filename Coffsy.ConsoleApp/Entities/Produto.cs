using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffsy.ConsoleApp.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string  Nome { get; set; }
        public string Descricao { get; set; }
        public Projeto Projeto { get; set; }

        public DateTime DataCadastro { get; set; }

        private Produto()
        {

        }

        public Produto( string nome , string descricao)
        {
            Nome = nome;
            Descricao = descricao;
            DataCadastro = DateTime.Now;
        }
    }
}
