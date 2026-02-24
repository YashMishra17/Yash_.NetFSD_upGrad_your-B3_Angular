// Student object in global scope
let student = {
    name: "Rahul",
    rollNo: 101,
    marks: 78
};

// Function to display student profile
function updateStudentProfile(studentObj) {
    let profileDiv = document.getElementById("profile");

    profileDiv.innerHTML =
        "<p><strong>Name:</strong> " + studentObj.name + "</p>" +
        "<p><strong>Roll No:</strong> " + studentObj.rollNo + "</p>" +
        "<p><strong>Marks:</strong> " + studentObj.marks + "</p>";
}

// Function to update marks and refresh display
function updateMarks(newMarks) {
    student.marks = newMarks;
    updateStudentProfile(student);
}

// Button actions (no inline JS)
document.getElementById("updateProfileBtn").addEventListener("click", function () {
    updateStudentProfile(student);
});

document.getElementById("updateMarksBtn").addEventListener("click", function () {
    updateMarks(90); // new marks
});