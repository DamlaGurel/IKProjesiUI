const passwordInput = document.getElementById('Password');
const showPasswordCheckbox = document.getElementById('showPassword');
const showPasswordIconLock = document.getElementById('showPasswordIconLock');

showPasswordCheckbox.addEventListener('change', function () {
    if (this.checked) {
        passwordInput.type = 'text';
        showPasswordIconLock.className = 'fa-solid fa-lock-open';
    } else {
        passwordInput.type = 'password';
        showPasswordIconLock.className = 'fas fa-lock';
    }
});


const passwordInput = document.getElementById('ConfirmPassword');
const showPasswordCheckbox = document.getElementById('showPassword');
const showPasswordIconLock = document.getElementById('showPasswordIconLock');

showPasswordCheckbox.addEventListener('change', function () {
    if (this.checked) {
        passwordInput.type = 'text';
        showPasswordIconLock.className = 'fa-solid fa-lock-open';
    } else {
        passwordInput.type = 'password';
        showPasswordIconLock.className = 'fas fa-lock';
    }
});