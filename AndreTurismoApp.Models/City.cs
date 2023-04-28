using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoApp.Models
{
    public class City
    {
        public static readonly string INSERT = @"insert into City (Description) values (@Description); 
                                                 select cast(scope_identity() as int)";

        public static readonly string GET_ALL = @"select Id, Description from City";

        public static readonly string GET = @"select Id, Description from City Where Id = @Id";

        public static readonly string UPDATE = @"update City set Description = @Description
                                                 where id = @IdCity";

        public static readonly string DELETE = @"delete from City where id = @idcity";
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
