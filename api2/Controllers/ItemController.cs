using api2.models;
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
    [ApiKey]
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
            if (ModelState.IsValid)
            {
                return Ok(ITaskrepo.GetAssignTask(TaskId));
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpGet("{Id}")]
        public ActionResult<api2.models.Task> GetTask(int id)
        {
           return Ok(ITaskrepo.GetTask(id));
        }

        [HttpGet]
        [Route("GetTasksinBoard/{Id}")]
        public ActionResult<api2.models.Task> GetTasksinBoard(int Id)
        {
           return Ok(ITaskrepo.GetTasksinBoard(Id));
        } 
        [HttpGet]
        [Route("GetNotesinBoard/{Id}")]
        public ActionResult<api2.models.Note> GetNotesinBoard(int Id)
        {
           return Ok(ITaskrepo.GetNotesinBoard(Id));
        } 
        [HttpGet]
        [Route("GetBoardsinBoard/{Id}")]
        public ActionResult<api2.models.Board> GetBoardsinBoard(int Id)
        {
           return Ok(ITaskrepo.GetBoardsinBoard(Id));
        } 
        [HttpGet]
        [Route("GetLinksinBoard/{Id}")]
        public ActionResult<api2.models.Link> GetlinksinBoard(int Id)
        {
           return Ok(ITaskrepo.GetLinksinBoard(Id));
        } 
        [HttpPut]
        public ActionResult<api2.models.Task> updateTask(api2.models.Task task)
        {
            if (ModelState.IsValid)
            {
                ITaskrepo.updateTask(task);

                return Ok();
            }
            else return BadRequest("Some properties are not valid");
        } 
        [HttpPut]
        [Route("Note")]
        public ActionResult<api2.models.Task> updateNote(api2.models.Note note)
        {
            if (ModelState.IsValid)
            {
                ITaskrepo.updateNotes(note);


                return Ok();
            }
            else return BadRequest("Some properties are not valid");
        } 
        [HttpPut]
        [Route("Board")]
        public ActionResult<api2.models.Task> updateBoard(api2.models.Board board)
        {
            if (ModelState.IsValid)
            {
                ITaskrepo.updateBoard(board);


                return Ok();
            }
            else return BadRequest("Some properties are not valid");
        } 
        [HttpPut]
        [Route("Link")]
        public ActionResult<api2.models.Link> updateLink(api2.models.Link link)
        {
            if (ModelState.IsValid)
            {
                ITaskrepo.updateLink(link);

                return Ok();
            }
            else return BadRequest("Some properties are not valid");
        } 
        [HttpPost]
        [Route("Board")]
        public ActionResult<api2.models.Board> CreateBoard(api2.models.Board board)
        {
            if (ModelState.IsValid)
            {
                ITaskrepo.createBoard(board);


                return Ok();

            }
            else return BadRequest("Some properties are not valid");

        } 
        
        [HttpPost]
        public ActionResult<api2.models.Task> CreateTask(api2.models.Task task)
        {
            if (ModelState.IsValid)
            {
                ITaskrepo.createTask(task);

                return Ok();
            }
            else return BadRequest("Some properties are not valid");
        } 
        
        [HttpPost]
        [Route("Note")]
        public ActionResult<api2.models.Note> CreateNote(api2.models.Note note)
        {
            if (ModelState.IsValid)
            {
                ITaskrepo.createNotes(note);


                return Ok();
            }
            else return BadRequest("Some properties are not valid");
        } 
        [HttpPost]
        [Route("Link")]
        public ActionResult<api2.models.Link> CreateLink(api2.models.Link link)
        {
            if (ModelState.IsValid)
            {
                ITaskrepo.createLink(link);

                return Ok();
            }
            else return BadRequest("Some properties are not valid");
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
        [HttpDelete]
        [Route("Board/{Id}")]
        public ActionResult<api2.models.Board> DeleteBoard(int id)
        {
           
                ITaskrepo.DeleteBoard(id);

           
           return Ok();
        } [HttpDelete]
        [Route("Link/{Id}")]
        public ActionResult<api2.models.Link> DeleteLink(int id)
        {
           
                ITaskrepo.DeleteLink(id);

           
           return Ok();
        }
    }
}
