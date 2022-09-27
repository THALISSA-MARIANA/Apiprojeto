using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProjetoApi.Models
{
    public class Anuncio
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Anunciante")]
        public int AnuncianteId { get; set; }
        public Cadastro? Anunciante { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public ICollection<Candidatura>? Candidaturas { get; set; }
    }
}
