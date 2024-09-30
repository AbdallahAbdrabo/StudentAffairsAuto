// wwwroot/js/modal.js

'use strict';

window.modalFunctions = {
    openModal: function () {
        const modal = document.querySelector('.modalshow');
        const overlay = document.querySelector('.overlay');
        modal.classList.remove('hidden');
        overlay.classList.remove('hidden');
    },
    closeModal: function () {
        const modal = document.querySelector('.modalshow');
        const overlay = document.querySelector('.overlay');
        modal.classList.add('hidden');
        overlay.classList.add('hidden');
    },
    addEventListeners: function () {
        const modal = document.querySelector('.modalshow');
        const overlay = document.querySelector('.overlay');
        const btnCloseModal = document.querySelector('.close-modal');
        const btnsOpenModal = document.querySelectorAll('.show-modal');

        const openModal = function () {
            modal.classList.remove('hidden');
            overlay.classList.remove('hidden');
        };

        const closeModal = function () {
            modal.classList.add('hidden');
            overlay.classList.add('hidden');
        };

        for (let i = 0; i < btnsOpenModal.length; i++) {
            btnsOpenModal[i].addEventListener('click', openModal);
        }

        btnCloseModal.addEventListener('click', closeModal);
        overlay.addEventListener('click', closeModal);

        document.addEventListener('keydown', function (e) {
            if (e.key === 'Escape' && !modal.classList.contains('hidden')) {
                closeModal();
            }
        });
    }
};

