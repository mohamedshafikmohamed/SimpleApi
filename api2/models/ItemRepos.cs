using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.models
{
  public  interface ItemRepos
    {
       public IEnumerable<Task> GetTasks();
        public IEnumerable<Task> GetTasksinProject(int Id);
        public IEnumerable<Note> GetNotesinProject(int Id);
        public IEnumerable<Project> GetBoardsinProject(int Id);
        public IEnumerable<Link> GetLinksinProject(int Id);
        public IEnumerable<Images> GetImagesinProject(int Id);
       
        public  Task GetTask(int id);
        public void createTask(Task task);
        public void updateTask(Task task);
        public  void DeleteTask(int id); 
       // public  Note GetNote(int id);
        public void createNotes(Note note);
        public void updateNotes(Note note);
        public  void DeleteNotes(int id);
        public void createProject(Project board);
        public void updateProject(Project board);
        public  void DeleteProject(int id);
        public void createImage(ImageViewModel board);
        public void updateImage(ImageViewModel board);
        public  void DeleteImage(int id);

        public void createLink(Link link);
        public void updateLink(Link link);
        public  void DeleteLink(int id);
        public void createFile(FileViewModel file);
        public void updateFile(FileViewModel file);
        public  void DeleteFile(int id);
       
        public void AddAssignTask(AssignTasks assignTasks);
        public IEnumerable<AssignTasks> GetAssignTask(int TaskId);
        public void AddAssignProject(AssignProject assignproject);
        public IEnumerable<AssignProject> GetAssignProject(int BoardId);
    }
}
