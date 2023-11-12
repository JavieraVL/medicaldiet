using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace csharp.Models
{
    public partial class medicalContext : DbContext
    {
        public medicalContext()
        {
        }

        public medicalContext(DbContextOptions<medicalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administradors { get; set; } = null!;
        public virtual DbSet<Citum> Cita { get; set; } = null!;
        public virtual DbSet<Colacion> Colacions { get; set; } = null!;
        public virtual DbSet<ColacionCopium> ColacionCopia { get; set; } = null!;
        public virtual DbSet<ComentarioCopium> ComentarioCopia { get; set; } = null!;
        public virtual DbSet<DietaCopium> DietaCopia { get; set; } = null!;
        public virtual DbSet<DietaOriginal> DietaOriginals { get; set; } = null!;
        public virtual DbSet<Imagen> Imagens { get; set; } = null!;
        public virtual DbSet<ImagenCopium> ImagenCopia { get; set; } = null!;
        public virtual DbSet<Ingrediente> Ingredientes { get; set; } = null!;
        public virtual DbSet<IngredienteC> IngredienteCs { get; set; } = null!;
        public virtual DbSet<IngredienteDietaC> IngredienteDietaCs { get; set; } = null!;
        public virtual DbSet<IngredienteDietum> IngredienteDieta { get; set; } = null!;
        public virtual DbSet<Paciente> Pacientes { get; set; } = null!;
        public virtual DbSet<Profesional> Profesionals { get; set; } = null!;
        public virtual DbSet<Seguimiento> Seguimientos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=medical;port=3307;user id=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.22-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.Rut)
                    .HasName("PRIMARY");

                entity.ToTable("administrador");

                entity.HasIndex(e => e.RutPaciente, "FK_paciente_admin");

                entity.HasIndex(e => e.RutProfecional, "FK_profecional_admin");

                entity.Property(e => e.Rut)
                    .HasMaxLength(100)
                    .HasColumnName("rut");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.RutPaciente)
                    .HasMaxLength(100)
                    .HasColumnName("rut_paciente");

                entity.Property(e => e.RutProfecional)
                    .HasMaxLength(100)
                    .HasColumnName("rut_profecional");

                entity.HasOne(d => d.RutPacienteNavigation)
                    .WithMany(p => p.Administradors)
                    .HasForeignKey(d => d.RutPaciente)
                    .HasConstraintName("FK_paciente_admin");

                entity.HasOne(d => d.RutProfecionalNavigation)
                    .WithMany(p => p.Administradors)
                    .HasForeignKey(d => d.RutProfecional)
                    .HasConstraintName("FK_profecional_admin");
            });

            modelBuilder.Entity<Citum>(entity =>
            {
                entity.ToTable("cita");

                entity.HasIndex(e => e.RutPaciente, "FK_paciente_cita");

                entity.HasIndex(e => e.RutProfecional, "FK_profecional_cita");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Hora)
                    .HasColumnType("time")
                    .HasColumnName("hora");

                entity.Property(e => e.RutPaciente)
                    .HasMaxLength(100)
                    .HasColumnName("rut_paciente");

                entity.Property(e => e.RutProfecional)
                    .HasMaxLength(100)
                    .HasColumnName("rut_profecional");

                entity.HasOne(d => d.RutPacienteNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.RutPaciente)
                    .HasConstraintName("FK_paciente_cita");

                entity.HasOne(d => d.RutProfecionalNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.RutProfecional)
                    .HasConstraintName("FK_profecional_cita");
            });

            modelBuilder.Entity<Colacion>(entity =>
            {
                entity.ToTable("colacion");

                entity.HasIndex(e => e.DietaId, "FK_dieta_original");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.DietaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("DietaID");

                entity.Property(e => e.Horario).HasMaxLength(50);

                entity.Property(e => e.Tipo).HasMaxLength(100);

                entity.HasOne(d => d.Dieta)
                    .WithMany(p => p.Colacions)
                    .HasForeignKey(d => d.DietaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dieta_original");
            });

            modelBuilder.Entity<ColacionCopium>(entity =>
            {
                entity.ToTable("colacion_copia");

                entity.HasIndex(e => e.DietaId, "FK_dieta_copia");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.DietaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("DietaID");

                entity.Property(e => e.Horario).HasMaxLength(50);

                entity.Property(e => e.Tipo).HasMaxLength(100);

                entity.HasOne(d => d.Dieta)
                    .WithMany(p => p.ColacionCopia)
                    .HasForeignKey(d => d.DietaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dieta_copia");
            });

            modelBuilder.Entity<ComentarioCopium>(entity =>
            {
                entity.ToTable("comentario_copia");

                entity.HasIndex(e => e.IdDietaCopia, "id_dieta_copia");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Hora)
                    .HasColumnType("time")
                    .HasColumnName("hora");

                entity.Property(e => e.IdDietaCopia)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_dieta_copia");

                entity.HasOne(d => d.IdDietaCopiaNavigation)
                    .WithMany(p => p.ComentarioCopia)
                    .HasForeignKey(d => d.IdDietaCopia)
                    .HasConstraintName("comentario_copia_ibfk_1");
            });

            modelBuilder.Entity<DietaCopium>(entity =>
            {
                entity.ToTable("dieta_copia");

                entity.HasIndex(e => e.IdComent, "id_coment");

                entity.HasIndex(e => e.RutPaciente, "rut_paciente");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(100)
                    .HasColumnName("categoria");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdComent)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_coment");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.RutPaciente)
                    .HasMaxLength(12)
                    .HasColumnName("rut_paciente");

                entity.HasOne(d => d.IdComentNavigation)
                    .WithMany(p => p.DietaCopia)
                    .HasForeignKey(d => d.IdComent)
                    .HasConstraintName("dieta_copia_ibfk_1");

                entity.HasOne(d => d.RutPacienteNavigation)
                    .WithMany(p => p.DietaCopia)
                    .HasForeignKey(d => d.RutPaciente)
                    .HasConstraintName("dieta_copia_ibfk_2");
            });

            modelBuilder.Entity<DietaOriginal>(entity =>
            {
                entity.ToTable("dieta_original");

                entity.HasIndex(e => e.Pacienterut, "FK_pacienteID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(100)
                    .HasColumnName("categoria");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Pacienterut)
                    .HasMaxLength(100)
                    .HasColumnName("pacienterut");

                entity.HasOne(d => d.PacienterutNavigation)
                    .WithMany(p => p.DietaOriginals)
                    .HasForeignKey(d => d.Pacienterut)
                    .HasConstraintName("FK_pacienteID");
            });

            modelBuilder.Entity<Imagen>(entity =>
            {
                entity.ToTable("imagen");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Url)
                    .HasMaxLength(200)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<ImagenCopium>(entity =>
            {
                entity.ToTable("imagen_copia");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Url)
                    .HasMaxLength(200)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<Ingrediente>(entity =>
            {
                entity.ToTable("ingredientes");

                entity.HasIndex(e => e.IdImg, "FK_imagen");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.IdImg)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_img");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(100)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdImgNavigation)
                    .WithMany(p => p.Ingredientes)
                    .HasForeignKey(d => d.IdImg)
                    .HasConstraintName("FK_imagen");
            });

            modelBuilder.Entity<IngredienteC>(entity =>
            {
                entity.ToTable("ingrediente_c");

                entity.HasIndex(e => e.IdImg, "FK_imagen_c");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.IdImg)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_img");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(100)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdImgNavigation)
                    .WithMany(p => p.IngredienteCs)
                    .HasForeignKey(d => d.IdImg)
                    .HasConstraintName("FK_imagen_c");
            });

            modelBuilder.Entity<IngredienteDietaC>(entity =>
            {
                entity.ToTable("ingrediente_dieta_c");

                entity.HasIndex(e => e.IdDietaC, "FK_dieta_c");

                entity.HasIndex(e => e.IdIngr, "FK_ingre_c");

                entity.HasIndex(e => e.RutPaciente, "FK_paciente_c");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.IdDietaC)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_dieta_c");

                entity.Property(e => e.IdIngr)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_ingr");

                entity.Property(e => e.Porciones)
                    .HasColumnType("int(11)")
                    .HasColumnName("porciones");

                entity.Property(e => e.RutPaciente)
                    .HasMaxLength(100)
                    .HasColumnName("rut_paciente");

                entity.HasOne(d => d.IdDietaCNavigation)
                    .WithMany(p => p.IngredienteDietaCs)
                    .HasForeignKey(d => d.IdDietaC)
                    .HasConstraintName("FK_dieta_c");

                entity.HasOne(d => d.IdIngrNavigation)
                    .WithMany(p => p.IngredienteDietaCs)
                    .HasForeignKey(d => d.IdIngr)
                    .HasConstraintName("FK_ingre_c");
            });

            modelBuilder.Entity<IngredienteDietum>(entity =>
            {
                entity.ToTable("ingrediente_dieta");

                entity.HasIndex(e => e.ColacionId, "FK_colacion");

                entity.HasIndex(e => e.IdIngr, "FK_ingrediente_D");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ColacionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("colacionID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdIngr)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_ingr");

                entity.HasOne(d => d.Colacion)
                    .WithMany(p => p.IngredienteDieta)
                    .HasForeignKey(d => d.ColacionId)
                    .HasConstraintName("FK_colacion");

                entity.HasOne(d => d.IdIngrNavigation)
                    .WithMany(p => p.IngredienteDieta)
                    .HasForeignKey(d => d.IdIngr)
                    .HasConstraintName("FK_ingrediente_D");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.Rut)
                    .HasName("PRIMARY");

                entity.ToTable("paciente");

                entity.Property(e => e.Rut)
                    .HasMaxLength(100)
                    .HasColumnName("rut");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .HasColumnName("correo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Edad)
                    .HasColumnType("int(11)")
                    .HasColumnName("edad");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaNac)
                    .HasMaxLength(20)
                    .HasColumnName("fecha_nac");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Peso).HasColumnName("peso");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(20)
                    .HasColumnName("sexo");

                entity.Property(e => e.Telefono)
                    .HasColumnType("int(11)")
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Profesional>(entity =>
            {
                entity.HasKey(e => e.Rut)
                    .HasName("PRIMARY");

                entity.ToTable("profesional");

                entity.Property(e => e.Rut)
                    .HasMaxLength(100)
                    .HasColumnName("rut");

                entity.Property(e => e.Especialidad)
                    .HasMaxLength(100)
                    .HasColumnName("especialidad");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Seguimiento>(entity =>
            {
                entity.ToTable("seguimiento");

                entity.HasIndex(e => e.RutPaciente, "FK_paciente_seg");

                entity.HasIndex(e => e.RutProfesional, "FK_profesional_seg");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Estatura).HasColumnName("estatura");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(200)
                    .HasColumnName("observacion");

                entity.Property(e => e.Peso).HasColumnName("peso");

                entity.Property(e => e.RutPaciente)
                    .HasMaxLength(100)
                    .HasColumnName("rut_paciente");

                entity.Property(e => e.RutProfesional)
                    .HasMaxLength(100)
                    .HasColumnName("rut_profesional");

                entity.HasOne(d => d.RutPacienteNavigation)
                    .WithMany(p => p.Seguimientos)
                    .HasForeignKey(d => d.RutPaciente)
                    .HasConstraintName("FK_paciente_seg");

                entity.HasOne(d => d.RutProfesionalNavigation)
                    .WithMany(p => p.Seguimientos)
                    .HasForeignKey(d => d.RutProfesional)
                    .HasConstraintName("FK_profesional_seg");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
