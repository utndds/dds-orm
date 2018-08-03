namespace ORM.Models
{
    using System.Data.Entity;

    public partial class UniversidadContext : DbContext
    {
        public UniversidadContext()
            : base("name=UniversidadBase")
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; }
        public virtual DbSet<Carrera> Carreras { get; set; }
        public virtual DbSet<Comision> Comisiones { get; set; }
        public virtual DbSet<Materia> Materias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>()
                .Property(e => e.Apellido)
                .IsUnicode(true);

            modelBuilder.Entity<Alumno>()
                .Property(e => e.Nombres)
                .IsUnicode(true);

            modelBuilder.Entity<Alumno>()
                .HasMany(e => e.Comisiones)
                .WithMany(e => e.Alumnos)
                .Map(m => m.ToTable("AlumnosPorComision").MapLeftKey("AlumnoId").MapRightKey("ComisionId"));

            modelBuilder.Entity<Carrera>()
                .Property(e => e.Codigo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Carrera>()
                .Property(e => e.Nombre)
                .IsUnicode(true);

            modelBuilder.Entity<Carrera>()
                .HasMany(e => e.Materias)
                .WithMany(e => e.Carreras)
                .Map(m => m.ToTable("MateriasPorCarrera").MapLeftKey("CarreraId").MapRightKey("MateriaId"));

            modelBuilder.Entity<Comision>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Comision>()
                .Property(e => e.Descripcion)
                .IsUnicode(true);

            modelBuilder.Entity<Materia>()
                .Property(e => e.Nombre)
                .IsUnicode(true);

            modelBuilder.Entity<Materia>()
                .HasMany(e => e.Comisiones)
                .WithRequired(e => e.Materia)
                .WillCascadeOnDelete(false);
        }
    }
}
