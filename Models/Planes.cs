using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Runtime.Serialization;

namespace _101.API.Models
{
    public class Planes
    {
        [Key]
        public int plane_id { get; set; }

        public string identifier { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public int    flight_hours { get; set; }
        public int    flight_hours_remain { get; set; }
        //public int   available { get; set; } // pasar a bool

        //public int    flight_hours_remain { get; set; } // hacemos la cuenta entre tabla
        //public string service_date { get; set; }
        //public string next_service_date { get; set; }
    }
}
