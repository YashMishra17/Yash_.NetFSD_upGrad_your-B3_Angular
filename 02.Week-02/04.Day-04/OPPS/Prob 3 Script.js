// Base Class
class Payment {
    pay(amount) {
        console.log("Processing payment");
    }
}

// Subclass 1
class CreditCardPayment extends Payment {
    pay(amount) {
        console.log(`Paid ₹${amount} using Credit Card`);
    }
}

// Subclass 2
class UPIPayment extends Payment {
    pay(amount) {
        console.log(`Paid ₹${amount} using UPI`);
    }
}

// Subclass 3
class CashPayment extends Payment {
    pay(amount) {
        console.log(`Paid ₹${amount} in Cash`);
    }
}

// Creating objects
const credit = new CreditCardPayment();
const upi = new UPIPayment();
const cash = new CashPayment();

// Calling pay() method
credit.pay(500);
upi.pay(500);
cash.pay(500);