namespace dapper_api.Dtos
{
    public record ClientDto
    {
        public int Id { get; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }   
}
