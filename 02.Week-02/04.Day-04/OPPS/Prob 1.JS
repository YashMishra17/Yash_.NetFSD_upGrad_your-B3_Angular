class Student {

    constructor(name, rollNumber, marks) {
        this.name = name;
        this.rollNumber = rollNumber;
        this.marks = marks;
    }

    getDetails() {
        return `Name: ${this.name}, Roll No: ${this.rollNumber}, Marks: ${this.marks}`;
    }

    getGrade() {
        if (this.marks >= 90) {
            return "A";
        } else if (this.marks >= 75) {
            return "B";
        } else if (this.marks >= 50) {
            return "C";
        } else {
            return "Fail";
        }
    }
}

// Creating student objects
const student1 = new Student("Rahul", 101, 92);
const student2 = new Student("Anita", 102, 68);

// Printing details and grades
console.log(student1.getDetails());
console.log("Grade:", student1.getGrade());

console.log(student2.getDetails());
console.log("Grade:", student2.getGrade());