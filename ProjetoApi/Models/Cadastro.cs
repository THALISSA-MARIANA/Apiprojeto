using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoApi.Models
{
    public class Cadastro
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }

        [MaxLength(10)]
        public string Senha { get; set; }

        public DateTime DataDeNascimento { get; set; }

        [MaxLength(80)]
        public string Email { get; set; }

        [MaxLength(10)]
        public string Cep { get; set; }

        [MaxLength(40)]
        public string Logradouro { get; set; }

        public int Numero { get; set; }

        [MaxLength(40)]
        public string Complemento { get; set; }
        [MaxLength(40)]
        public string Bairro { get; set; }
        [MaxLength(40)]
        public string Cidade { get; set; }

        public UfEnum UF { get; set; }
        [MaxLength(1)]
        public string Sexo { get; set; }

        [MaxLength(18)]
        public string RG { get; set; }
        [MaxLength(18)]
        public string CPF { get; set; }
        [MaxLength(10)]
        public string OrgaoExpedidor { get; set; }

        public bool CNH { get; set; }

        public bool Fumante { get; set; }

        public bool CursoCuidador { get; set; }

        public int CargaHoraria { get; set; }

        //  public ICollection<>? EscolhaCursos { get; set; }

        public int CorenEnfermagem { get; set; }

        public ICollection<Anuncio>? Anuncios { get; set; }
        public ICollection<Candidatura>? Candidaturas { get; set; }
    }
}
