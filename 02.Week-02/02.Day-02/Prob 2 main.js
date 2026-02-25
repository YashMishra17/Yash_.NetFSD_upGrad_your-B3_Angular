// main.js

import { products, calculateTotal } from "./cart.js";

const totalAmount = calculateTotal(products);

const invoice = `
Product Cart Summary
--------------------
${products.map(p => `${p.name} x ${p.quantity} = ₹${p.price * p.quantity}`).join("\n")}

Total Cart Value: ₹${totalAmount}
`;

console.log(invoice);