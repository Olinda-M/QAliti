// Funkcja do przewijania strony na górę
function scrollToTop() {
    const navbarHeight = document.querySelector('.top-navbar').offsetHeight;  // Pobierz wysokość navbaru
    window.scrollTo({
        top: 0 - navbarHeight,  // Zanim przewiniemy na górę, odejmujemy wysokość navbaru
        behavior: 'smooth'      // Płynne przewijanie
    });
}
