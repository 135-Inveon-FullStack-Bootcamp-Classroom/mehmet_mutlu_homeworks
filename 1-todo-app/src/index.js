import { nanoid } from "nanoid";
import "./style.css";
import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";

class TodoApp {
  constructor() {
    this.todoList = [];
    this.editTodoId = "";
    this.initApp();
  }

  initApp() {
    this.todoList = JSON.parse(localStorage.getItem("todos")) || [];
    document.body.appendChild(this.renderApp());
    this.getTodos();
    this.submitTodoHandler();
    this.operationHandler();
    this.removeCompletedTodos();
    this.submitTodoEditHandler();
  }

  renderApp() {
    const todoAppDOM = document.createElement("div");

    todoAppDOM.innerHTML = `
      <div class="header-section">
        <h1 class="header-title">Todo App</h1>
        <div class="inputs-group">
          <form id="todo-form">
            <input class="header-input" placeholder="Add to list..." ><button type="submit" class="add-button">Add</button>
          </form>
        </div>
      </div>
      <div class="todos-section">
        <button class="remove-completed">Remove Completed Todos</button>
        <ul class="todos-ul">
        </ul>
      </div>
      <div class="modal fade" id="editModal" tabindex="-1" aria-labelledby="editModal" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
              <form id="edit-form">
                <div>
                  <input class="edit-input" placeholder="Edit todo..." ><button type="submit" class="edit-button" data-bs-dismiss="modal">Edit</button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    `;
    todoAppDOM.classList.add("app-container");

    return todoAppDOM;
  }

  submitTodoHandler() {
    const formDOM = document.getElementById("todo-form");
    formDOM.addEventListener("submit", (event) => this.addTodoHandler(event));
  }

  submitTodoEditHandler() {
    const editFormDOM = document.getElementById("edit-form");
    editFormDOM.addEventListener("submit", (event) =>
      this.editTodoHandler(event)
    );
  }

  editTodoHandler(event) {
    event.preventDefault();
    const modalInputDOM = document.querySelector(".edit-input");
    if (modalInputDOM.value.length > 0 && !/^\s+$/.test(modalInputDOM.value)) {
      let todo = this.todoList[this.findTodoIndex(this.editTodoId)];
      todo.text = modalInputDOM.value;
      this.saveToLocalStorage(this.todoList);
      this.getTodos();
      modalInputDOM.value = "";
    }
  }

  addTodoHandler(event) {
    event.preventDefault();
    const inputDOM = document.querySelector(".header-input");
    const ulDOM = document.querySelector(".todos-ul");
    const liDOM = document.createElement("li");

    if (inputDOM.value.length > 0 && !/^\s+$/.test(inputDOM.value)) {
      liDOM.innerHTML = `<span>${inputDOM.value}</span><div><button type="button" class="edit" data-bs-toggle="modal" data-bs-target="#editModal">Edit</button><button class="close">X</button></div>`;
      liDOM.id = nanoid();
      ulDOM.append(liDOM);
      this.todoList.push({
        id: liDOM.id,
        text: inputDOM.value,
        completed: false,
      });
      this.saveToLocalStorage(this.todoList);
      inputDOM.value = "";
    }
  }

  saveToLocalStorage(todo) {
    localStorage.setItem("todos", JSON.stringify(todo));
  }

  getTodos() {
    const ulDOM = document.querySelector(".todos-ul");
    let todos = "";
    if (this.todoList.length > 0) {
      this.todoList.map(
        (todo) =>
          (todos += `<li id=${todo.id}><span class=${
            todo.completed === true ? "done" : ""
          }>${
            todo.text
          }</span><div><button type="button" class="edit" data-bs-toggle="modal" data-bs-target="#editModal">Edit</button><button class="close">X</button></div></li>`)
      );
      ulDOM.innerHTML = todos;
    } else {
      ulDOM.innerHTML = todos;
    }
  }

  operationHandler() {
    const ulDOM = document.querySelector(".todos-ul");
    ulDOM.addEventListener("click", (e) => {
      let target = e.target;
      if (target.tagName === "SPAN") {
        if (target.classList.contains("done")) {
          target.classList.remove("done");
          this.changeTodoHandler(target.parentNode.id);
        } else {
          target.classList.add("done");
          this.changeTodoHandler(target.parentNode.id);
        }
      } else if (target.tagName === "BUTTON") {
        if (target.classList.contains("close")) {
          this.removeTodo(target.parentNode.parentNode.id);
        } else if (target.classList.contains("edit")) {
          this.editTodoId = e.target.parentNode.parentNode.id;
        }
      }
    });
  }

  changeTodoHandler(id) {
    let todo = this.todoList[this.findTodoIndex(id)];
    todo.completed = !todo.completed;
    this.saveToLocalStorage(this.todoList);
  }

  removeTodo(id) {
    this.todoList = this.todoList.filter((todo) => todo.id != id);
    this.saveToLocalStorage(this.todoList);
    this.getTodos();
  }

  findTodoIndex(id) {
    return this.todoList.findIndex((todo) => todo.id === id);
  }

  removeCompletedTodos() {
    const removeButtonDOM = document.querySelector(".remove-completed");
    removeButtonDOM.addEventListener("click", () => {
      this.todoList = this.todoList.filter((todo) => todo.completed !== true);
      this.saveToLocalStorage(this.todoList);
      this.getTodos();
    });
  }
}

new TodoApp();
