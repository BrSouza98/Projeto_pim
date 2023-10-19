
/*Controla os formularios e botões exibidos na tela */
var FinCadBtn = document.getElementById('FinCadBtn');
var NextBtn = document.getElementById('NextBtn');
var PrevBtn = document.getElementById('PrevBtn');


var forms = {
    firstForm: {
        html: document.getElementById("firstForm"),
        state: true
    },

    secondForm: {
        html: document.getElementById("secondForm"),
        state: false
    },


    thirdForm: {
        html: document.getElementById("thirdForm"),
        state: false
    },

    showFirst: () => {
        forms.firstForm.state = true;
        forms.firstForm.html.classList.remove('d-none');

        forms.secondForm.state = false;
        forms.secondForm.html.classList.add('d-none');

        forms.thirdForm.state = false;
        forms.thirdForm.html.classList.add('d-none');
    },

    showSecond: () => {
        forms.firstForm.state = false;
        forms.firstForm.html.classList.add('d-none');

        forms.secondForm.state = true;
        forms.secondForm.html.classList.remove('d-none');

        forms.thirdForm.state = false;
        forms.thirdForm.html.classList.add('d-none');

    },

    showThird: () => {
        forms.firstForm.state = false;
        forms.firstForm.html.classList.add('d-none');

        forms.secondForm.state = false;
        forms.secondForm.html.classList.add('d-none');

        forms.thirdForm.state = true;
        forms.thirdForm.html.classList.remove('d-none');

    }
}


PrevBtn.addEventListener("click", () => {
    //Navega do terceiro form para o segundo
    if (forms.firstForm.state == false &&
        forms.secondForm.state == false &&
        forms.thirdForm.state == true) {

        forms.showSecond();

        if (!FinCadBtn.getAttribute("hidden")) {
            FinCadBtn.setAttribute("hidden", "hidden")
            FinCadBtn.parentElement.classList.add('d-none')
        }

        if (NextBtn.getAttribute("hidden")) {
            NextBtn.removeAttribute("hidden")
            NextBtn.parentElement.classList.remove('d-none')
        }
    }

    //Navega do segundo form para o primeiro
    else if (forms.firstForm.state == false &&
        forms.secondForm.state == true &&
        forms.thirdForm.state == false) { forms.showFirst(); }

    else {
        window.history.back();
    }
})

NextBtn.addEventListener("click", () => {
    //Navega do primeiro para o segundo
    if (forms.firstForm.state == true &&
        forms.secondForm.state == false &&
        forms.thirdForm.state == false) {
        forms.showSecond()
    }

    //Navega do segundo para o terceiro
    else if (forms.firstForm.state == false &&
        forms.secondForm.state == true &&
        forms.thirdForm.state == false) {
        forms.showThird()

        FinCadBtn.parentElement.classList.remove('d-none')
        FinCadBtn.removeAttribute("hidden")

        NextBtn.setAttribute("hidden", "hidden")
        NextBtn.parentElement.classList.add('d-none')
    }

    else {
        return
    }
})


//Interação com os switchs

const switchAcesso = document.getElementById("switchAcesso")
const inputPwd = document.getElementById("inputPwd")
const confirmInputPwd = document.getElementById("confirmInputPwd")

const toogle = (element) => {
    if (!element.classList.contains('d-none')) {
        element.classList.add('d-none')
    } else {
        element.classList.remove('d-none')
    }
}

switchAcesso.addEventListener("click", () => {
    toogle(inputPwd);
    toogle(confirmInputPwd);
})







