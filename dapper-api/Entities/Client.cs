namespace dapper_api.Entities
{
    public class Client
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
