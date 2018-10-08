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
    public class VaultsController : Controller
    {
        VaultsRepository _repo;
        public VaultsController(VaultsRepository repo)
        {
            _repo = repo;
        }


        [Authorize]
        [HttpGet]
        public IEnumerable<Vault> Get()
        {
            string userId = HttpContext.User.Identity.Name;
            return _repo.GetAll(userId);
        }


        [Authorize]
        [HttpPost]
        public Vault Post([FromBody] Vault vault)
        {
            if (ModelState.IsValid)
            {
                vault = new Vault();
                return _repo.Create(vault);
            }
            throw new Exception("INVALID VAULT");
        }


        [Route("{id}")]
        [HttpGet("GetbyId")]
        public Vault GetbyId(int id)
        {
            return _repo.GetById(id);
        }
        // 
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Vault vault)
        {
            return _repo.EditVault(vault);
        }


        [HttpDelete("{id}")]
        public void Delete(string id)
        {
        }

    }
}
