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


        // Get keeps by vaultId
        //Route: 'api/vaultkeeps/SOMEID'
        [Authorize]
        [HttpGet("{vaultId}")]
        public IEnumerable<Keep> Get(int vaultId)
        {
            var keeps = _repo.GetAll(vaultId);
            return keeps;

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
        // [Authorize]
        // [Route("{id}")]
        // [HttpGet("GetbyId")]
        // public VaultKeep GetbyId(int id)
        // {
        //     return _repo.GetById(id);
        // }
    }

}