using System;

namespace Cadastro.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Cpf { get; set; }

    }
}
