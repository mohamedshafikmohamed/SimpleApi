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
        [Route("GetTasksinProject/{Id}")]
        public ActionResult<api2.models.Task> GetTasksinProject(int Id)
        {
           return Ok(ITaskrepo.GetTasksinProject(Id));
        } 
        [HttpGet]
        [Route("GetNotesinProject/{Id}")]
        public ActionResult<api2.models.Note> GetNotesinProject(int Id)
        {
           return Ok(ITaskrepo.GetNotesinProject(Id));
        } 
        [HttpGet]
        [Route("GetBoardsinProject/{Id}")]
        public ActionResult<api2.models.Project> GetBoardsinProject(int Id)
        {
           return Ok(ITaskrepo.GetBoardsinProject(Id));
        } 
        [HttpGet]
        [Route("GetLinksinProject/{Id}")]
        public ActionResult<api2.models.Link> GetlinksinProject(int Id)
        {
           return Ok(ITaskrepo.GetLinksinProject(Id));
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
        [Route("Project")]
        public ActionResult<api2.models.Task> updateProject(api2.models.Project board)
        {
            if (ModelState.IsValid)
            {
                ITaskrepo.updateProject(board);


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
        [HttpPut]
        [Route("Image")]
        public ActionResult<api2.models.Link> updateImage([FromForm] api2.models.ImageViewModel Image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ITaskrepo.updateImage(Image);

                    return Ok();
                }
                else return BadRequest("Some properties are not valid");
            }
            catch
            {
                return BadRequest("Some properties are not valid");
            }
        } 
        [HttpPut]
        [Route("File")]
        public ActionResult<api2.models.Link> updateFile([FromForm] api2.models.FileViewModel file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ITaskrepo.updateFile(file);

                    return Ok();
                }
                else return BadRequest("Some properties are not valid");
            }
            catch
            {
                return BadRequest("Some properties are not valid");
            }
        } 
        [HttpPost]
        [Route("Image")]
        public ActionResult<api2.models.Project> CreateImage([FromForm] api2.models.ImageViewModel Img)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ITaskrepo.createImage(Img);
                    return Ok();

                }
                else return BadRequest("Some properties are not valid");
            }
            
            catch
            {
                return BadRequest("Some properties are not valid");
            }
        } 
        [HttpPost]
        [Route("Board")]
        public ActionResult<api2.models.Project> CreateBoard(api2.models.Project board)
        {
            if (ModelState.IsValid)
            {
                ITaskrepo.createProject(board);


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
        [HttpPost]
        [Route("File")]
        public ActionResult<api2.models.File> CreateFile([FromForm] api2.models.FileViewModel file)
        {
            if (ModelState.IsValid)
            {
                ITaskrepo.createFile(file);

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
        public ActionResult<api2.models.Project> DeleteBoard(int id)
        {
           
                ITaskrepo.DeleteProject(id);

           
           return Ok();
        } [HttpDelete]
        [Route("Link/{Id}")]
        public ActionResult<api2.models.Link> DeleteLink(int id)
        {
           
           ITaskrepo.DeleteLink(id);
           return Ok();
        }
        
        [HttpDelete]
        [Route("Image/{Id}")]
        public ActionResult<api2.models.Link> DeleteImage(int id)
        {
           
                ITaskrepo.DeleteImage(id);

           
           return Ok();
        }
        [HttpDelete]
        [Route("File/{Id}")]
        public ActionResult<api2.models.Link> DeleteFile(int id)
        {
           
                ITaskrepo.DeleteFile(id);

           
           return Ok();
        }
    }
}
