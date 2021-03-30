﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.models
{
  public  interface ItemRepos
    {
       public IEnumerable<Task> GetTasks();
        public IEnumerable<Task> GetTasksinBoard(int Id);
        public  Task GetTask(int id);
        public void createTask(Task task);
        public void updateTask(Task task);
        public  void DeleteTask(int id); 
       // public  Note GetNote(int id);
        public void createNotes(Note note);
        public void updateNotes(Note note);
        public  void DeleteNotes(int id);
       
        public void AddAssignTask(AssignTasks assignTasks);
        public IEnumerable<AssignTasks> GetAssignTask(int TaskId);
    }
}
