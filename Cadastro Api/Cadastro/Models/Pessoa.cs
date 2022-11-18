using System;
using System.Reflection.PortableExecutable;

namespace Cadastro.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Cpf { get; set; }

        public void UpdatePessoa(Pessoa pessoa)
        {
            Nome = pessoa.Nome;
            Sexo = pessoa.Sexo;
            DataDeNascimento = pessoa.DataDeNascimento;
            Cpf = pessoa.Cpf;
        }
    }
}
