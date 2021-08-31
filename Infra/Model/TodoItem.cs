using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Model
{
    public class TodoItem
    {
        public int Id { get; set; }
        public String AssignedFor { get; set; }
        public State Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public enum State
    {
        Backlog = 1,
        InProgress = 2,
        Done = 3
    }
}
