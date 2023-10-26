/*
Scripts com as interações da página
De cadastro e edição de funcionario
*/


//scripts para a funcionalidade dos botoes avançar e voltar do form
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
        forms.showSecond()

        FinCadBtn.parentElement.classList.add("d-none")
        NextBtn.parentElement.classList.remove('d-none')
       
    }

    //Navega do segundo form para o primeiro
    else if (forms.firstForm.state == false &&
        forms.secondForm.state == true &&
        forms.thirdForm.state == false) {
        forms.showFirst()
    }

    else {
        window.history.back()
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
        forms.showThird();

        FinCadBtn.parentElement.classList.remove("d-none")
        NextBtn.parentElement.classList.add('d-none')
    }
})



//Script para o Switch mostrar e ocultar a senha


const SwitchAcesso = document.getElementById('SwitchAcesso');
var PasswordDiv = document.getElementById('PasswordDiv')
var toggleVar = false

const togglePwrdDiv = () => {
    if (toggleVar) {
        PasswordDiv.classList.remove('d-none')
        console.log(toggleVar)
    } else {
        PasswordDiv.classList.add('d-none')
        console.log(toggleVar)
    }
}

SwitchAcesso.addEventListener("click", () => {
    toggleVar = !toggleVar
    togglePwrdDiv()
    
})


