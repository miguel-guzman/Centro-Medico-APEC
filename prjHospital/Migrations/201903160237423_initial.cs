namespace prjHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActividadModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ActividadEspecialidadModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Actividad_Id = c.Int(nullable: false),
                        Especialidad_Id = c.Int(nullable: false),
                        MedicoModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActividadModel", t => t.Actividad_Id)
                .ForeignKey("dbo.EspecialidadModel", t => t.Especialidad_Id)
                .ForeignKey("dbo.MedicoModel", t => t.MedicoModel_Id)
                .Index(t => t.Actividad_Id)
                .Index(t => t.Especialidad_Id)
                .Index(t => t.MedicoModel_Id);
            
            CreateTable(
                "dbo.EspecialidadModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EpisodioModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaHoraIngreso = c.DateTime(nullable: false),
                        FechaHoraEgreso = c.DateTime(nullable: false),
                        Actividad_Id = c.Int(nullable: false),
                        Medico_Id = c.Int(nullable: false),
                        Persona_Id = c.Int(nullable: false),
                        TipoEgreso_Id = c.Int(),
                        TipoIngreso_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActividadModel", t => t.Actividad_Id)
                .ForeignKey("dbo.MedicoModel", t => t.Medico_Id)
                .ForeignKey("dbo.PersonaModel", t => t.Persona_Id)
                .ForeignKey("dbo.TipoEgresoModel", t => t.TipoEgreso_Id)
                .ForeignKey("dbo.TipoIngresoModel", t => t.TipoIngreso_Id)
                .Index(t => t.Actividad_Id)
                .Index(t => t.Medico_Id)
                .Index(t => t.Persona_Id)
                .Index(t => t.TipoEgreso_Id)
                .Index(t => t.TipoIngreso_Id);
            
            CreateTable(
                "dbo.MedicoModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Persona_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonaModel", t => t.Persona_Id)
                .Index(t => t.Persona_Id);
            
            CreateTable(
                "dbo.PersonaModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 60),
                        ApellidoPaterno = c.String(nullable: false, maxLength: 30),
                        ApellidoMaterno = c.String(maxLength: 30),
                        FechaNacimiento = c.DateTime(nullable: false),
                        CedulaIdentidad = c.String(nullable: false),
                        SexoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SexoModel", t => t.SexoId)
                .Index(t => t.SexoId);
            
            CreateTable(
                "dbo.SexoModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoEgresoModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoIngresoModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EpisodioModel", "TipoIngreso_Id", "dbo.TipoIngresoModel");
            DropForeignKey("dbo.EpisodioModel", "TipoEgreso_Id", "dbo.TipoEgresoModel");
            DropForeignKey("dbo.EpisodioModel", "Persona_Id", "dbo.PersonaModel");
            DropForeignKey("dbo.EpisodioModel", "Medico_Id", "dbo.MedicoModel");
            DropForeignKey("dbo.MedicoModel", "Persona_Id", "dbo.PersonaModel");
            DropForeignKey("dbo.PersonaModel", "SexoId", "dbo.SexoModel");
            DropForeignKey("dbo.ActividadEspecialidadModel", "MedicoModel_Id", "dbo.MedicoModel");
            DropForeignKey("dbo.EpisodioModel", "Actividad_Id", "dbo.ActividadModel");
            DropForeignKey("dbo.ActividadEspecialidadModel", "Especialidad_Id", "dbo.EspecialidadModel");
            DropForeignKey("dbo.ActividadEspecialidadModel", "Actividad_Id", "dbo.ActividadModel");
            DropIndex("dbo.PersonaModel", new[] { "SexoId" });
            DropIndex("dbo.MedicoModel", new[] { "Persona_Id" });
            DropIndex("dbo.EpisodioModel", new[] { "TipoIngreso_Id" });
            DropIndex("dbo.EpisodioModel", new[] { "TipoEgreso_Id" });
            DropIndex("dbo.EpisodioModel", new[] { "Persona_Id" });
            DropIndex("dbo.EpisodioModel", new[] { "Medico_Id" });
            DropIndex("dbo.EpisodioModel", new[] { "Actividad_Id" });
            DropIndex("dbo.ActividadEspecialidadModel", new[] { "MedicoModel_Id" });
            DropIndex("dbo.ActividadEspecialidadModel", new[] { "Especialidad_Id" });
            DropIndex("dbo.ActividadEspecialidadModel", new[] { "Actividad_Id" });
            DropTable("dbo.TipoIngresoModel");
            DropTable("dbo.TipoEgresoModel");
            DropTable("dbo.SexoModel");
            DropTable("dbo.PersonaModel");
            DropTable("dbo.MedicoModel");
            DropTable("dbo.EpisodioModel");
            DropTable("dbo.EspecialidadModel");
            DropTable("dbo.ActividadEspecialidadModel");
            DropTable("dbo.ActividadModel");
        }
    }
}
