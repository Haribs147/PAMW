using Microsoft.AspNetCore.Mvc;
using LAB2.Models;
using System.Collections.Generic;

namespace LAB2.Controllers
{
    public class Zadanie2Controller : Controller
    {
        private const string SessionKey = "TodoList";

        // Retrieve the TODO list from the session or initialize a new list
        private List<TodoItem> GetTodoListFromSession()
        {
            var todoList = HttpContext.Session.GetObjectFromJson<List<TodoItem>>(SessionKey);
            if (todoList == null)
            {
                todoList = new List<TodoItem>();
                HttpContext.Session.SetObjectAsJson(SessionKey, todoList);
            }
            return todoList;
        }

        // Save the updated TODO list back into the session
        private void SaveTodoListToSession(List<TodoItem> todoList)
        {
            HttpContext.Session.SetObjectAsJson(SessionKey, todoList);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var todoList = GetTodoListFromSession();
            return View(todoList);
        }

        [HttpPost]
        public IActionResult AddTask(string task)
        {
            if (!string.IsNullOrEmpty(task))
            {
                var todoList = GetTodoListFromSession();
                todoList.Add(new TodoItem { Task = task, IsCompleted = false });
                SaveTodoListToSession(todoList);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MarkAsCompleted(int index)
        {
            var todoList = GetTodoListFromSession();
            if (index >= 0 && index < todoList.Count)
            {
                todoList[index].IsCompleted = true;
                SaveTodoListToSession(todoList);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UnmarkAsCompleted(int index)
        {
            var todoList = GetTodoListFromSession();
            if (index >= 0 && index < todoList.Count)
            {
                todoList[index].IsCompleted = false;
                SaveTodoListToSession(todoList);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveTask(int index)
        {
            var todoList = GetTodoListFromSession();
            if (index >= 0 && index < todoList.Count)
            {
                todoList.RemoveAt(index);
                SaveTodoListToSession(todoList);
            }
            return RedirectToAction("Index");
        }
    }
}
