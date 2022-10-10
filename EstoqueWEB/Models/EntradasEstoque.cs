using System;
using System.Collections.Generic;

namespace EstoqueWEB.Models
{
    public partial class EntradasEstoque
    {
        public int IdEntrada { get; set; }
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; } = null!;
        public int QtdEntrada { get; set; }
        public DateTime DtEntrada { get; set; }
        public DateTime? DtUltimaAlteracao { get; set; }
        public int NumItensAtual { get; set; }
        public decimal PrecoUn { get; set; }
        public decimal? ValorVenda { get; set; }
        public int? NumNotaFiscal { get; set; }
        public string Lote { get; set; } = null!;
        public int IdFornecedor { get; set; }
        public bool Aberto { get; set; }

        public virtual Fornecedore IdFornecedorNavigation { get; set; } = null!;
        public virtual Produto IdProdutoNavigation { get; set; } = null!;
    }
}