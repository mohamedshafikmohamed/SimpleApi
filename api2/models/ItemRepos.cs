using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.models
{
  public  interface ItemRepos
    {
       public IEnumerable<Task> GetTasks();
        public IEnumerable<Task> GetTasksinBoard(int Id);
        public IEnumerable<Note> GetNotesinBoard(int Id);
        public IEnumerable<Board> GetBoardsinBoard(int Id);
        public IEnumerable<Link>  GetLinksinBoard(int Id);
        public IEnumerable<Images> GetImagesinBoard(int Id);
        public IEnumerable<Board> SearchForBoard(string Title,string Email);
        public  Task GetTask(int id);
        public void createTask(Task task);
        public void updateTask(Task task);
        public  void DeleteTask(int id); 
       // public  Note GetNote(int id);
        public void createNotes(Note note);
        public void updateNotes(Note note);
        public  void DeleteNotes(int id);
        public void createBoard(Board board);
        public void updateBoard(Board board);
        public  void DeleteBoard(int id);
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
        public void AddAssignBoard(AssignBoard assignBoard);
        public IEnumerable<AssignBoard> GetAssignBoard(int BoardId);
    }
}
