// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("mousemove", (event) => {
    const screenWidth = window.innerWidth;
    const threshold = 400;
    const offcanvas = bootstrap.Offcanvas.getOrCreateInstance(document.getElementById('offcanvasExample'))

    if (screenWidth - event.clientX < threshold) {
        offcanvas.show();
    } else {
        offcanvas.hide();
    }
})