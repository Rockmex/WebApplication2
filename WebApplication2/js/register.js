﻿const inputs = document.querySelectorAll(".input");

/*--Add "focus" to class name--*/
function addcl() {
    let parent = this.parentNode.parentNode;
    parent.classList.add("focus");
}

/*--Remove "focus" from class name--*/
function remcl() {
    let parent = this.parentNode.parentNode;
    if (this.value == "") {
        parent.classList.remove("focus");
    }
}

/*Checks event status*/
inputs.forEach(input => {
    input.addEventListener("focus", addcl);
    input.addEventListener("blur", remcl);
});

/*Alert Message*/
var alertMsg = document.getElementById('ContentPlaceHolder1_errorMessageHidden');
if (alertMsg != null) {
    if (alertMsg.value != "") {
        alert(alertMsg.value);
        window.location.href = 'Register.aspx';
    }
}