"use strict";
// 1. Generic Function
function getFirstElement(items) {
    if (items.length === 0) {
        throw new Error("Array is empty");
    }
    return items[0];
}
// 3. Generic Class
class DataManager {
    items = [];
    add(item) {
        this.items.push(item);
    }
    getAll() {
        return this.items;
    }
}
// 5. Use Case Implementation
// User Data Manager
const userManager = new DataManager();
userManager.add({ id: 1, name: "Yash" });
userManager.add({ id: 2, name: "Nishi" });
// Product Data Manager
const productManager = new DataManager();
productManager.add({ id: 101, title: "Laptop" });
productManager.add({ id: 102, title: "Phone" });
// Testing Outputs
console.log("All Users:", userManager.getAll());
console.log("All Products:", productManager.getAll());
// Generic Function Usage
console.log("First User:", getFirstElement(userManager.getAll()));
console.log("First Product:", getFirstElement(productManager.getAll()));
