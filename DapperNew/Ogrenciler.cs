using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
