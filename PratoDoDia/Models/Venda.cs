using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PratoDoDia.Models
{
    public partial class Venda
    {
        [Key]
        [Column("idVenda")]
        public int IdVenda { get; set; }
        [Column("idCliente")]
        public int? IdCliente { get; set; }
        [Column("idPrato")]
        public int? IdPrato { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(Cliente.Venda))]
        public virtual Cliente IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdPrato))]
        [InverseProperty(nameof(Prato.Venda))]
        public virtual Prato IdPratoNavigation { get; set; }
    }
}
