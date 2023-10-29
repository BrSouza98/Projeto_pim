
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

function renderCep(data) {
    const cepHtml = document.querySelector("#cep");
    const rua = document.querySelector("#rua");
    const bairro = document.querySelector("#bairro")
    const cidade = document.querySelector("#cidade")
    const estado = document.querySelector("#estado")

    cepHtml.value = data.cep
    rua.value = data.logradouro
    bairro.value = data.bairro
    cidade.value = data.localidade
    estado.value = data.uf
}

const cepApi = (cep) => {
    const cepHtml = document.querySelector("#cep");
    cepHtml.value = cepMask(cep)
    let api = `https://viacep.com.br/ws/${cepHtml.value}/json/`
    

    if (cepHtml.value.length == 8) {
        fetch(api)
            .then((response) => {
                response.json().then((data) => {
                    if (data.erro == true) {
                        cepHtml.classList.add("border-danger");
                    } else {
                        cepHtml.classList.remove("border-warning")
                        cepHtml.classList.add("border-success")
                        renderCep(data)
                    }
                })
            })
    } else {
        if (!cepHtml.classList.contains("border-warning")) {
            cepHtml.classList.add("border-warning")
        }
    }
}

function cepMask(v) {
    v = v.replace(/\D/g, '');
    return v
}


function validarPIS(pis) {
    var multiplicadorBase = "3298765432";
    var total = 0;
    var resto = 0;
    var multiplicando = 0;
    var multiplicador = 0;
    var digito = 99;

    pisHtml = document.getElementById('pis')

    pisHtml.value = pis.replace(/[^\d]+/g, '');
    
    // Retira a mascara
    var numeroPIS = pis.replace(/[^\d]+/g, '');

    if (numeroPIS.length !== 11 || 
        numeroPIS === "00000000000" || 
        numeroPIS === "11111111111" || 
        numeroPIS === "22222222222" || 
        numeroPIS === "33333333333" || 
        numeroPIS === "44444444444" || 
        numeroPIS === "55555555555" || 
        numeroPIS === "66666666666" || 
        numeroPIS === "77777777777" || 
        numeroPIS === "88888888888" || 
        numeroPIS === "99999999999") {
        pisHtml.classList.add("border-danger");
       return false
    } else {
        for (var i = 0; i < 10; i++) {
            multiplicando = parseInt( numeroPIS.substring( i, i + 1 ) );
            multiplicador = parseInt( multiplicadorBase.substring( i, i + 1 ) );
            total += multiplicando * multiplicador;
        }

        //Ex: 170.33259.50-4
        pisHtml.value = pis.replace(/(\d{3})(\d{5})(\d{2})(\d)/, "$1.$2.$3-$4");

        resto = 11 - total % 11;
        resto = resto === 10 || resto === 11 ? 0 : resto;

        digito = parseInt("" + numeroPIS.charAt(10));

        if (resto === digito) {
         pisHtml.classList.add("border-success");
            pisHtml.classList.remove("border-danger");
         return true
        }
    }
}



