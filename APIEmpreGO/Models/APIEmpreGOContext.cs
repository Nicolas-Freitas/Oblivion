using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIEmpreGO.Models
{
    public partial class APIEmpreGOContext : DbContext
    {
        public APIEmpreGOContext()
        {
        }

        public APIEmpreGOContext(DbContextOptions<APIEmpreGOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Aluno> Aluno { get; set; }
        public virtual DbSet<AlunoSkill> AlunoSkill { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<FuncionarioEmpresa> FuncionarioEmpresa { get; set; }
        public virtual DbSet<Inscricao> Inscricao { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vaga> Vaga { get; set; }
        public virtual DbSet<VagaSkill> VagaSkill { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-LEL72H4\\SQLEXPRESS;Database=Emprego;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.IdAdministrador)
                    .HasName("PK__Administ__2B3E34A8850E9E38");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Administrador)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Administr__IdUsu__4BAC3F29");
            });

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(e => e.IdAluno)
                    .HasName("PK__Aluno__8092FCB3A2A800C1");

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__Aluno__C1F89731061A261E")
                    .IsUnique();

                entity.HasIndex(e => e.NumeroMatricula)
                    .HasName("UQ__Aluno__8B9D7E45FC6C8A3B")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Curso)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.NumeroMatricula)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Aluno)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Aluno__IdUsuario__2C3393D0");
            });

            modelBuilder.Entity<AlunoSkill>(entity =>
            {
                entity.HasKey(e => e.IdAlunoSkill)
                    .HasName("PK__AlunoSki__1DAB0D6BB29457B2");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.AlunoSkill)
                    .HasForeignKey(d => d.IdAluno)
                    .HasConstraintName("FK__AlunoSkil__IdAlu__440B1D61");

                entity.HasOne(d => d.IdSkillNavigation)
                    .WithMany(p => p.AlunoSkill)
                    .HasForeignKey(d => d.IdSkill)
                    .HasConstraintName("FK__AlunoSkil__IdSki__44FF419A");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__Empresa__5EF4033E3777EA95");

                entity.HasIndex(e => e.Cep)
                    .HasName("UQ__Empresa__C1FF39CFED021829")
                    .IsUnique();

                entity.HasIndex(e => e.Cnpj)
                    .HasName("UQ__Empresa__AA57D6B4571A747F")
                    .IsUnique();

                entity.HasIndex(e => e.Contato)
                    .HasName("UQ__Empresa__F7C1CC9726128FDB")
                    .IsUnique();

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("CEP")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("CNPJ")
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Contato)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Logo).IsRequired();

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Empresa__IdUsuar__31EC6D26");
            });

            modelBuilder.Entity<FuncionarioEmpresa>(entity =>
            {
                entity.HasKey(e => e.IdFuncionarioEmpresa)
                    .HasName("PK__Funciona__375FA311A645790B");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.FuncionarioEmpresa)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK__Funcionar__IdEmp__34C8D9D1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.FuncionarioEmpresa)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Funcionar__IdUsu__35BCFE0A");
            });

            modelBuilder.Entity<Inscricao>(entity =>
            {
                entity.HasKey(e => e.IdInscricao)
                    .HasName("PK__Inscrica__6209444B06F614F5");

                entity.Property(e => e.Admicao).HasDefaultValueSql("((0))");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.Inscricao)
                    .HasForeignKey(d => d.IdAluno)
                    .HasConstraintName("FK__Inscricao__IdAlu__47DBAE45");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasKey(e => e.IdSkill)
                    .HasName("PK__Skill__A0069307D5DDBEDE");

                entity.Property(e => e.NomeSkill)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.Skill)
                    .HasForeignKey(d => d.IdAluno)
                    .HasConstraintName("FK__Skill__IdAluno__3D5E1FD2");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.Skill)
                    .HasForeignKey(d => d.IdVaga)
                    .HasConstraintName("FK__Skill__IdVaga__3C69FB99");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__CA04062BB7D84084");

                entity.Property(e => e.TituloTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF971D3B5A78");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__A9D10534F1145854")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SenhaUsuario)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__IdTipoU__276EDEB3");
            });

            modelBuilder.Entity<Vaga>(entity =>
            {
                entity.HasKey(e => e.IdVaga)
                    .HasName("PK__Vaga__A848DC3E3F0CB0CC");

                entity.Property(e => e.DescricaoVaga)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DisponibilidadeVaga).HasColumnType("date");

                entity.Property(e => e.NomeVaga)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Vaga)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK__Vaga__IdEmpresa__38996AB5");

                entity.HasOne(d => d.IdFuncionarioEmpresaNavigation)
                    .WithMany(p => p.Vaga)
                    .HasForeignKey(d => d.IdFuncionarioEmpresa)
                    .HasConstraintName("FK__Vaga__IdFunciona__398D8EEE");
            });

            modelBuilder.Entity<VagaSkill>(entity =>
            {
                entity.HasKey(e => e.IdVagaSkill)
                    .HasName("PK__VagaSkil__0F10719687486996");

                entity.HasOne(d => d.IdSkillNavigation)
                    .WithMany(p => p.VagaSkill)
                    .HasForeignKey(d => d.IdSkill)
                    .HasConstraintName("FK__VagaSkill__IdSki__412EB0B6");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.VagaSkill)
                    .HasForeignKey(d => d.IdVaga)
                    .HasConstraintName("FK__VagaSkill__IdVag__403A8C7D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
