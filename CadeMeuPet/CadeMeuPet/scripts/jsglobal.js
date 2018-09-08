var modal = document.getElementById('modal-wrapper');
window.onclick = function (event) {
    if (event.target == modal) {
        $("#conta").show();
        modal.style.display = "none";
    }
}