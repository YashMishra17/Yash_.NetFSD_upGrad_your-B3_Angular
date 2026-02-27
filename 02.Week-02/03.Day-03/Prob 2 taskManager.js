// taskManager.js

let tasks = [];

/* ---------------------------
   1 Callback Version
---------------------------- */

export const addTaskCallback = (task, callback) => {
  setTimeout(() => {
    tasks.push(task);
    callback(`Task "${task}" added successfully.`);
  }, 1000);
};

export const deleteTaskCallback = (task, callback) => {
  setTimeout(() => {
    tasks = tasks.filter(t => t !== task);
    callback(`Task "${task}" deleted successfully.`);
  }, 1000);
};

export const listTasksCallback = (callback) => {
  setTimeout(() => {
    callback(tasks);
  }, 1000);
};


/* ---------------------------
   2 Promise Version
---------------------------- */

export const addTaskPromise = (task) => {
  return new Promise((resolve) => {
    setTimeout(() => {
      tasks.push(task);
      resolve(`Task "${task}" added successfully.`);
    }, 1000);
  });
};

export const deleteTaskPromise = (task) => {
  return new Promise((resolve) => {
    setTimeout(() => {
      tasks = tasks.filter(t => t !== task);
      resolve(`Task "${task}" deleted successfully.`);
    }, 1000);
  });
};

export const listTasksPromise = () => {
  return new Promise((resolve) => {
    setTimeout(() => {
      resolve(tasks);
    }, 1000);
  });
};


/* ---------------------------
   3 Async/Await Version
---------------------------- */

export const addTask = async (task) => {
  tasks.push(task);
  return `Task "${task}" added successfully.`;
};

export const deleteTask = async (task) => {
  tasks = tasks.filter(t => t !== task);
  return `Task "${task}" deleted successfully.`;
};

export const listTasks = async () => {
  return tasks;
};