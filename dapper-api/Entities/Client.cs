namespace dapper_api.Entities
{
#pragma warning disable CS0659 // El tipo reemplaza a Object.Equals(object o), pero no reemplaza a Object.GetHashCode()
    public class Client
#pragma warning restore CS0659 // El tipo reemplaza a Object.Equals(object o), pero no reemplaza a Object.GetHashCode()
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
#pragma warning disable CS8765 // La nulabilidad del tipo de parámetro no coincide con el miembro invalidado (posiblemente debido a los atributos de nulabilidad).
        public override bool Equals(object obj)
#pragma warning restore CS8765 // La nulabilidad del tipo de parámetro no coincide con el miembro invalidado (posiblemente debido a los atributos de nulabilidad).
        {
            if (obj is Client other)
            {
                return Id == other.Id &&
                    Name == other.Name &&
                    Surname == other.Surname;
            }
            return false;
        }
    }   
}
