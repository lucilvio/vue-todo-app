using System;

namespace Vue.TodoApp.Model
{
    public class Task
    {
        public Task()
        {
            this.Id = Guid.NewGuid();
        }

        public Task(string name, Guid userId, Guid? list = null) : this()
        {
            this.Name = name;
            this.UserId = userId;
            this.Done = false;
            this.Important = false;
            this.ListId = list;
        }

        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public bool Done { get; private set; }
        public bool Important { get; private set; }
        public Guid? ListId { get; private set; }

        public void MarkAsDone() => this.Done = true;
        public void MarkAsTodo() => this.Done = false;
        public void MarkAsImportant() => this.Important = true;
        public void MarkAsNotImportant() => this.Important = false;
    }
}