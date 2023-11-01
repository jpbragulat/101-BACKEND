using Microsoft.AspNetCore.Mvc;
using _101.API.Models;
using Microsoft.Extensions.Hosting;
using _101.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.AspNetCore.Components.Forms;
using System.Net;

// probando git
namespace _101.API.Controllers
{
    [ApiController] 
    [Route("api")]
    public class UserController : ControllerBase
    {
       
        private readonly _101DbContext _context;
      
        public UserController(_101DbContext context)
        {
            _context = context;
        }
        
        [HttpGet("GetAllPilots")]
        public List<Pilots> Get()
        {
            return _context.Pilots.ToList();
        }
        
        [HttpGet("GetAllPlanes")]
        public List<Planes> GetPlanes()
        {   
            return _context.Planes.ToList();
        }

        [HttpGet("GetAllReservations")]
        public List<Reservations> GetReservations()
        {
            return _context.Reservations.ToList();
        }



        [HttpGet("GetPilotById/{id}")]
        public Pilots GetById(int id)
        {
            var pilotFound = _context.Pilots.Where(x => x.PilotId == id).FirstOrDefault();
            return pilotFound;
        }

        [HttpGet("GetPlaneBy/{id}")]
        public Planes GetPlaneById(int id)
        {
            var planeFound = _context.Planes.Where(x => x.plane_id == id).FirstOrDefault();
            return planeFound;
        }
        
        
        [HttpPost("AddPilot")]
        public List<Pilots> AddPilot(Pilots pilot)
        {
            _context.Pilots.Add(pilot);
            _context.SaveChanges();
            return _context.Pilots.ToList(); //post puede ser void
        }
        
        [HttpPost("AddPlane")]
        public List<Planes> AddPlane(Planes plane)
        {
            _context.Planes.Add(plane);
            _context.SaveChanges();
            return _context.Planes.ToList();
        }

        [HttpPost("AddReservation")] // esta mal , tengo q setear q reciba el numero de ID del piloto y avion elegidos para generar esta nueva reserva.
        public HttpStatusCode AddReservation(Reservations reservation) //firma, no hace falta definir todas la variables denuevo porq ya le puse q es tipo Reservations ya sabe q tiene q recibir
        {
            var totalHours = reservation.FinishDateTime - reservation.StartDateTime;
            reservation.TotalTimeReservation = totalHours.TotalMinutes;
            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            return HttpStatusCode.OK;
        }


        [HttpPut("UpdatePilot")]
        public List<Pilots> UpdatePilot(Pilots request)
        {
            var dbPilot = _context.Pilots.Find(request.PilotId);
            dbPilot.FirstName = request.FirstName;
            dbPilot.LastName = request.LastName;
            dbPilot.FlightHours = request.FlightHours;
            dbPilot.PilotLicenseId = request.PilotLicenseId;
           
            _context.SaveChanges();
            return _context.Pilots.ToList();
            
        }

        
        [HttpPut("UpdatePlane")]
        public List<Planes> UpdatePlane(Planes requestPlane)
        {
            var dbPlane = _context.Planes.Find(requestPlane.plane_id); // TODO: falta control de error x si mandan un ID que no existe
            dbPlane.plane_id = requestPlane.plane_id;
            dbPlane.identifier = requestPlane.identifier;
            dbPlane.manufacturer = requestPlane.manufacturer;
            dbPlane.model = requestPlane.model;
            dbPlane.flight_hours = requestPlane.flight_hours;
            dbPlane.flight_hours_remain = requestPlane.flight_hours_remain;
            _context.SaveChanges();
            return _context.Planes.ToList();
        }

        [HttpPut("UpdateReservation")]
        public HttpStatusCode UpdateReservation(Reservations requestReservation)
        {
            var dbReservation = _context.Reservations.Find(requestReservation.ReservationId);
            dbReservation.ReservationId = requestReservation.ReservationId;
            dbReservation.PilotId = requestReservation.PilotId;
            dbReservation.plane_id = requestReservation.plane_id;
            dbReservation.StartDateTime = requestReservation.StartDateTime; 
            dbReservation.FinishDateTime = requestReservation.FinishDateTime;
            dbReservation.TotalTimeReservation = requestReservation.TotalTimeReservation; // mmm habria q hacer la cuenta denuevo ?
            _context.SaveChanges();

            return HttpStatusCode.OK;
        }
        
        [HttpDelete("DeletePilot/{id}")]
        public List<Pilots> DeletePilotxId(int id)
        {
            var dbDeletePilot = _context.Pilots.Where(x => x.PilotId == id).FirstOrDefault();
            _context.Pilots.Remove(dbDeletePilot);
            _context.SaveChanges();
            return _context.Pilots.ToList();
        }
        
        [HttpDelete("DeletePlane/{id}")]
        public List<Planes> DeletePlanexId(int id)
        {
            var dbDeletePlane = _context.Planes.Where(x => x.plane_id == id).FirstOrDefault();
            _context.Planes.Remove(dbDeletePlane);
            _context.SaveChanges();

            return _context.Planes.ToList();
        }

        [HttpDelete("DeleteReservation/{id}")]
        public HttpStatusCode DeleteReservationxId(int id)
        {
            var dbDeleteReservation = _context.Reservations.Where(x => x.ReservationId == id).FirstOrDefault();
            _context.Reservations.Remove(dbDeleteReservation);
            _context.SaveChanges();

            return HttpStatusCode.OK;
        }

    }
}