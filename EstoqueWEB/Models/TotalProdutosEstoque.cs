using System;
using System.Collections.Generic;

namespace EstoqueWEB.Models
{
    public partial class TotalProdutosEstoque
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; } = null!;
        public int QtdEstoque { get; set; }
        public decimal PrecoUnd { get; set; }
        public string LoteAtual { get; set; } = null!;

        public virtual Produto IdProdutoNavigation { get; set; } = null!;
    }
}
