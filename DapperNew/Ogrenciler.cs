using Dapper.Contrib.Extensions;
namespace DapperNew
{
    [Table("Ogrenciler")]
    public class Ogrenciler
    {
        [Key]
        public int id { get; set; }
        public string ad { get; set; }
        public int yas { get; set; }
    }
}
