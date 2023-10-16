
const handlePhone = (event) => {
    let input = event.target
    input.value = phoneMask(input.value)
}

const handleCpf = (event) => {
    let input = event.target
    input.value = cpfMask(input.value)
}

const handleRg = (event) => {
    let input = event.target
    input.value = rgMask(input.value)
}

const handleValEmail = (event) => {
    validaEmail(event.value)
}
const handleCep = (event) => {
    let input = event.target
    input.value = cepMask(input.value)
}


/* Mascaras Regex */
const phoneMask = (value) => {
    if (!value) return ""
    value = value.replace(/\D/g, '')
    value = value.replace(/(\d{2})(\d)/, "($1) $2")
    value = value.replace(/(\d)(\d{4})$/, "$1-$2")
    return value
}

function cpfMask(v) {
    if (!v) return ""
    v = v.replace(/\D/g, '')                    //Remove tudo o que não é dígito
    v = v.replace(/(\d{3})(\d)/, "$1.$2")       //Coloca um ponto entre o terceiro e o quarto dígitos
    v = v.replace(/(\d{3})(\d)/, "$1.$2")       //Coloca um ponto entre o terceiro e o quarto dígitos
    v = v.replace(/(\d{3})(\d{1,2})$/, "$1-$2") //Coloca um hífen 
    return v
}

function rgMask(v) {
    v = v.replace(/\D/g, ""); //Substituí o que não é dígito por "", /g é [Global][1]
    v = v.replace(/(\d{2})(\d{3})(\d{3})(\d)/, "$1.$2.$3-$4")
    // \d{1,2} = Separa 1 grupo de 1 ou 2 carac. (\d{3}) = Separa 1 grupo de 3 carac. (\d{1}) = Separa o grupo de 1 carac.
    // "$1.$2.$3-$4" = recupera os grupos e adiciona "." após cada.

    return v
}

function cepMask(v) {
    v = v.replace(/\D/g, '');
    v = v.replace(/(\d{5})(\d{3})/, "$1-$2")

    return v
}


/*Valida Email*/
function validaEmail(v) {
    email = document.getElementById("Email").value

    return v == email
}
