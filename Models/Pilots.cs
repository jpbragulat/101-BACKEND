using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Runtime.Serialization;

namespace _101.API.Models
{
    public class Pilots
    {
        [Key]
        public int PilotId { get; set; } //en .net es asi PilotId // en sql server tambien
         
        
        public string FirstName { get; set; } 
        public string LastName { get; set; }  
        public int    FlightHours { get; set; }
        public int    PilotLicenseId { get; set; }
        
    }
}
