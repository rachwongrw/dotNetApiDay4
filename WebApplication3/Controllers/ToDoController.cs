using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoContext _db;
        public ToDoController(ToDoContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var todos = _db.ToDos.ToList();
                if (!todos.Any())
                {
                    return NoContent();
                }
                return Ok(todos);
            } 
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpGet("{id}", Name = "GetOne")]
        public IActionResult GetById(int id)
        {
            var todo = _db.ToDos.Where(t => t.Id == id).FirstOrDefault();
            return new ObjectResult(todo);
        }

        [HttpPost]
        public IActionResult Create(ToDo todo)
        {
            if (todo.Description != null || todo.Description != "")
            {
                try
                {
                    todo.CreatedOn = DateTime.Now;
                    _db.ToDos.Add(todo);
                    _db.SaveChanges();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
                return Ok(todo);
                //return CreatedAtRoute("GetOne", new { id = todo.Id });
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("Edit")]
        public IActionResult Update(ToDo todo)
        {
            var item = _db.ToDos.Where(t => t.Id == todo.Id).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                item.IsComplete = todo.IsComplete;
                _db.SaveChanges();
            }
            return Ok(item);
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(long Id)
        {
            var item = _db.ToDos.Where(testc => testc.Id == Id).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            _db.ToDos.Remove(item);
            _db.SaveChanges();
            return new ObjectResult(item);       
        }
    }
}
