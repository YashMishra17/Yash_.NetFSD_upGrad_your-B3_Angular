"use strict";
// 1. Function with Required Parameters
function getWelcomeMessage(name) {
    return `Welcome ${name}!`;
}
// 2. Optional Parameters
function getUserInfo(name, age) {
    if (age !== undefined) {
        return `User ${name} is ${age} years old.`;
    }
    return `User ${name} prefers not to share age.`;
}
// 3. Default Parameters
function getSubscriptionStatus(name, isSubscribed = false) {
    return isSubscribed
        ? `${name} is subscribed to premium services.`
        : `${name} is not subscribed.`;
}
// 4. Return Type (boolean)
function isEligibleForPremium(age) {
    return age > 18;
}
// 5. Arrow Function
const getAccountStatus = (name) => {
    return `Account for ${name} is active.`;
};
// 6. Lexical this
const notificationService = {
    appName: "MyApp",
    // Arrow function → preserves lexical this
    getAppMessage: () => {
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
