using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBWORK.DATA.Data;
using WEBWORK.DATA.Models;
using WEBWORK.DATA.Models.BindingTarget;
using WEBWORK.WEB3.Repositories;
using WEBWORK.WEB3.Repositories.IRepositories;

namespace WEBWORK.WEB3.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class StudentsController : Controller
    {
        private ApplicationContext context { get; set; }
        public IStudentRepository repo { get; }
        public StudentsController(ApplicationContext _context, IStudentRepository _repo)
        {
            this.context = _context;
            repo = _repo;
        }

        [HttpGet(Name = "GetAllStudent")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]

        public IActionResult GetAllStudent()
        {
            return Ok(this.repo.GetAll()) ;
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

        [HttpGet("GetByEmail/{email}")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]

        public IActionResult GetByEmail([FromRoute] string email)
        {
            if( email.Trim().Length == 0  && !email.Trim().Equals("")  )
            {
                return BadRequest(ModelState);
            }
            var mailToLower = email.ToLower().Trim();

            var student = this.context.Students.Where(a => a.Email.ToLower().Trim().Equals(mailToLower)).FirstOrDefault();
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(student);
            }

        }

        [HttpGet("GetByEmail/{email}/AndPhoneNumber/{phone}")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]

        public IActionResult GetByEmailAndPhoneNumber([FromRoute] string email, string phone)
        {
            if (email.Trim().Length == 0 && !email.Trim().Equals(""))
            {
                return BadRequest(ModelState);
            }

            if (phone.Trim().Length == 0 && !phone.Trim().Equals(""))
            {
                return BadRequest(ModelState);
            }
            var mailToLower = email.ToLower().Trim();
            var sPhone = phone.ToLower().Trim();

            var student = this.context.Students.Where(a => a.Email.ToLower().Trim().Equals(mailToLower) && a.Phone==sPhone).FirstOrDefault();
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(student);
            }

        }



        [HttpPost(Name = "CreateStudent")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateStudent([FromBody] StudentData sdata) {

            var student = sdata.Student;

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
        public IActionResult DeleteStudent([FromRoute] long id)
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





