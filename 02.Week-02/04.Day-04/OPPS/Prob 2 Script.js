// Base Class
class Vehicle {

    constructor(brand, speed) {
        this.brand = brand;
        this.speed = speed;
    }

    displayInfo() {
        return `Brand: ${this.brand}, Speed: ${this.speed} km/h`;
    }
}

// Derived Class
class Car extends Vehicle {

    constructor(brand, speed, fuelType) {
        super(brand, speed);   // Call parent constructor
        this.fuelType = fuelType;
    }

    showCarDetails() {
        return `${this.displayInfo()}, Fuel Type: ${this.fuelType}`;
    }
}

// Create Car object
const car1 = new Car("Toyota", 180, "Petrol");

// Call parent method
console.log(car1.displayInfo());

// Call child method
console.log(car1.showCarDetails());