export const products = [
    { name: "Pen", price: 10, quantity: 5 },
    { name: "Notebook", price: 50, quantity: 2 },
    { name: "Bag", price: 700, quantity: 1 }
];

export const calculateTotal = (items) =>
    items
        .map(item => item.price * item.quantity)
        .reduce((sum, value) => sum + value, 0);