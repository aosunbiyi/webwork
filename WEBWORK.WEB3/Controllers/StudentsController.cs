﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBWORK.DATA.Data;
using WEBWORK.DATA.Models;

namespace WEBWORK.WEB3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentsController : Controller
    {
        private ApplicationContext context { get; set; }
        public StudentsController(ApplicationContext _context)
        {
            this.context = _context;
        }

        [HttpGet(Name = "GetAllStudent")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]

        public IActionResult GetAllStudent()
        {
            return Ok(this.context.Students.ToList()) ;
        }


        /// <summary>
        /// Endpoint to get student by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}",Name = "GetStudentById")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public  IActionResult GetStudentById([FromRoute] int id) {

            var student =  this.context.Students.Where(a=>a.StudentId==id).FirstOrDefault();
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }


        [HttpPost(Name = "CreateStudent")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateStudent([FromBody] Student student) {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                this.context.Students.Add(student);
                this.context.SaveChanges();
                return Ok(student);
            }
        }

        [HttpPut("{id}",Name = "UpdateStudent")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult UpdateStudent([FromRoute] int id,[FromBody] Student student)
        {
            if(student.StudentId != id)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var st = this.context.Students.Where(a => a.StudentId == id).SingleOrDefault();
                if (st == null)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    st.LastName = student.LastName;
                    st.FirstName = student.FirstName;
                    st.Email = student.Email;

                    this.context.SaveChanges();
                    return Ok(st);
                }
            }
        }

        [HttpDelete("{id}",Name = "DeleteStudent")]
        public IActionResult DeleteStudent([FromRoute] int id)
        {
            var st = this.context.Students.Where(a => a.StudentId == id).SingleOrDefault();
            if (st == null)
            {
                return BadRequest(ModelState);
            }

            this.context.Students.Remove(st);
            this.context.SaveChanges();
            return Ok();

        }
    }
}




