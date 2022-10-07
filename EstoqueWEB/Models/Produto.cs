using System;
using System.Collections.Generic;

namespace EstoqueWEB.Models
{
    public partial class Produto
    {
        public Produto()
        {
            BaixasEstoques = new HashSet<BaixasEstoque>();
            EntradasEstoques = new HashSet<EntradasEstoque>();
            SaidasEstoques = new HashSet<SaidasEstoque>();
        }

        public int IdProduto { get; set; }
        public string NomeProduto { get; set; } = null!;
        public int IdMarca { get; set; }
        public string? Linha { get; set; }
        public int? QtdEstoque { get; set; }

        public virtual Marca IdMarcaNavigation { get; set; } = null!;
        public virtual ICollection<BaixasEstoque> BaixasEstoques { get; set; }
        public virtual ICollection<EntradasEstoque> EntradasEstoques { get; set; }
        public virtual ICollection<SaidasEstoque> SaidasEstoques { get; set; }
    }
}
