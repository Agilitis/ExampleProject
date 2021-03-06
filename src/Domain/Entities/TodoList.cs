﻿using ExampleProject.Domain.Common;
using ExampleProject.Domain.ValueObjects;
using System.Collections.Generic;

namespace ExampleProject.Domain.Entities
{
    public class TodoList : AuditableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public CarColor Colour { get; set; } = CarColor.White;

        public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
    }
}
