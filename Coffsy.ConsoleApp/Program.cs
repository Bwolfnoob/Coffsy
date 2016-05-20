using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Entity;
using Coffsy.ConsoleApp.Entities;

namespace Coffsy.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            ListDapper();
            //   ListEF();


            Console.ReadKey();
        }

        private static void InsertEF(string suff)
        {
            for (int i = 0; i < 100000; i++)
            {
                using (var dbCtx = new CoffsyContext())
                {
                    dbCtx.Produtos.Add(new Entities.Produto("Produto " + suff + i, "Descricao a" + i));
                    dbCtx.SaveChanges();
                }
            }
            Console.WriteLine("Fim Insert 10000 " + suff);
        }

        private static void ListEF()
        {
            Console.WriteLine("Inicio EF");
            using (var dbCtx = new CoffsyContext())
            {
                Console.WriteLine(dbCtx.Produtos.ToList().Count());
            }
            Console.WriteLine("Fim EF");
        }

        private static void ListDapper()
        {
            Console.WriteLine("Inicio Dapper");
            try
            {

                SqlConnection conexao = new SqlConnection(@"Data Source=localhost\sqlexpress;Initial Catalog=ALLTADM;Integrated Security=True");

                conexao.Open();

                var dados = conexao.Query<Produto, Projeto, Produto>(@"select * from Produto a
                                                     INNER JOIN Projeto p on p.ProjetoId = a.Projeto_ProjetoId
                                                     where ProdutoId = '2'", (a, s) =>
                {
                    a.Projeto = s;
                    return a;
                },
                     splitOn: "ProjetoId");

                Console.WriteLine("Novo:" + dados.Count());

                conexao.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro =" + e.Message);
            }
            Console.WriteLine("Fim Dapper");
        }
    }
}
