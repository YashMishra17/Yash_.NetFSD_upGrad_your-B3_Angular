// Global variable (outside all functions)
let counter = 0;

// Increment function with parameter
function incrementCounter(step) {
    counter = counter + step;
    document.getElementById("counterValue").innerText = counter;
}

// Reset function
function resetCounter() {
    counter = 0;
    document.getElementById("counterValue").innerText = counter;
}

// Event listeners (NO inline JS)
document.getElementById("incrementBtn").addEventListener("click", function () {
    incrementCounter(1);
});

document.getElementById("resetBtn").addEventListener("click", function () {
    resetCounter();
});