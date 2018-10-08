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

        [HttpGet]
        public IEnumerable<Vault> Get()
        {
            return _repo.GetAll();
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

        [HttpPut]
        public Vault UpdateVault([FromBody] Vault vault)
        {
            return _repo.Update(vault);
        }

        [HttpDelete]

        public Vault DeleteVault([FromBody] Vault vault)
        {
            return _repo.Delete(vault);
        }

    }

}