namespace Odonto.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaPaciente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CNPJ = c.String(maxLength: 14, unicode: false),
                        RazaoSocial = c.String(nullable: false, maxLength: 255, unicode: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CPF = c.String(maxLength: 11, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 255, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 100, unicode: false),
                        CRO = c.String(maxLength: 100, unicode: false),
                        ResponsavelTecnico = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                        IdEmpresa = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.IdEmpresa)
                .Index(t => t.IdEmpresa);
            
            CreateTable(
                "dbo.Paciente",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 255, unicode: false),
                        CPF = c.String(maxLength: 11, unicode: false),
                        RG = c.String(maxLength: 20, unicode: false),
                        DataNascimento = c.DateTime(nullable: false),
                        CEP = c.String(maxLength: 10, unicode: false),
                        UF = c.String(maxLength: 10, unicode: false),
                        Cidade = c.String(maxLength: 100, unicode: false),
                        Bairro = c.String(maxLength: 100, unicode: false),
                        Numero = c.String(maxLength: 30, unicode: false),
                        Complemento = c.String(maxLength: 100, unicode: false),
                        Telefone = c.String(maxLength: 20, unicode: false),
                        Celular = c.String(maxLength: 20, unicode: false),
                        Profissao = c.String(maxLength: 255, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Observacao = c.String(maxLength: 8000, unicode: false),
                        Status = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        IdEmpresa = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.IdEmpresa)
                .Index(t => t.IdEmpresa);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paciente", "IdEmpresa", "dbo.Empresa");
            DropForeignKey("dbo.Funcionario", "IdEmpresa", "dbo.Empresa");
            DropIndex("dbo.Paciente", new[] { "IdEmpresa" });
            DropIndex("dbo.Funcionario", new[] { "IdEmpresa" });
            DropTable("dbo.Paciente");
            DropTable("dbo.Funcionario");
            DropTable("dbo.Empresa");
        }
    }
}
