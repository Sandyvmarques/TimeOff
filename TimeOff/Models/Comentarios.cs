namespace TimeOff.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comentarios
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Texto { get; set; }

        public DateTime Data { get; set; }

        [ForeignKey("Filmes")]
        public int FilmeId { get; set; }

        public virtual Filme Filmes { get; set; }

        [ForeignKey("Utilizadores")]
        public int UtilizadorId { get; set; }

        public virtual Utilizador Utilizadores { get; set; }
    }
}
