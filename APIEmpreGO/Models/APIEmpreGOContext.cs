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
                    .HasName("PK__Administ__EBE80EA1F62314DD");

                entity.Property(e => e.IdAdministrador).HasColumnName("idAdministrador");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Administrador)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Administr__idUsu__44FF419A");
            });

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(e => e.IdAluno)
                    .HasName("PK__Aluno__0C5BC84989FF5E1F");

                entity.Property(e => e.IdAluno).HasColumnName("idAluno");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Curriculo).HasColumnName("curriculo");

                entity.Property(e => e.Curso)
                    .HasColumnName("curso")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("dataNascimento")
                    .HasColumnType("date");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NumeroMatricula)
                    .HasColumnName("numeroMatricula")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Aluno)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Aluno__idUsuario__29572725");
            });

            modelBuilder.Entity<AlunoSkill>(entity =>
            {
                entity.HasKey(e => e.IdAlunoSkill)
                    .HasName("PK__AlunoSki__30C11B0377915C9F");

                entity.Property(e => e.IdAlunoSkill).HasColumnName("idAlunoSkill");

                entity.Property(e => e.IdAluno).HasColumnName("idAluno");

                entity.Property(e => e.IdSkill).HasColumnName("idSkill");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.AlunoSkill)
                    .HasForeignKey(d => d.IdAluno)
                    .HasConstraintName("FK__AlunoSkil__idAlu__3E52440B");

                entity.HasOne(d => d.IdSkillNavigation)
                    .WithMany(p => p.AlunoSkill)
                    .HasForeignKey(d => d.IdSkill)
                    .HasConstraintName("FK__AlunoSkil__idSki__3F466844");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__Empresa__75D2CED40A34EF01");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Cnpj)
                    .HasColumnName("CNPJ")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Contato)
                    .HasColumnName("contato")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Logo).HasColumnName("logo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Empresa__idUsuar__2C3393D0");
            });

            modelBuilder.Entity<FuncionarioEmpresa>(entity =>
            {
                entity.HasKey(e => e.IdFuncionarioEmpresa)
                    .HasName("PK__Funciona__04E1487846EA931C");

                entity.Property(e => e.IdFuncionarioEmpresa).HasColumnName("idFuncionarioEmpresa");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.FuncionarioEmpresa)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK__Funcionar__idEmp__2F10007B");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.FuncionarioEmpresa)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Funcionar__idUsu__300424B4");
            });

            modelBuilder.Entity<Inscricao>(entity =>
            {
                entity.HasKey(e => e.IdInscricao)
                    .HasName("PK__Inscrica__CB2B18FEE73B0325");

                entity.Property(e => e.IdInscricao).HasColumnName("idInscricao");

                entity.Property(e => e.Admicao).HasColumnName("admicao");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IdAluno).HasColumnName("idAluno");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.Inscricao)
                    .HasForeignKey(d => d.IdAluno)
                    .HasConstraintName("FK__Inscricao__idAlu__4222D4EF");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasKey(e => e.IdSkill)
                    .HasName("PK__Skill__C4CE4D6EDB46F902");

                entity.Property(e => e.IdSkill).HasColumnName("idSkill");

                entity.Property(e => e.IdAluno).HasColumnName("idAluno");

                entity.Property(e => e.IdVaga).HasColumnName("idVaga");

                entity.Property(e => e.NomeSkill)
                    .HasColumnName("nomeSkill")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.Skill)
                    .HasForeignKey(d => d.IdAluno)
                    .HasConstraintName("FK__Skill__idAluno__37A5467C");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.Skill)
                    .HasForeignKey(d => d.IdVaga)
                    .HasConstraintName("FK__Skill__idVaga__36B12243");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__03006BFF6C91D2BE");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.TituloTipoUsuario)
                    .HasColumnName("tituloTipoUsuario")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A651989477");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasColumnName("nomeUsuario")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SenhaUsuario)
                    .IsRequired()
                    .HasColumnName("senhaUsuario")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__idTipoU__267ABA7A");
            });

            modelBuilder.Entity<Vaga>(entity =>
            {
                entity.HasKey(e => e.IdVaga)
                    .HasName("PK__Vaga__02E6F4AA3DA3F6CB");

                entity.Property(e => e.IdVaga).HasColumnName("idVaga");

                entity.Property(e => e.CandidatosVaga).HasColumnName("candidatosVaga");

                entity.Property(e => e.DescricaoVaga)
                    .HasColumnName("descricaoVaga")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DisponibilidadeVaga)
                    .HasColumnName("disponibilidadeVaga")
                    .HasColumnType("date");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdFuncionarioEmpresa).HasColumnName("idFuncionarioEmpresa");

                entity.Property(e => e.NomeVaga)
                    .HasColumnName("nomeVaga")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Vaga)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK__Vaga__idEmpresa__32E0915F");

                entity.HasOne(d => d.IdFuncionarioEmpresaNavigation)
                    .WithMany(p => p.Vaga)
                    .HasForeignKey(d => d.IdFuncionarioEmpresa)
                    .HasConstraintName("FK__Vaga__idFunciona__33D4B598");
            });

            modelBuilder.Entity<VagaSkill>(entity =>
            {
                entity.HasKey(e => e.IdVagaSkill)
                    .HasName("PK__VagaSkil__4CB79F8E13289AEC");

                entity.Property(e => e.IdVagaSkill).HasColumnName("idVagaSkill");

                entity.Property(e => e.IdSkill).HasColumnName("idSkill");

                entity.Property(e => e.IdVaga).HasColumnName("idVaga");

                entity.HasOne(d => d.IdSkillNavigation)
                    .WithMany(p => p.VagaSkill)
                    .HasForeignKey(d => d.IdSkill)
                    .HasConstraintName("FK__VagaSkill__idSki__3B75D760");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.VagaSkill)
                    .HasForeignKey(d => d.IdVaga)
                    .HasConstraintName("FK__VagaSkill__idVag__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
