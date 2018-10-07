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

        [HttpGet]
        public IEnumerable<VaultKeep> Get()
        {
            return _repo.GetAll();
        }

        [Authorize]
        [HttpPost]
        public VaultKeep Post([FromBody] VaultKeep vaultKeep)
        {
            if (ModelState.IsValid)
            {
                vaultKeep = new VaultKeep(vaultKeep.Name, vaultKeep.Description);
                return _repo.Create(vaultKeep);
            }
            throw new Exception("INVALID VAULTKEEP");
        }

    }

}