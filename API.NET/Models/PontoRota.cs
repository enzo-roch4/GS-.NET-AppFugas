using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.NET.Models
{
    public class PontoRota
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("LATITUDE_A")]
        public double LatitudeA { get; set; }

        [Column("LONGITUDE_A")]
        public double LongitudeA { get; set; }

        [Column("LATITUDE_B")]
        public double LatitudeB { get; set; }

        [Column("LONGITUDE_B")]
        public double LongitudeB { get; set; }

        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}