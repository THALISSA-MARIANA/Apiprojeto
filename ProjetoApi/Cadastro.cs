using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoApi
{
    public class Cadastro
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Cliente")]

        public int ClienteId { get; set; }

        public string Nome { get; set; }

        public int idade { get; set; }

        public string E-mail { get; set; }

        public int Cep { get; set; }

         public string Logradouro { get; set; }

         public int Numero { get; set; }

         public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public ICollection<>? UF { get; set; }

        public bool Sexo { get; set; }

        public int RG { get; set; }

        public int CPF { get; set; }

        public ICollection<>? Orgao Expedidor{ get; set; }

        public bool CNH { get; set; }

        public bool Fumante { get; set; }

        public bool CursoCuidador { get; set; }

        public int CargaHoraria { get; set; }

        public ICollection<>? EscolhaCursos { get; set; }

        public int CorenEnfermagem { get; set; }
    }
}
