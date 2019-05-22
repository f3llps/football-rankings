import HandleErros from '../shared/Index.js'

const elCompetitions = document.getElementsByClassName('l-competitions');
// const url = 'https://localhost:5001/api';
const url = 'https://localhost:44344/api';

let competicoes = [];
let classificacoes = [];

const dialog = mdc.dialog.MDCDialog.attachTo(document.querySelector('.mdc-dialog'));

function openModal(elementCompetitionCard){
    const competitionId = elementCompetitionCard.getAttribute('data-id');
    const competitionName = elementCompetitionCard.getAttribute('data-name');
    document.getElementById('dialog__title').innerHTML = `<b>${competitionName}</b>`;
    listarClassificacaoPorCompeticao(competitionId)
}

function renderListarTodasCompeticoes(){
    competicoes.forEach(competicao => {
        elCompetitions[0].innerHTML += `
            <div class="competitions__card" data-id="${competicao.id}" data-name="${competicao.name}" data-area="${competicao.area.name}"> 
                <div class="competitions__header" >${competicao.area.name}</div> 
                <div class="competitions__wrapper-name" style="margin: auto;">
                    <h3 class="competitions__name" id="cod_${competicao.id}"> ${competicao.id} - ${competicao.name} </h3> 
                </div> 
            </div>
        `;
    });

    document.querySelectorAll('.competitions__card').forEach(
        value => value.addEventListener('click', function() {openModal(this);}, false)
        );

    document.querySelector('.textfield-search-bar').addEventListener('keyup', function (e) {  
        
        [...document.getElementsByClassName('competitions__card')].forEach( item => {
            if(item.textContent.toLowerCase().includes(e.target.value.toLowerCase()))
                item.style.display = "";
            else
                item.style.display = "none";
        });
    });
};

function renderListarClassificacaoPorCompeticao(){
    document.getElementById('tbody-standings').innerHTML = "";
    classificacoes.forEach((linha) => {
        document.getElementById('tbody-standings').innerHTML +=  `<tr> <td>${linha.position}</td> <td>${linha.team.name}</td> <td>${linha.won}</td> <td>${linha.draw}</td> <td>${linha.lost}</td> <td>${linha.points}</td></tr>`;
    });
}

function listarTodasCompeticoes() {
    return fetch(`${url}/competition`)
        .then(HandleErros)
        .then(response => response.json())
        .then(response => {
            competicoes = response;
            renderListarTodasCompeticoes();
        })
};

function listarCompeticaoPorId(competicaoId) {
    return fetch(`${url}/competition/${competicaoId}`)
        .then(HandleErros)
        .then(response => response.json())
        .then(response => { competicoes = response; })
};

function listarClassificacaoPorCompeticao (competicaoId) {
    return fetch(`${url}/standings/obter-classificacao-por-competicao/${competicaoId}`)
        .then(HandleErros)
        .then(response => response.json())
        .then(response => { 
            classificacoes = response; 
            renderListarClassificacaoPorCompeticao();
            dialog.open();
        })
};

(function () {
    listarTodasCompeticoes();
    Toastify({
        text: "Clique em um card para ver a classificação do seu campeonato favorito.",
        duration: 7000,
        newWindow: true,
        close: true,
        gravity: "bottom", // `top` or `bottom`
        positionLeft: true, // `true` or `false`
        backgroundColor: "linear-gradient(to right top, #91b1e1, #82bbd2, #92c0bf, #acc0b4, #bec0b9);",
        stopOnFocus: true // Prevents dismissing of toast on hover
      }).showToast();
})();
