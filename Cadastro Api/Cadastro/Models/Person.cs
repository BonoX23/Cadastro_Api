using System;
using System.Reflection.PortableExecutable;

namespace Cadastro.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cpf { get; set; }

        public void UpdatePerson(Person person)
        {
            Name = person.Name;
            Genre = person.Genre;
            BirthDate = person.BirthDate;
            Cpf = person.Cpf;
        }
    }
}
