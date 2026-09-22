namespace BibliotecaCatalogo.Domain.Common;

/// <summary>
/// Clase base para las entidades del dominio.
/// Expone la identidad de la entidad. En DDD la igualdad de una entidad
/// se define por su identidad (Id), no por sus atributos.
/// </summary>
public abstract class BaseEntity
{
    public int Id { get; protected set; }

    public override bool Equals(object? obj)
    {
        if (obj is not BaseEntity other)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        // Entidades transitorias (Id == 0) solo son iguales por referencia.
        if (Id == 0 || other.Id == 0)
            return false;

        return Id == other.Id;
    }

    public override int GetHashCode() => (GetType().ToString() + Id).GetHashCode();
}
