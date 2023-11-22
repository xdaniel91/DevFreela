namespace DevFreela.Core.Entities;
public abstract class BaseEntity
{
    protected BaseEntity()
    {
        
    }

    public long Id { get; private set; }
}
