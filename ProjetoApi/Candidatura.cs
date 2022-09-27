using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoApi
{
    public class Candidatura
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("TipoAnuncio")]
        public int AnuncioId { get; set; }
        public TipoAnuncio? Anuncio { get; set; }

        [ForeignKey("Candidato")]
        public int CandidatoId { get; set; }
        public Cliente? Candidato { get; set; }

        public Enum Status { get; set; }

        public ICollection<HistoricoCandidatura>? Historico { get; set; }
    }
}
