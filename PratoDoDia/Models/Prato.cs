using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PratoDoDia.Models
{
    public partial class Prato
    {
        public Prato()
        {
            Venda = new HashSet<Venda>();
        }

        [Key]
        [Column("idPrato")]
        public int IdPrato { get; set; }
        [Required]
        [Column("nomePrato")]
        [StringLength(100)]
        public string NomePrato { get; set; }
        [Required]
        [Column("diaPrato")]
        [StringLength(100)]
        public string DiaPrato { get; set; }
        [Required]
        [Column("preco")]
        [StringLength(100)]
        public string Preco { get; set; }
        [Required]
        [Column("descricao")]
        [StringLength(500)]
        public string Descricao { get; set; }

        [InverseProperty("IdPratoNavigation")]
        public virtual ICollection<Venda> Venda { get; set; }
    }
}
