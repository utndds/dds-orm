namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumno",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Apellido = c.String(nullable: false, maxLength: 256),
                        Nombres = c.String(nullable: false, maxLength: 256),
                        Legajo = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comision",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        MateriaId = c.Long(nullable: false),
                        Codigo = c.String(nullable: false, maxLength: 5, unicode: false),
                        Descripcion = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materia", t => t.MateriaId)
                .Index(t => t.MateriaId);
            
            CreateTable(
                "dbo.Materia",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Carrera",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Codigo = c.String(nullable: false, maxLength: 5, fixedLength: true, unicode: false),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MateriasPorCarrera",
                c => new
                    {
                        CarreraId = c.Long(nullable: false),
                        MateriaId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.CarreraId, t.MateriaId })
                .ForeignKey("dbo.Carrera", t => t.CarreraId, cascadeDelete: true)
                .ForeignKey("dbo.Materia", t => t.MateriaId, cascadeDelete: true)
                .Index(t => t.CarreraId)
                .Index(t => t.MateriaId);
            
            CreateTable(
                "dbo.AlumnosPorComision",
                c => new
                    {
                        AlumnoId = c.Long(nullable: false),
                        ComisionId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.AlumnoId, t.ComisionId })
                .ForeignKey("dbo.Alumno", t => t.AlumnoId, cascadeDelete: true)
                .ForeignKey("dbo.Comision", t => t.ComisionId, cascadeDelete: true)
                .Index(t => t.AlumnoId)
                .Index(t => t.ComisionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlumnosPorComision", "ComisionId", "dbo.Comision");
            DropForeignKey("dbo.AlumnosPorComision", "AlumnoId", "dbo.Alumno");
            DropForeignKey("dbo.Comision", "MateriaId", "dbo.Materia");
            DropForeignKey("dbo.MateriasPorCarrera", "MateriaId", "dbo.Materia");
            DropForeignKey("dbo.MateriasPorCarrera", "CarreraId", "dbo.Carrera");
            DropIndex("dbo.AlumnosPorComision", new[] { "ComisionId" });
            DropIndex("dbo.AlumnosPorComision", new[] { "AlumnoId" });
            DropIndex("dbo.MateriasPorCarrera", new[] { "MateriaId" });
            DropIndex("dbo.MateriasPorCarrera", new[] { "CarreraId" });
            DropIndex("dbo.Comision", new[] { "MateriaId" });
            DropTable("dbo.AlumnosPorComision");
            DropTable("dbo.MateriasPorCarrera");
            DropTable("dbo.Carrera");
            DropTable("dbo.Materia");
            DropTable("dbo.Comision");
            DropTable("dbo.Alumno");
        }
    }
}
