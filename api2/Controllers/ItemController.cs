﻿using api2.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemRepos ITaskrepo;
     //   [HttpGet("{id}")]
        public ItemController(ItemRepos _Iproductrepo)
        {
            ITaskrepo = _Iproductrepo;
        }
        [HttpGet]
        [Route("GetUserTasks")]
        public ActionResult<IEnumerable<api2.models.Task>> GetTasks()
        {
           return Ok(ITaskrepo.GetTasks());
        }
       
        [HttpGet]
        [Route("GetUserInTask/{TaskId}")]
        public ActionResult<IEnumerable<api2.models.AssignTasks>> GetUserInTask(int TaskId)
        {
           return Ok(ITaskrepo.GetAssignTask(TaskId));
        }

        [HttpGet("{Id}")]
        public ActionResult<api2.models.Task> GetTask( int id)
        {
           return Ok(ITaskrepo.GetTask(id));
        }

        [HttpGet]
        [Route("GetTasksinBoard/{Id}")]
        public ActionResult<api2.models.Task> GetTasksinBoard(int Id)
        {
           return Ok(ITaskrepo.GetTasksinBoard(Id));
        } 
        [HttpPut]
        public ActionResult<api2.models.Task> updateTask(api2.models.Task task)
        {
            ITaskrepo.updateTask(task);

           return Ok();
        } 
        [HttpPost]
        public ActionResult<api2.models.Task> CreateTask(api2.models.Task task)
        {
            ITaskrepo.createTask(task);

           return Ok();
        } 
        
        [HttpPost]
        [Route("Note")]
        public ActionResult<api2.models.Note> CreateNote(api2.models.Note note)
        {
            ITaskrepo.createNotes(note);

           return Ok();
        } 
        [HttpDelete("{Id}")]
        public ActionResult<api2.models.Task> DeleteTask(int id)
        {
            ITaskrepo.DeleteTask(id);
           return Ok();
        }
        [HttpDelete("{Id}")]
        [Route("DeleteNote/{Id}")]
        public ActionResult<api2.models.Note> DeleteNote(int id)
        {
            ITaskrepo.DeleteNotes(id);
           return Ok();
        }
    }
}
