using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai.HRODS.webApi.Domains;

#nullable disable

namespace senai.HRODS.webApi.Contexts
{
    public partial class HrodsContext : DbContext
    {
        public HrodsContext()
        {
        }

        public HrodsContext(DbContextOptions<HrodsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Classe> Classes { get; set; }
        public virtual DbSet<ClasseHabilidade> ClasseHabilidades { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<Personagem> Personagems { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<TipoHabilidade> TipoHabilidades { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-EJ47PRO\\SQLEXPRESS; Initial Catalog= Senai_Hroads_Tarde; user id=sa; pwd=senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Classe>(entity =>
            {
                entity.ToTable("Classe");

                entity.Property(e => e.ClasseId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("classeId");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClasseHabilidade>(entity =>
            {
                entity.ToTable("ClasseHabilidade");

                entity.Property(e => e.ClasseHabilidadeId).ValueGeneratedOnAdd();

                entity.Property(e => e.ClasseId).HasColumnName("classeId");

                entity.HasOne(d => d.Classe)
                    .WithMany(p => p.ClasseHabilidades)
                    .HasForeignKey(d => d.ClasseId)
                    .HasConstraintName("FK__ClasseHab__class__2B3F6F97");

                entity.HasOne(d => d.Habilidade)
                    .WithMany(p => p.ClasseHabilidades)
                    .HasForeignKey(d => d.HabilidadeId)
                    .HasConstraintName("FK__ClasseHab__Habil__2C3393D0");
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.ToTable("Habilidade");

                entity.Property(e => e.HabilidadeId).ValueGeneratedOnAdd();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoHabilidade)
                    .WithMany(p => p.Habilidades)
                    .HasForeignKey(d => d.TipoHabilidadeId)
                    .HasConstraintName("FK__Habilidad__TipoH__286302EC");
            });

            modelBuilder.Entity<Personagem>(entity =>
            {
                entity.ToTable("Personagem");

                entity.Property(e => e.PersonagemId).ValueGeneratedOnAdd();

                entity.Property(e => e.ClasseId).HasColumnName("classeId");

                entity.Property(e => e.DataDeAtualização).HasColumnType("datetime");

                entity.Property(e => e.DataDeCriacao).HasColumnType("datetime");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Classe)
                    .WithMany(p => p.Personagems)
                    .HasForeignKey(d => d.ClasseId)
                    .HasConstraintName("FK__Personage__class__2F10007B");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");

                entity.HasOne(d => d.Personagem)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.PersonagemId)
                    .HasConstraintName("FK__Player__Personag__5070F446");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__Player__UsuarioI__5165187F");
            });

            modelBuilder.Entity<TipoHabilidade>(entity =>
            {
                entity.ToTable("TipoHabilidade");

                entity.Property(e => e.TipoHabilidadeId).ValueGeneratedOnAdd();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.ToTable("TipoUsuario");

                entity.HasIndex(e => e.TituloTipoUsuario, "UQ__TipoUsua__37BBE07E060F376D")
                    .IsUnique();

                entity.Property(e => e.TipoUsuarioId).ValueGeneratedOnAdd();

                entity.Property(e => e.TituloTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Email, "UQ__Usuario__A9D105345BC05F9D")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoUsuario)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipoUsuarioId)
                    .HasConstraintName("FK__Usuario__TipoUsu__4D94879B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
