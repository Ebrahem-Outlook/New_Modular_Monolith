namespace Monolith.Domain.Core.BaseType;

/// <summary>
/// 
/// </summary>
public abstract class Entity : IEntity, IEquatable<Entity?>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    protected Entity(Guid id) => Id = id;

    /// <summary>
    /// 
    /// </summary>
    protected Entity() { }

    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Entity);
    }

    public bool Equals(Entity? other)
    {
        return other is not null &&
               Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

    public static bool operator ==(Entity? left, Entity? right)
    {
        return EqualityComparer<Entity>.Default.Equals(left, right);
    }

    public static bool operator !=(Entity? left, Entity? right)
    {
        return !(left == right);
    }
}

/// <summary>
/// 
/// </summary>
public interface IEntity
{
    /// <summary>
    /// 
    /// </summary>
    Guid Id { get; }
}
