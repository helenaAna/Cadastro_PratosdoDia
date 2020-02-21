using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PratoDoDia.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venda = new HashSet<Venda>();
        }

        [Key]
        [Column("idCliente")]
        public int IdCliente { get; set; }
        [Required]
        [Column("nomeCliente")]
        [StringLength(100)]
        public string NomeCliente { get; set; }
        [Required]
        [Column("telefone")]
        [StringLength(100)]
        public string Telefone { get; set; }
        [Required]
        [Column("endereco")]
        [StringLength(100)]
        public string Endereco { get; set; }

        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<Venda> Venda { get; set; }
    }
}
