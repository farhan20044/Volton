document.addEventListener('DOMContentLoaded', function () {
    const onBoardingForm = document.getElementById('onBoardingForm');
    if (!onBoardingForm)
        return;

    const optionCards = document.querySelectorAll('.option-card');
    const contentSections = {
        'home': document.getElementById('homeContent'),
        'business': document.getElementById('businessContent'),
        'appartment': document.getElementById('appartmentContent')
    };
    const selectedOptionInput = document.getElementById('selectedOption');
    const nextBtn = document.getElementById('nextBtn');

    function checkValidation() {
        const selectedCard = document.querySelector('.option-card.selected');
        if (!selectedCard) {
            disableNextButton();
            return;
        }

        const selectedValue = selectedCard.getAttribute('data-value');
        const activeContent = contentSections[selectedValue];

        if (!activeContent) {
            disableNextButton();
            return;
        }

        const radioGroups = [...new Set([...activeContent.querySelectorAll('input[type="radio"]')].map(r => r.name))];
        const allGroupsSelected = radioGroups.every(groupName => activeContent.querySelector(`input[name="${groupName}"]:checked`));

        if (allGroupsSelected) {
            enableNextButton();
        } else {
            disableNextButton();
        }
    }

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

    optionCards.forEach(card => {
        card.addEventListener('click', function (e) {
            // Check the radio input inside the label
            const radio = this.querySelector('input[type="radio"]');
            if (radio) {
                radio.checked = true;
            }

            // Remove .selected from all, add to this
            optionCards.forEach(c => c.classList.remove('selected'));
            this.classList.add('selected');

            const selectedValue = this.getAttribute('data-value');
            const selectedId = this.getAttribute('data-id');
            selectedOptionInput.value = selectedValue;
            document.getElementById('selectedPlanId').value = selectedId;

            Object.values(contentSections).forEach(section => section.style.display = 'none');
            if (contentSections[selectedValue]) {
                contentSections[selectedValue].style.display = 'block';
            }

            checkValidation();
        });

        // Also handle keyboard selection of the radio
        const radio = card.querySelector('input[type="radio"]');
        if (radio) {
            radio.addEventListener('change', function () {
                optionCards.forEach(c => c.classList.remove('selected'));
                card.classList.add('selected');
                checkValidation();
            });
        }
    });

    Object.values(contentSections).forEach(section => {
        if (section) {
            section.querySelectorAll('input[type="radio"]').forEach(radio => {
                radio.addEventListener('change', checkValidation);
            });
        }
    });

    function checkInitialSelection() {
        const previouslySelectedId = onBoardingForm.dataset.selectedPlanId;
        if (previouslySelectedId && previouslySelectedId > 0) {
            const selectedCard = document.querySelector(`.option-card[data-id='${previouslySelectedId}']`);
            if (selectedCard) {
                selectedCard.click();
                // After clicking the card, check validation to handle pre-selected radio buttons
                setTimeout(() => {
                    checkValidation();
                }, 100);
            }
        } else {
            checkValidation();
        }
    }

    checkInitialSelection();
});
