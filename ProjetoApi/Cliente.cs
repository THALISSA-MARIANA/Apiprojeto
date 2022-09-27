using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoApi
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public ICollection<Cadastro>? Cadastro { get; set; }
        public ICollection<TipoAnuncio>? Anuncios { get; set; }
        public ICollection<Candidatura>? Candidaturas { get; set; }
    }
}
