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

        [HttpGet]
        public IEnumerable<Keep> Get()
        {
            return _repo.GetAll();
        }

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

    }

}