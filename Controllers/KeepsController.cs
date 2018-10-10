using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeepsController : Controller
    {
        KeepsRepository _repo;
        public KeepsController(KeepsRepository repo)
        {
            _repo = repo;
        }


        // GET all keeps

        [HttpGet]
        public IEnumerable<Keep> Get()
        {
            return _repo.GetAll();
        }


        // GET keeps by keep ID

        // [Route("{id}")]
        // [HttpGet("GetbyId")]
        // public Keep GetKeepById(int id)
        // {
        //     return _repo.GetById(id);
        // }

        // POST keeps

        [Authorize]
        [HttpPost]
        public Keep Post([FromBody] Keep keep)
        {
            if (ModelState.IsValid)
            {
                string userId = HttpContext.User.Identity.Name;
                keep = new Keep(keep.Name, keep.Description, keep.ImgUrl);
                keep.UserId = userId;
                return _repo.Create(keep);
            }
            throw new Exception("INVALID KEEP");
        }




        [Route("{id}")]
        [HttpGet("GetbyId")]
        public Keep GetbyId(int id)
        {
            return _repo.GetById(id);
        }
        // 



        [HttpPut("{id}")]
        public Keep Put(int id, [FromBody]Keep keep)
        {
            return _repo.EditKeep(id, keep);
        }


        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _repo.Delete(id);
        }




    }

}