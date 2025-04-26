
function scrollToTop() {
    const navbarHeight = document.querySelector('.top-navbar').offsetHeight;  
    window.scrollTo({
        top: 0 - navbarHeight,  
        behavior: 'smooth'      
    });
}
