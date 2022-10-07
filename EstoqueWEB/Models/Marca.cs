using System;
using System.Collections.Generic;

namespace EstoqueWEB.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Produtos = new HashSet<Produto>();
        }

        public int IdMarca { get; set; }
        public string NomeMarca { get; set; } = null!;
        public string? Fabricante { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
