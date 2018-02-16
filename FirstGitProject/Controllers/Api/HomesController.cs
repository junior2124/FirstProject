using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using FirstGitProject.Dtos;
using FirstGitProject.Models;

namespace FirstGitProject.Controllers.Api
{
    public class HomesController : ApiController
    {
        private ApplicationDbContext _context;

        public HomesController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<HomeDto> GetHomes()
        {
            return _context.Homes
                .Include(m => m.Genre)
                .ToList()
                .Select(Mapper.Map<Home, HomeDto>);
        }

        public IHttpActionResult GetHome(int id)
        {
            var home = _context.Homes.SingleOrDefault(c => c.Id == id);

            if (home == null)
                return NotFound();

            return Ok(Mapper.Map<Home, HomeDto>(home));
        }

        [HttpPost]
        public IHttpActionResult CreateHome(HomeDto homeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var home = Mapper.Map<HomeDto, Home>(homeDto);
            _context.Homes.Add(home);
            _context.SaveChanges();

            homeDto.Id = home.Id;
            return Created(new Uri(Request.RequestUri + "/" + home.Id), homeDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateHome(int id, HomeDto homeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var homeInDb = _context.Homes.SingleOrDefault(c => c.Id == id);

            if (homeInDb == null)
                return NotFound();

            Mapper.Map(homeDto, homeInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteHome(int id)
        {
            var homeInDb = _context.Homes.SingleOrDefault(c => c.Id == id);

            if (homeInDb == null)
                return NotFound();

            _context.Homes.Remove(homeInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
