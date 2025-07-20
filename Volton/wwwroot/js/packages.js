document.addEventListener('DOMContentLoaded', function () {
    // Carousel 
    const scrollLeftBtn = document.getElementById('scroll-left');
    const scrollRightBtn = document.getElementById('scroll-right');
    const carousel = document.getElementById('package-carousel');

    if (carousel) {
        const cardWidth = carousel.querySelector('.col-md-4').offsetWidth;

        scrollLeftBtn.addEventListener('click', () => {
            carousel.scrollBy({ left: -cardWidth, behavior: 'smooth' });
        });

        scrollRightBtn.addEventListener('click', () => {
            carousel.scrollBy({ left: cardWidth, behavior: 'smooth' });
        });
    }
    const packageForm = document.getElementById('packageForm');
    if (!packageForm)
        return; 

    const getItButtons = document.querySelectorAll('.package-card .btn-secondary');
    const selectedPackageInput = document.getElementById('selectedPackageId');
    const nextBtn = document.getElementById('nextBtn');

    function enableNextButton() {
        if (nextBtn) {
            nextBtn.classList.remove('disabled');
            nextBtn.removeAttribute('aria-disabled');
            nextBtn.removeAttribute('tabindex');
        }
    }

    function disableNextButton() {
        if (nextBtn) {
            nextBtn.classList.add('disabled');
            nextBtn.setAttribute('aria-disabled', 'true');
            nextBtn.setAttribute('tabindex', '-1');
        }
    }

    getItButtons.forEach(button => {
        button.addEventListener('click', function (event) {
            event.stopPropagation();
            const parentCard = this.closest('.package-card');

            // Reset buttons
            getItButtons.forEach(btn => {
                btn.classList.remove('btn-success');
                btn.classList.add('btn-secondary');
                btn.closest('.package-card').classList.remove('selected');
            });

            // selected button
            parentCard.classList.add('selected');
            this.classList.remove('btn-secondary');
            this.classList.add('btn-success');

            selectedPackageInput.value = parentCard.getAttribute('data-value');
            enableNextButton();
        });
    });

    function checkInitialSelection() {
        const previouslySelectedId = packageForm.dataset.selectedPackageId; 
        if (previouslySelectedId && previouslySelectedId > 0) {
            selectedPackageInput.value = previouslySelectedId;
            const selectedCard = document.querySelector(`.package-card[data-value='${previouslySelectedId}']`);
            if (selectedCard) {
                selectedCard.classList.add('selected');
                const selectedButton = selectedCard.querySelector('button');
                if (selectedButton) {
                    // Ensure proper styling for previously selected button
                    selectedButton.classList.remove('btn-secondary');
                    selectedButton.classList.add('btn-success');
                    // Force the button to have the correct text
                    selectedButton.textContent = 'Get it';
                }
                enableNextButton();
            }
        } else {
            disableNextButton();
        }
    }

    checkInitialSelection();
});
