// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', function () {
    const cards = document.querySelectorAll('.card');
    const lists = document.querySelectorAll('.list');

    let draggedCard = null;

    cards.forEach(card => {
        card.addEventListener('dragstart', function () {
            draggedCard = card;
        });

        card.addEventListener('dragend', function () {
            draggedCard = null;
        });
    });

    lists.forEach(list => {
        list.addEventListener('dragover', function (e) {
            e.preventDefault();
        });

        list.addEventListener('drop', function () {
            this.append(draggedCard);
            // Add an AJAX request here to update the card position on the server
        });
    });
});
