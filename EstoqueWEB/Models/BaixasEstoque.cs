using System;
using System.Collections.Generic;

namespace EstoqueWEB.Models
{
    public partial class BaixasEstoque
    {
        public int IdBaixa { get; set; }
        public int IdProduto { get; set; }
        public DateTime DtBaixa { get; set; }
        public int QtdProduto { get; set; }
        public string? Lote { get; set; }
        public decimal? ValorPerda { get; set; }

        public virtual Produto? IdProdutoNavigation { get; set; } = null!;
    }
}
