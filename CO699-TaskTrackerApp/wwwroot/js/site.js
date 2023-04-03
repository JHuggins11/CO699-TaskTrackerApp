// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// UserTasks/Index.cshtml

var taskName = document.getElementById("task-name");
var taskDueDate = document.getElementById("task-due-date");
var taskPriority = document.getElementById("task-priority");
var taskDescription = document.getElementById("task-description");

// Strikethrough task's text in Bootstrap card if the task has been set as completed
function strikeText() {
    taskName.classList.add("completed-task");
    taskDueDate.classList.add("completed-task");
    taskPriority.classList.add("completed-task");
    taskDescription.classList.add("completed-task");
}

// Remove strikethrough text from task's Bootstrap card if the task has been set as incomplete
function removeStrikeText() {
    taskName.classList.remove("completed-task");
    taskDueDate.classList.remove("completed-task");
    taskPriority.classList.remove("completed-task");
    taskDescription.classList.remove("completed-task");
}