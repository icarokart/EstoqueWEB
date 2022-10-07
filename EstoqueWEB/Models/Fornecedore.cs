using System;
using System.Collections.Generic;

namespace EstoqueWEB.Models
{
    public partial class Fornecedore
    {
        public Fornecedore()
        {
            EntradasEstoques = new HashSet<EntradasEstoque>();
        }

        public int IdFornecedor { get; set; }
        public string NomeFornecedor { get; set; } = null!;
        public string? RazaoSocial { get; set; }
        public string? Cnpj { get; set; }
        public string Telefone1 { get; set; } = null!;
        public string? Telefone2 { get; set; }
        public string? Email { get; set; }
        public string? Responsavel { get; set; }
        public byte SitFornecedor { get; set; }

        public virtual ICollection<EntradasEstoque> EntradasEstoques { get; set; }
    }
}
