var FinCadBtn = document.getElementById('FinCadBtn');
var NextBtn = document.getElementById('NextBtn');
var PrevBtn = document.getElementById('PrevBtn');


var CampoOutro = document.getElementById('CampoOutro');
var SelectGenero = document.getElementById('SelectGenero');

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

        if (FinCadBtn.classList.contains('d-none') == false) {
            FindCadBtn.classList.add('d-none');
        }
    },

    showSecond: () => {
        forms.firstForm.state = false;
        forms.firstForm.html.classList.add('d-none');

        forms.secondForm.state = true;
        forms.secondForm.html.classList.remove('d-none');

        forms.thirdForm.state = false;
        forms.thirdForm.html.classList.add('d-none');



        if (FindCadBtn.classList.contains('d-none') == false) {
            FindCadBtn.classList.add('d-none');
        }
    },

    showThird: () => {
        forms.firstForm.state = false;
        forms.firstForm.html.classList.add('d-none');

        forms.secondForm.state = false;
        forms.secondForm.html.classList.add('d-none');

        forms.thirdForm.state = true;
        forms.thirdForm.html.classList.remove('d-none');

        /* Mostra o botão FinCadastro*/
        FinCadBtn.classList.remove('d-none');
    }
}


PrevBtn.addEventListener("click", () => {
    //Navega do terceiro form para o segundo
    if (forms.firstForm.state == false &&
        forms.secondForm.state == false &&
        forms.thirdForm.state == true) { forms.showSecond(); }

    //Navega do segundo form para o primeiro
    else if (forms.firstForm.state == false &&
        forms.secondForm.state == true &&
        forms.thirdForm.state == false) { forms.showFirst(); }

    else {
        throw new DOMException("Nenhum formulário a ser mostrado");
    }
})

NextBtn.addEventListener("click", () => {
    //Navega do primeiro para o segundo
    if (forms.firstForm.state == true &&
        forms.secondForm.state == false &&
        forms.thirdForm.state == false) { forms.showSecond(); }

    //Navega do segundo para o terceiro
    else if (forms.firstForm.state == false &&
        forms.secondForm.state == true &&
        forms.thirdForm.state == false) { forms.showThird(); }

    else {
        throw new DOMException("Nenhum formulário a ser mostrado");
    }
})


