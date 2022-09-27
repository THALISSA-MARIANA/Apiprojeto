using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoApi.Models
{
    public class Candidatura
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Anuncio")]
        public int AnuncioId { get; set; }
        public Anuncio? Anuncio { get; set; }

        [ForeignKey("Candidato")]
        public int CandidatoId { get; set; }
        public Cadastro? Candidato { get; set; }

        public StatusEnum Status { get; set; }

        public ICollection<HistoricoCandidatura>? Historico { get; set; }
    }
}
