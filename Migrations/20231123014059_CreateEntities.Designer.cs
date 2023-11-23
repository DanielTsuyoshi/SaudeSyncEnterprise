using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SaudeSync.Migrations
{
    [DbContext(typeof(PostgreDbContext))]
    [Migration("20231123014059_CreateEntities")]
    partial class CreateEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SaudeSync.Entities.Consulta", b =>
            {
                b.Property<long>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint")
                    .HasColumnName("id");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                b.Property<long>("ConsultorioId")
                    .HasColumnType("bigint")
                    .HasColumnName("id_consultorio");

                b.Property<DateTime>("DataHora")
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("data_consulta");

                b.Property<long>("MedicoId")
                    .HasColumnType("bigint")
                    .HasColumnName("id_medico");

                b.Property<int>("UsuarioId")
                    .HasColumnType("integer")
                    .HasColumnName("id_usuario");

                b.HasKey("Id");

                b.HasIndex("ConsultorioId");

                b.HasIndex("MedicoId");

                b.HasIndex("UsuarioId");

                b.ToTable("Consultas");
            });

            modelBuilder.Entity("SaudeSync.Entities.Consultorio", b =>
            {
                b.Property<long>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint")
                    .HasColumnName("id");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                b.Property<string>("Cnpj")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("cnpj_consultorio");

                b.Property<long?>("EnderecoId")
                    .IsRequired()
                    .HasColumnType("bigint")
                    .HasColumnName("id_endereco");

                b.Property<string>("Nome")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("character varying(100)")
                    .HasColumnName("nome_consultorio");

                b.HasKey("Id");

                b.HasIndex("EnderecoId");

                b.ToTable("Consultorios");
            });

            modelBuilder.Entity("SaudeSync.Entities.Endereco", b =>
            {
                b.Property<long>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint")
                    .HasColumnName("id");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                b.Property<string>("Cep")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("cep");

                b.Property<string>("Cidade")
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnType("character varying(40)")
                    .HasColumnName("cidade");

                b.Property<string>("Complemento")
                    .HasMaxLength(40)
                    .HasColumnType("character varying(40)")
                    .HasColumnName("complemento");

                b.Property<long?>("ConsultorioId")
                    .HasColumnType("bigint")
                    .HasColumnName("id_consultorio");

                b.Property<string>("Estado")
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnType("character varying(40)")
                    .HasColumnName("estado");

                b.Property<string>("Logradouro")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("character varying(100)")
                    .HasColumnName("logradouro");

                b.Property<int>("Numero")
                    .HasColumnType("integer")
                    .HasColumnName("numero");

                b.HasKey("Id");

                b.HasIndex("ConsultorioId");

                b.ToTable("Enderecos");
            });

            modelBuilder.Entity("SaudeSync.Entities.Medico", b =>
            {
                b.Property<long>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint")
                    .HasColumnName("id");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                b.Property<string>("Crm")
                    .IsRequired()
                    .HasMaxLength(13)
                    .HasColumnType("character varying(13)")
                    .HasColumnName("crm_medico");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnType("character varying(256)")
                    .HasColumnName("email_medico");

                b.Property<string>("Nome")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("character varying(100)")
                    .HasColumnName("nome_medico");

                b.HasKey("Id");

                b.ToTable("Medicos");
            });

            modelBuilder.Entity("SaudeSync.Entities.Usuario", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer")
                    .HasColumnName("id");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                b.Property<string>("Cpf")
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnType("character varying(11)")
                    .HasColumnName("cpf_usuario");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnType("character varying(256)")
                    .HasColumnName("email_usuario");

                b.Property<string>("Nome")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("character varying(100)")
                    .HasColumnName("nome_usuario");

                b.Property<string>("Senha")
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnType("character varying(60)")
                    .HasColumnName("senha_usuario");

                b.HasKey("Id");

                b.ToTable("Usuarios");
            });

            modelBuilder.Entity("SaudeSync.Entities.Consulta", b =>
            {
                b.HasOne("SaudeSync.Entities.Consultorio", "Consultorio")
                    .WithMany("Consultas")
                    .HasForeignKey("ConsultorioId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("SaudeSync.Entities.Medico", "Medico")
                    .WithMany("Consultas")
                    .HasForeignKey("MedicoId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("SaudeSync.Entities.Usuario", "Usuario")
                    .WithMany("Consultas")
                    .HasForeignKey("UsuarioId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Consultorio");

                b.Navigation("Medico");

                b.Navigation("Usuario");
            });

            modelBuilder.Entity("SaudeSync.Entities.Consultorio", b =>
            {
                b.HasOne("SaudeSync.Entities.Endereco", "Endereco")
                    .WithMany()
                    .HasForeignKey("EnderecoId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Endereco");
            });

            modelBuilder.Entity("SaudeSync.Entities.Endereco", b =>
            {
                b.HasOne("SaudeSync.Entities.Consultorio", "Consultorio")
                    .WithMany()
                    .HasForeignKey("ConsultorioId");

                b.Navigation("Consultorio");
            });

            modelBuilder.Entity("SaudeSync.Entities.Consultorio", b =>
            {
                b.Navigation("Consultas");
            });

            modelBuilder.Entity("SaudeSync.Entities.Medico", b =>
            {
                b.Navigation("Consultas");
            });

            modelBuilder.Entity("SaudeSync.Entities.Usuario", b =>
            {
                b.Navigation("Consultas");
            });
#pragma warning restore 612, 618
        }
    }
}
