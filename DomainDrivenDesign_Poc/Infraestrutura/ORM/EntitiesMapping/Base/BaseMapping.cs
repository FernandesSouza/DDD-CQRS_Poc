namespace DomainDrivenDesign_Poc.Infraestrutura.ORM.EntitiesMapping.Base;

public abstract class BaseMapping(string schema)
{
    private const string SchemaDefault = "RichDomain";
    protected readonly string Schema = schema;

    protected BaseMapping() : this(SchemaDefault)
    {
    }
}