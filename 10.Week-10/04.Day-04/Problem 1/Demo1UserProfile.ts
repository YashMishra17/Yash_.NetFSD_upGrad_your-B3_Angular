/*Week-10 (DAY-4) Hands-On
Problem -1: User Profile Data Handling using TypeScript Basics
Problem
Develop a simple TypeScript module to manage and display user profile information using core TypeScript concepts like variables, data types, type inference, let/const, template literals, and operators.
Scenario:
You are building a basic Angular application where user details need to be processed before displaying on the UI. As a developer, you must write TypeScript code to handle user data such as name, age, email, and subscription status.
The goal is to ensure type safety, readability, and proper usage of modern TypeScript features.

Requirements:
1.Variable Declaration: 
oDeclare variables for: 
User Name (string) 
Age (number) 
Email (string) 
IsSubscribed (boolean) 
2.Type Inference: 
oDeclare at least 2 variables without explicit types and let TypeScript infer them. 
3.let / const Usage: 
oUse const for values that should not change. 
oUse let where reassignment is required (e.g., updating age). 
4.Template Literals: 
oCreate a formatted user profile message using backticks (`). 
Example:
	Hello John, you are 25 years old and your email is john@example.com



5.Operators:
Perform operations: 
oIncrement age by 1 
oCheck if user is eligible for a premium plan (age > 18 AND subscribed) 
oUse comparison and logical operators
6.Output:
Print all results using console.log()

Technical Constraints
Use only TypeScript (no Angular components required yet) 
Do not use any external libraries 
Follow proper naming conventions (camelCase) 
Ensure strict typing where applicable 
Code should run using ts-node or compiled via tsc
Expectations
Correct usage of TypeScript data types 
Clear understanding of type inference 
Proper distinction between let and const 
Clean and readable code 
Correct use of template literals and operators 
Logical correctness in conditions
Learning Outcomes
After completing this hands-on, learners will be able to:
Understand and apply basic TypeScript data types 
Use type inference effectively 
Differentiate between let and const 
Write dynamic strings using template literals 
Apply operators for real-world conditions 
Build a strong foundation for Angular TypeScript development*/

// Variable Declaration
const userName: string = "Yash";
let age: number = 20;
const email: string = "yash555@gmail.com";
const isSubscribed: boolean = true;

// Type Inference 
let country = "India";        // inferred as string
let loginCount = 5;           // inferred as number


// Template Literals
let profileMessage: string = `Hello ${userName}, you are ${age} years old and your email is ${email}`;

// Operators

// Increment age
age = age + 1;

// Premium eligibility
let isEligibleForPremium: boolean = age > 18 && isSubscribed;


let isAdult: boolean = age >= 18;

console.log("User Name:", userName);
console.log("Age after increment:", age);
console.log("Email:", email);
console.log("Subscribed:", isSubscribed);
console.log("Country (inferred):", country);
console.log("Login Count (inferred):", loginCount);
console.log("Profile Message:", profileMessage);
console.log("Is Adult:", isAdult);
console.log("Eligible for Premium:", isEligibleForPremium);