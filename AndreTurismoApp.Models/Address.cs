using AndreTurismoApp.Models.DTO;

namespace AndreTurismoApp.Models
{
    public class Address
    {
        public readonly static string INSERT = @"insert into ADDRESS (Street, Number, Neighborhood, CEP, Complement, Data_Cadastre, IdCity) 
                                               values (@Street, @Number, @Neighborhood, @CEP, @Complement, @Data_Cadastre, @IdCity);
                                               select cast(scope_identity() as int)";

        public readonly static string GET_ALL = @"select a.Street, a.Number , a.Neighborhood , a.CEP, a.Complement, c.Description, c.Id 
                                                  from [Address] a inner join City c on a.IdCity = c.Id";

        public readonly static string GET = @"select a.Street, a.Number , a.Neighborhood , a.CEP, a.Complement, c.Id 
                                              from [Address] a inner join City c on c.IdCity = c.Id where a.Id = @Id";

        public readonly static string UPDATE = @"update Address set Street = @Street,
                                                 Number = @Number, 
                                                 Neighborhood = @Neighborhood, 
                                                 PostalCode = @PostalCode,
                                                 Complement = @Complement,
                                                 City = @IdCity
                                                 where id = @id";

        public readonly static string DELETE = "delete from Address where Id = @Id";
        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string CEP { get; set; }
        public string Complement { get; set; }
        public City City { get; set; }
        public Address()
        {
            
        }
        public Address(AddressDTO addressDTO)
        {
            this.Street = addressDTO.Street;
            this.CEP = addressDTO.CEP;
            this.City = new City() { Description = addressDTO.City };
        }
    }
}