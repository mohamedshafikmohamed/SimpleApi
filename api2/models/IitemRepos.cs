using api2.Data;
using System;
using System.Collections.Generic;
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
        public void AddAssignBoard(AssignBoard assignBoard)
        {
            db.AssignBoards.Add(assignBoard);
            db.SaveChanges();
        }
        public IEnumerable<AssignBoard> GetAssignBoard(int BoardId)
        {
          return  db.AssignBoards.Where(x => x.BoardId == BoardId).ToList();
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

        public IEnumerable<Task> GetTasksinBoard(int Id)
        {
            return db.Tasks.Where(x => x.BoardId == Id).ToList();
        }
        public IEnumerable<Note> GetNotesinBoard(int Id)
        {
            return db.Notes.Where(x => x.BoardId == Id).ToList();
        }
        public IEnumerable<Board> GetBoardsinBoard(int Id)
        {
            return db.Boards.Where(x => x.BoardId == Id).ToList();
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
        
        public void createBoard(Board board)
        {
            db.Boards.Add(board);
            db.SaveChanges();
        }

        public void updateBoard(Board board)
        {
            db.Boards.Update(board);
            db.SaveChanges();
        }

        public void DeleteBoard(int id)
        {
            db.Boards.Remove(db.Boards.Find(id));
            db.SaveChanges();
        }
    }
}
