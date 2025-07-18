﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', function () {
    const optionCards = document.querySelectorAll('.option-card');
    const hiddenInput = document.getElementById('energySelection');
    const nextBtn = document.getElementById('nextBtn');
    function updateNextButtonState() {
        if (hiddenInput && hiddenInput.value) {
            nextBtn.classList.remove('disabled');
            nextBtn.removeAttribute('tabindex');
            nextBtn.removeAttribute('aria-disabled');
        } else {
            nextBtn.classList.add('disabled');
            nextBtn.setAttribute('tabindex', '-1');
            nextBtn.setAttribute('aria-disabled', 'true');
        }
    }
    optionCards.forEach(card => {
        card.addEventListener('click', function () {
            optionCards.forEach(c => {
                c.classList.remove('active');
                c.querySelector('.checkmark').classList.add('d-none');
            });
            this.classList.add('active');
            this.querySelector('.checkmark').classList.remove('d-none');
            if (hiddenInput) {
                hiddenInput.value = this.getAttribute('data-value');
            }


            // Show/hide partials based on card selection
            const value = this.getAttribute('data-value');
            const homeContent = document.getElementById('homeContent');
            const businessContent = document.getElementById('businessContent');
            const appartmentContent = document.getElementById('appartmentContent');
            if (value === 'home') {
                if (homeContent) homeContent.style.display = '';
                if (businessContent) businessContent.style.display = 'none';
                if (appartmentContent) appartmentContent.style.display = 'none';
            } else if (value === 'business') {
                if (homeContent) homeContent.style.display = 'none';
                if (businessContent) businessContent.style.display = '';
                if (appartmentContent) appartmentContent.style.display = 'none';
            } else if (value === 'appartment') {
                if (homeContent) homeContent.style.display = 'none';
                if (businessContent) businessContent.style.display = 'none';
                if (appartmentContent) appartmentContent.style.display = '';
            }

            updateNextButtonState();
        });
    });
    // Initial state
    updateNextButtonState();
});




