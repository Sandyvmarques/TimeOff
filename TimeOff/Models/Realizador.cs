namespace TimeOff.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

   
    public partial class Realizador
    {
        public Realizador()
        {
            Filmes = new HashSet<Filme>();
        }
        //chave primária 
        [Key]
        public int Id { get; set; }

        [Required]
        public string NomeRealizador { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)] //formata a data para aparecer Ano/Mês/Dia
        public DateTime DataNasc { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public String Biografia { get; set; }

        [Required]
        public String ImagemRealizador { get; set; }

        // especifica que um Realizador tem vários Filmes
        public virtual ICollection<Filme> Filmes { get; set; }
    }
}
