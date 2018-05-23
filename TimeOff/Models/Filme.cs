namespace TimeOff.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Filme
    {
        public Filme()
        {
            Comentarios = new HashSet<Comentarios>();
            Categorias = new HashSet<Categorias>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Sinopse { get; set; }

        public int AnoLanc { get; set; }

        public string LinkTrailer { get; set; }

        [ForeignKey("Realizadores")]
        public int RealizadorId { get; set; }

        public virtual Realizador Realizadores { get; set; }

        public virtual ICollection<Comentarios> Comentarios { get; set; }

        public virtual ICollection<Categorias> Categorias { get; set; }

        public virtual ICollection<Imagens> Imagens { get; set; }
    }
}
