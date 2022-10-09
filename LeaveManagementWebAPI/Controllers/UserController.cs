﻿using LeaveManagementWebAPI.Models.ViewModels;
using LeaveManagementWebAPI.Repositories.Datas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserRepository _repository;

        public UserController(UserRepository repository)
        {
            this._repository = repository;
        }
        // READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = _repository.Get();
            if (data.Count == 0)
                return Ok(new { message = "gagal mengambil data", StatusCode = 200, data = "null" });
            return Ok(new { message = "berhasil mengambil data", StatusCode = 200, data = data });
        }

        //READ BY ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _repository.Get(id);
            if (data == null)
                return Ok(new { message = "gagal mengambil data", StatusCode = 200, data = "null" });
            return Ok(new { message = "berhasil mengambil data", StatusCode = 200, data = data });
        }
        // UPDATE 
        [HttpPut("{id}")]
        public IActionResult Put(int id, UserViewModel user)
        {
            var result = _repository.Put(id, user);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil mengupdate data" });
            return BadRequest(new { StatusCode = 400, message = "gagal mengupdate data" });
        }
        // CREATE
        [HttpPost]
        public IActionResult Post(UserViewModel user)
        {
            var result = _repository.Post(user);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil menambah data" });
            return BadRequest(new { StatusCode = 400, message = "gagal menambah data" });
        }
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _repository.Delete(id);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil menghapus data" });
            return BadRequest(new { StatusCode = 400, message = "gagal menghapus data" });
        }
    }
}
