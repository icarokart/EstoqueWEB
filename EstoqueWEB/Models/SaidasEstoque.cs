using System;
using System.Collections.Generic;

namespace EstoqueWEB.Models
{
    public partial class SaidasEstoque
    {
        public int IdSaida { get; set; }
        public int IdProduto { get; set; }
        public DateTime DtSaida { get; set; }
        public string? NomeProduto { get; set; }
        public int QtdSaida { get; set; }
        public decimal PrecoVendaUn { get; set; }

        public virtual Produto? IdProdutoNavigation { get; set; } = null!;
    }
}
