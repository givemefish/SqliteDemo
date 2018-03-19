// =================================================================
// File: UsersController.cs
// Editor: 陳佳駿 chiachunchen (Yuanta)
// Create Date: 2018/03/15 下午 05:31
// Update Date: 2018/03/16 上午 10:49
// =================================================================
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SqliteApi.Controllers;
using SqliteApi.Repositories;
using SqliteApi.ViewModels;

namespace SqliteDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UsersController: BaseController
    {
        private readonly IAppUserRepository repository;

        private ILogger<HomeController> logger;

        public UsersController(IAppUserRepository repository, ILogger<HomeController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = repository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = repository.Get(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AppUser appUser)
        {
            if (appUser == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return Unprocessable(ModelState);
            }

            repository.Add(appUser);
            return CreatedAtAction("Get", new { id = appUser.Id }, appUser);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AppUser appUser)
        {
            if (appUser == null || id != appUser.Id)
            {
                return BadRequest();
            }

            if (repository.Get(id) == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Unprocessable(ModelState);
            }

            repository.Update(id, appUser);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (repository.Get(id) == null)
            {
                return NotFound();
            }

            repository.Delete(id);
            return NoContent();
        }
    }
}