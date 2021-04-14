using api2.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace api2.models
{
    public class ITaskRepos : ItemRepos
    {
        private readonly AppDbContext db;
        public ITaskRepos(AppDbContext _db)
        {
            db = _db;
        }

        public void AddAssignTask(AssignTasks assignTasks)
        {

            db.Assigntasks.Add(assignTasks);

            db.SaveChanges();

        }
        public IEnumerable<AssignTasks> GetAssignTask(int TaskId)
        {
          return  db.Assigntasks.Where(x => x.TaskId == TaskId).ToList();
        }
        public void AddAssignProject(AssignProject assignproject)
        {
            db.AssignProject.Add(assignproject);
            db.SaveChanges();
        }
        public IEnumerable<AssignProject> GetAssignProject(int BoardId)
        {
          return  db.AssignProject.Where(x => x.BoardId == BoardId).ToList();
        }
       

        public void createTask(Task task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            db.Tasks.Remove(db.Tasks.Find(id));
            db.SaveChanges();
        }

       

        public Task GetTask(int id)
        {
            return db.Tasks.Find(id);
        }

        public IEnumerable<Task> GetTasks()
        {
            return db.Tasks.ToList();
        }

        public IEnumerable<Task> GetTasksinProject(int Id)
        {
            return db.Tasks.Where(x => x.BoardId == Id).ToList();
        }
        public IEnumerable<Note> GetNotesinProject(int Id)
        {
            return db.Notes.Where(x => x.BoardId == Id).ToList();
        }
        public IEnumerable<Project> GetBoardsinProject(int Id)
        {
            return db.Projects.Where(x => x.BoardId == Id).ToList();
        }
        public IEnumerable<Link> GetLinksinProject(int Id)
        {
            return db.Linkes.Where(x => x.BoardId == Id).ToList();
        }
        public IEnumerable<Images> GetImagesinProject(int Id)
        {
            return db.images.Where(x => x.BoardId == Id).ToList();
        }
        public void updateTask(Task task)
        {
            db.Tasks.Update(task);
            db.SaveChanges();
        }

     
        public void createNotes(Note note)
        {

            db.Notes.Add(note);
            db.SaveChanges();
        
        }

        public void updateNotes(Note note)
        {
            db.Notes.Update(note);
            db.SaveChanges();
        }

        public void DeleteNotes(int id)
        {
            db.Notes.Remove(db.Notes.Find(id));
            db.SaveChanges();
        }
        
        public void createProject(Project board)
        {
            db.Projects.Add(board);
            db.SaveChanges();
        }

        public void updateProject(Project board)
        {
            
            db.Projects.Update(board);

            db.SaveChanges();
        
        }

        public void DeleteProject(int id)
        {
            db.Projects.Remove(db.Projects.Find(id));
            db.SaveChanges();
        }
        public void createLink(Link link)
        {
            db.Linkes.Add(link);
            db.SaveChanges();
        }

        public void updateLink(Link link)
        {
            db.Linkes.Update(link);
            db.SaveChanges();
        }

        public void DeleteLink(int id)
        {
            db.Linkes.Remove(db.Linkes.Find(id));
            db.SaveChanges();
        }

       

        public async void createImage([FromBody] ImageViewModel model)
        {
            
            Images img = new Images();
            img.BoardId = model.BoardId;
            img.Id = model.Id;
            img.Index = model.Index;
            if(model.files.Length>0)
            {

                 using(var stream =new MemoryStream())
                {

                    await model.files.CopyToAsync(stream);
                    img.Image = stream.ToArray();

                }
            }
            db.images.Add(img);
            db.SaveChanges();
        }

        public async void updateImage([FromBody] ImageViewModel model)
        {
            Images img = new Images();
            img.BoardId = model.BoardId;
            img.Id = model.Id;
            img.Index = model.Index;
            if (model.files.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await model.files.CopyToAsync(stream);
                    img.Image = stream.ToArray();

                }

            }
            db.images.Update(img);
            db.SaveChanges();
        }

        public void DeleteImage(int id)
        {
          db.images.Remove(db.images.Find(id));

            db.SaveChanges();
        }
        public async void createFile([FromBody] FileViewModel model)
        {


            File file = new File();
            file.BoardId = model.BoardId;
            file.Id = model.Id;
            file.Index = model.Index;
            using (var memoryStream = new MemoryStream())
            {
                await model.file.CopyToAsync(memoryStream);

                // Upload the file if less than 20 MB
                if (memoryStream.Length < 2097152)
                {
                    file.file = memoryStream.ToArray();
                }
               
            }
            db.Files.Add(file);
            db.SaveChanges();
        }

        public async void updateFile([FromBody] FileViewModel model)
        {

            File file = new File();
            file.BoardId = model.BoardId;
            file.Id = model.Id;
            file.Index = model.Index;
            using (var memoryStream = new MemoryStream())
            {
                await model.file.CopyToAsync(memoryStream);

                // Upload the file if less than 20 MB
                if (memoryStream.Length < 20097152)
                {

                    file.file = memoryStream.ToArray();
                
                }

            }
            db.Files.Update(file);
            db.SaveChanges();
        }

        public void DeleteFile(int id)
        {
          db.Files.Remove(db.Files.Find(id));

            db.SaveChanges();
        }
    }
}
