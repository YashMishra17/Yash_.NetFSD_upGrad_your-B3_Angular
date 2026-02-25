// marksAnalyzer.js

// Store student marks
const marks = [65, 78, 82, 56, 90];

// Calculate total using reduce()
const totalMarks = marks.reduce((total, mark) => total + mark, 0);

// Calculate average
const averageMarks = totalMarks / marks.length;

// Determine pass or fail
const result = averageMarks >= 40 ? "Pass" : "Fail";

// Display output using template literals
const output = `
Student Marks Analysis
----------------------
Marks: ${marks.join(", ")}
Total Marks: ${totalMarks}
Average Marks: ${averageMarks.toFixed(2)}
Result: ${result}
`;

console.log(output);