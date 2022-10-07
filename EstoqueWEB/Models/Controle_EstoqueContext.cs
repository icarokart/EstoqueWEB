using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EstoqueWEB.Models
{
    public partial class Controle_EstoqueContext : DbContext
    {
        public Controle_EstoqueContext()
        {
        }

        public Controle_EstoqueContext(DbContextOptions<Controle_EstoqueContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BaixasEstoque> BaixasEstoques { get; set; } = null!;
        public virtual DbSet<EntradasEstoque> EntradasEstoques { get; set; } = null!;
        public virtual DbSet<Fornecedore> Fornecedores { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Produto> Produtos { get; set; } = null!;
        public virtual DbSet<SaidasEstoque> SaidasEstoques { get; set; } = null!;
        public virtual DbSet<TotalProdutosEstoque> TotalProdutosEstoques { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PC-SUPO-ICARO;Database=Controle_Estoque;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaixasEstoque>(entity =>
            {
                entity.HasKey(e => e.IdBaixa)
                    .HasName("PK_ID_BAIXA");

                entity.ToTable("BAIXAS_ESTOQUE");

                entity.Property(e => e.IdBaixa).HasColumnName("ID_BAIXA");

                entity.Property(e => e.DtBaixa)
                    .HasColumnType("datetime")
                    .HasColumnName("DT_BAIXA");

                entity.Property(e => e.IdProduto).HasColumnName("ID_PRODUTO");

                entity.Property(e => e.Lote)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LOTE");

                entity.Property(e => e.QtdProduto).HasColumnName("QTD_PRODUTO");

                entity.Property(e => e.ValorPerda)
                    .HasColumnType("numeric(7, 2)")
                    .HasColumnName("VALOR_PERDA");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.BaixasEstoques)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PRODUTOS__BAIXAS_ESTOQUE");
            });

            modelBuilder.Entity<EntradasEstoque>(entity =>
            {
                entity.HasKey(e => e.IdEntrada)
                    .HasName("PK_ID_ENTRADA");

                entity.ToTable("ENTRADAS_ESTOQUE");

                entity.Property(e => e.IdEntrada).HasColumnName("ID_ENTRADA");

                entity.Property(e => e.Aberto).HasColumnName("ABERTO");

                entity.Property(e => e.DtEntrada)
                    .HasColumnType("datetime")
                    .HasColumnName("DT_ENTRADA");

                entity.Property(e => e.DtUltimaAlteracao)
                    .HasColumnType("datetime")
                    .HasColumnName("DT_ULTIMA_ALTERACAO");

                entity.Property(e => e.IdFornecedor).HasColumnName("ID_FORNECEDOR");

                entity.Property(e => e.IdProduto).HasColumnName("ID_PRODUTO");

                entity.Property(e => e.Lote)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LOTE");

                entity.Property(e => e.NomeProduto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOME_PRODUTO");

                entity.Property(e => e.NumItensAtual).HasColumnName("NUM_ITENS_ATUAL");

                entity.Property(e => e.NumNotaFiscal).HasColumnName("NUM_NOTA_FISCAL");

                entity.Property(e => e.PrecoUn)
                    .HasColumnType("numeric(7, 2)")
                    .HasColumnName("PRECO_UN");

                entity.Property(e => e.QtdEntrada).HasColumnName("QTD_ENTRADA");

                entity.Property(e => e.ValorVenda)
                    .HasColumnType("numeric(7, 2)")
                    .HasColumnName("VALOR_VENDA");

                entity.HasOne(d => d.IdFornecedorNavigation)
                    .WithMany(p => p.EntradasEstoques)
                    .HasForeignKey(d => d.IdFornecedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_FORNECEDOR__ENTRADAS_ESTOQUE");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.EntradasEstoques)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PRODUTO__ENTRADAS_ESTOQUE");
            });

            modelBuilder.Entity<Fornecedore>(entity =>
            {
                entity.HasKey(e => e.IdFornecedor)
                    .HasName("PK_ID_FORNECEDOR");

                entity.ToTable("FORNECEDORES");

                entity.Property(e => e.IdFornecedor).HasColumnName("ID_FORNECEDOR");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.NomeFornecedor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOME_FORNECEDOR");

                entity.Property(e => e.RazaoSocial)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RAZAO_SOCIAL");

                entity.Property(e => e.Responsavel)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("RESPONSAVEL");

                entity.Property(e => e.SitFornecedor).HasColumnName("SIT_FORNECEDOR");

                entity.Property(e => e.Telefone1)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONE1");

                entity.Property(e => e.Telefone2)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONE2");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK_ID_MARCA");

                entity.ToTable("MARCAS");

                entity.Property(e => e.IdMarca).HasColumnName("ID_MARCA");

                entity.Property(e => e.Fabricante)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FABRICANTE");

                entity.Property(e => e.NomeMarca)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NOME_MARCA");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK_ID_PRODUTO");

                entity.ToTable("PRODUTOS");

                entity.Property(e => e.IdProduto).HasColumnName("ID_PRODUTO");

                entity.Property(e => e.IdMarca).HasColumnName("ID_MARCA");

                entity.Property(e => e.Linha)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("LINHA");

                entity.Property(e => e.NomeProduto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOME_PRODUTO");

                entity.Property(e => e.QtdEstoque).HasColumnName("QTD_ESTOQUE");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_MARCA__PRODUTOS");
            });

            modelBuilder.Entity<SaidasEstoque>(entity =>
            {
                entity.HasKey(e => e.IdSaida)
                    .HasName("PK_ID_SAIDA");

                entity.ToTable("SAIDAS_ESTOQUE");

                entity.Property(e => e.IdSaida).HasColumnName("ID_SAIDA");

                entity.Property(e => e.DtSaida)
                    .HasColumnType("datetime")
                    .HasColumnName("DT_SAIDA");

                entity.Property(e => e.IdProduto).HasColumnName("ID_PRODUTO");

                entity.Property(e => e.NomeProduto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOME_PRODUTO");

                entity.Property(e => e.PrecoVendaUn)
                    .HasColumnType("numeric(7, 2)")
                    .HasColumnName("PRECO_VENDA_UN");

                entity.Property(e => e.QtdSaida).HasColumnName("QTD_SAIDA");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.SaidasEstoques)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PRODUTO__SAIDAS_ESTOQUE");
            });

            modelBuilder.Entity<TotalProdutosEstoque>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TOTAL_PRODUTOS_ESTOQUE");

                entity.HasIndex(e => e.IdProduto, "UQ__TOTAL_PR__69B28A53D199D588")
                    .IsUnique();

                entity.Property(e => e.IdProduto).HasColumnName("ID_PRODUTO");

                entity.Property(e => e.LoteAtual)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LOTE_ATUAL");

                entity.Property(e => e.NomeProduto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOME_PRODUTO");

                entity.Property(e => e.PrecoUnd)
                    .HasColumnType("numeric(7, 2)")
                    .HasColumnName("PRECO_UND");

                entity.Property(e => e.QtdEstoque).HasColumnName("QTD_ESTOQUE");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithOne()
                    .HasForeignKey<TotalProdutosEstoque>(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PRODUTO__TOTAL_PRODUTOS_ESTOQUE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
