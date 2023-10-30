using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Runtime.Serialization;

namespace _101.API.Models
{
    public class Reservations
    {
        [Key]
        public int ReservationId { get; set; }

        [ForeignKey("Pilots")]
        public int PilotId { get; set; } // tengo q plantear q tengo q ir a buscar un piloto no setearlo de aca

        [ForeignKey("Planes")]
        public int plane_id { get; set; } 

        public DateTime StartDateTime { get; set; }
        public DateTime FinishDateTime { get; set; }
        public double TotalTimeReservation { get; set; } // cuanto tiempo esta en uso el avion




    }
}
    