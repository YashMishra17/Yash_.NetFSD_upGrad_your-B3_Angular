"use strict";
// Variable Declaration
const userName = "Yash";
let age = 20;
const email = "yash555@gmail.com";
const isSubscribed = true;
// Type Inference 
let country = "India"; // inferred as string
let loginCount = 5; // inferred as number
// Template Literals
let profileMessage = `Hello ${userName}, you are ${age} years old and your email is ${email}`;
// Operators
// Increment age
age = age + 1;
// Premium eligibility
let isEligibleForPremium = age > 18 && isSubscribed;
let isAdult = age >= 18;
console.log("User Name:", userName);
console.log("Age after increment:", age);
console.log("Email:", email);
console.log("Subscribed:", isSubscribed);
console.log("Country (inferred):", country);
console.log("Login Count (inferred):", loginCount);
console.log("Profile Message:", profileMessage);
console.log("Is Adult:", isAdult);
console.log("Eligible for Premium:", isEligibleForPremium);
