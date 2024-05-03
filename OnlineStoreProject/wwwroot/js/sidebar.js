document.addEventListener("DOMContentLoaded", function () {
    const menuToggle = document.querySelector(".menu-toggle");
    const sideMenu = document.querySelector(".side-menu");
    const closeButton = document.querySelector(".btn-close");

    menuToggle.addEventListener("click", function () {
        sideMenu.classList.toggle("open");
        document.body.classList.toggle("menu-open");
    });

    document.addEventListener("click", function (event) {
        if (!sideMenu.contains(event.target) && !menuToggle.contains(event.target)) {
            sideMenu.classList.remove("open");
            document.body.classList.remove("menu-open");
        }
    });

    closeButton.addEventListener("click", function () {
        sideMenu.classList.remove("open");
        document.body.classList.remove("menu-open");
    });

    sideMenu.addEventListener("click", function (event) {
        event.stopPropagation();
    });
});
