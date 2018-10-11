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
    public class VaultKeepsController : Controller
    {
        VaultKeepsRepository _repo;
        public VaultKeepsController(VaultKeepsRepository repo)
        {
            _repo = repo;
        }


        // Get vaultkeeps by userid
        [Authorize]
        [HttpGet]
        public IEnumerable<VaultKeep> Get()
        {
            string userId = HttpContext.User.Identity.Name;
            return _repo.GetAll(userId);

        }

        // post vaultkeeps
        [Authorize]
        [HttpPost]
        public VaultKeep Post([FromBody] VaultKeep vaultKeep)
        {
            if (ModelState.IsValid)
            {
                // this is your req.session.uid
                string id = HttpContext.User.Identity.Name;
                vaultKeep.UserId = id;
                return _repo.Create(vaultKeep);
            }
            throw new Exception("INVALID VAULTKEEP");
        }

        //Get vaultkeeps by vaultkeepID
        [Authorize]
        [Route("{id}")]
        [HttpGet("GetbyId")]
        public VaultKeep GetbyId(int id)
        {
            return _repo.GetById(id);
        }
    }

}