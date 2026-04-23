/*Problem -2: User Notification System using TypeScript Functions
Problem Statement:
Create a TypeScript module that generates user notifications using functions. The implementation should demonstrate function parameters (required, optional, and default), return types, and arrow functions with lexical this.
Scenario:
You are developing an Angular-based application where users receive different types of notifications (e.g., welcome message, subscription alert, account update).
As a developer, you need to design reusable TypeScript functions to generate and manage these notifications while ensuring proper typing and clean code practices.
Requirements:
1. Function with Required Parameters
Create a function getWelcomeMessage(name: string): string 
It should return a welcome message for the user
2. Optional Parameters
Create a function getUserInfo(name: string, age?: number): string 
If age is provided → include it in the message 
If not → return message without age
3. Default Parameters
Create a function getSubscriptionStatus(name: string, isSubscribed: boolean = false): string 
If no value is passed → treat user as not subscribed
4. Return Types
All functions must explicitly define return types 
At least one function should return a boolean 
oExample: isEligibleForPremium(age: number): boolean 
5. Arrow Functions
Rewrite one or more functions using arrow syntax
6. Lexical this 
Create an object NotificationService with: 
oa property appName 
oa method using arrow function that accesses this.appName 
Demonstrate how arrow function preserves this
7. Execution
Call all functions and print outputs using console.log()
Technical Constraints:
Use only TypeScript (no Angular component yet) 
Avoid using any type 
Follow proper naming conventions (camelCase) 
Use ES6+ syntax 
Code should compile without errors using tsc

Expectations:
Correct implementation of: 
oRequired, optional, and default parameters 
oExplicit return types 
Proper usage of arrow functions 
Clear understanding of lexical this 
Clean, readable, and modular code 
Logical handling of conditions

Learning Outcomes:
After completing this hands-on, learners will be able to:
Understand function parameter types in TypeScript 
Use optional and default parameters effectively 
Define and enforce return types 
Write arrow functions confidently 
Understand lexical this behavior 
Build a strong foundation for Angular service methods and business logic*/


// 1. Function with Required Parameters
function getWelcomeMessage(name: string): string {
  return `Welcome ${name}!`;
}

// 2. Optional Parameters
function getUserInfo(name: string, age?: number): string {
  if (age !== undefined) {
    return `User ${name} is ${age} years old.`;
  }
  return `User ${name} prefers not to share age.`;
}

// 3. Default Parameters
function getSubscriptionStatus(
  name: string,
  isSubscribed: boolean = false
): string {
  return isSubscribed
    ? `${name} is subscribed to premium services.`
    : `${name} is not subscribed.`;
}

// 4. Return Type (boolean)
function isEligibleForPremium(age: number): boolean {
  return age > 18;
}

// 5. Arrow Function
const getAccountStatus = (name: string): string => {
  return `Account for ${name} is active.`;
};

// 6. Lexical this
const notificationService = {
  appName: "MyApp",

  // Arrow function → preserves lexical this
  getAppMessage: (): string => {
    return `Welcome to ${notificationService.appName}`;
  }
};


console.log(getWelcomeMessage("Yash"));

console.log(getUserInfo("Yash", 20));
console.log(getUserInfo("Nishi"));

console.log(getSubscriptionStatus("Yash", true));
console.log(getSubscriptionStatus("Devu"));

console.log("Eligible for Premium:", isEligibleForPremium(20));
console.log("Eligible for Premium:", isEligibleForPremium(16));

console.log(getAccountStatus("Yash"));

console.log(notificationService.getAppMessage());