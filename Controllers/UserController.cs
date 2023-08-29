using Microsoft.AspNetCore.Mvc;
using _101.API.Models;
using Microsoft.Extensions.Hosting;
using _101.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.AspNetCore.Components.Forms;

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
        /*
        [HttpGet("GetAllPilots")]
        public List<Pilots> Get()
        {
            return _context.Pilots.ToList();
        }
        */
        [HttpGet("GetAllPlanes")]
        public List<Planes> GetPlanes()
        {   
            return _context.Planes.ToList();
        }
               
        /*[HttpGet("GetPilotById{id}")]
        public Pilots GetById(int id)
        {
            var pilotFound = _context.Pilots.Where(x => x.pilot_id == id).FirstOrDefault();
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
        */
        [HttpPost("AddPlane")]
        public List<Planes> AddPlane(Planes plane)
        {
            _context.Planes.Add(plane);
            _context.SaveChanges();
            return _context.Planes.ToList();
        }
        /*
        
        [HttpPut("UpdatePilot")]
        public List<Pilots> UpdatePilot(Pilots request)
        {
            var dbPilot = _context.Pilots.Find(request.pilot_id);
            dbPilot.user_name = request.user_name;
            dbPilot.first_name = request.first_name;
            dbPilot.last_name = request.last_name;
            dbPilot.flight_hours = request.flight_hours;
            dbPilot.pilot_license_id = request.pilot_license_id;
            dbPilot.country = request.country;
            _context.SaveChanges();
            return _context.Pilots.ToList();

        }
        */
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
        /*
        [HttpDelete("DeletePilot/{id}")]
        public List<Pilots> DeletePilotxId(int id)
        {
            var dbDeletePilot = _context.Pilots.Where(x => x.pilot_id == id).FirstOrDefault();
            _context.Pilots.Remove(dbDeletePilot);
            _context.SaveChanges();
            return _context.Pilots.ToList();
        }
        */
        [HttpDelete("DeletePlane/{id}")]
        public List<Planes> DeletePlanexId(int id)
        {
            var dbDeletePlane = _context.Planes.Where(x => x.plane_id == id).FirstOrDefault();
            _context.Planes.Remove(dbDeletePlane);
            _context.SaveChanges();

            return _context.Planes.ToList();
        }
        /*
     */
    }
}