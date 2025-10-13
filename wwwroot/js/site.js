document.addEventListener("DOMContentLoaded", function () {
    // initialize progress bar at 0%
    const bar = document.getElementById("progressBar");
    if (bar) {
        bar.style.width = "0%";
        bar.innerText = "0%";
        bar.className = "progress-bar bg-danger"; // start red
    }

    // add event listener to the form
    const form = document.getElementById("reportForm");
    if (form) {
        form.addEventListener("input", updateProgress);
    }
});

function updateProgress() {
    let progress = 0;

    if (document.getElementById("location").value.trim() !== "") {
        progress += 20;
    }
    if (document.getElementById("category").value !== "") {
        progress += 20;
    }
    if (document.getElementById("description").value.trim() !== "") {
        progress += 30;
    }
    if (document.getElementById("media").files.length > 0) {
        progress += 30;
    }

    const bar = document.getElementById("progressBar");
    bar.style.width = progress + "%";
    bar.innerText = progress + "%";

    // update color based on progress
    if (progress < 40) {
        bar.className = "progress-bar bg-danger"; // red
    } else if (progress < 80) {
        bar.className = "progress-bar bg-warning"; // yellow
    } else {
        bar.className = "progress-bar bg-success"; // green
    }
}