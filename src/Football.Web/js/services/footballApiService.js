import '../../styles/app.scss'
import { HandlerErros } from "../shared/index.js";
import { MDCTextField } from '../../node_modules/@material/textfield/index.js';
import { MDCDialog } from '../../node_modules/@material/dialog';

class FootballApiService  {
    
    constructor() {
        this.url  = 'https://localhost:5001/api';
        this.competicoes = [];
        this.classificacoes = [];
        this.elCompetitions = document.getElementsByClassName('l-competitions');
        new MDCTextField(document.querySelector('.textfield-search-bar'));
        this.dialog = new MDCDialog(document.querySelector('.mdc-dialog'));
    }
   
    obterTodasCompeticoes() {
        return fetch(`${this.url}/competition`, {
            method: 'GET',
            mode: 'cors',
            cache: 'no-cache',
            credentials: 'same-origin',
            accept: 'application/json',
            headers: new Headers({
                'Access-Control-Allow-Origin': '*',
                'Access-Control-Allow-Methods': '*',
                'Access-Control-Allow-Credentials': 'true',
                'Access-Control-Request-Method': '*',
                'Access-Control-Allow-Headers': 'Origin'       
            })
        }
         
        )
        .then(response => HandlerErros(response))
        .then(response => response.json())
        .then(response => {
            this.competicoes = response;
            this.renderTodasCompeticoes();
        });
    }

    renderTodasCompeticoes(){
        this.competicoes.forEach(competicao => {
            this.elCompetitions[0].innerHTML += `
                <div class="competitions__card" data-id="${competicao.id}" data-name="${competicao.name}" data-area="${competicao.area.name}"> 
                    <div class="competitions__header" >${competicao.area.name}</div> 
                    <div class="competitions__wrapper-name" style="margin: auto;">
                        <h3 class="competitions__name" id="cod_${competicao.id}"> ${competicao.id} - ${competicao.name} </h3> 
                    </div> 
                </div>
            `;
            
        });

        
        // evento para abrir os modais após clique nos cards de competição
        var self = this;
            document.querySelectorAll('.competitions__card').forEach(
            value => value.addEventListener('click', function() {
                self.openModal(value);
            }, false)
        );
        
        // implementação do comportamento da barra de pesquisas
        document.querySelector('.textfield-search-bar').addEventListener('keyup', function (e) {  
            
            [...document.getElementsByClassName('competitions__card')].forEach( item => {
                if(item.textContent.toLowerCase().includes(e.target.value.toLowerCase()))
                    item.style.display = "";
                else
                    item.style.display = "none";
            });
        });
    }

    obterClassificacaoPorCompeticao (competicaoId) {
        return fetch(`${this.url}/standings/obter-classificacao-por-competicao/${competicaoId}`, {
            method: 'GET',
            mode: 'cors',
            cache: 'no-cache',
            credentials: 'same-origin', 
            headers: new Headers({
                'Access-Control-Allow-Origin': '*',
                'Access-Control-Allow-Methods': '*',
                'Access-Control-Allow-Credentials': 'true',
                'Access-Control-Request-Method': '*',
                'Access-Control-Allow-Headers': 'Origin'                   
            })
        })
        .then(response => HandlerErros(response))
        .then(response => response.json())
        .then(response => { 
            this.classificacoes = response; 
            this.renderClassificacaoPorCompeticao();
            this.dialog.open();
        })
    }

    renderClassificacaoPorCompeticao() {
        document.getElementById('tbody-standings').innerHTML = "";
        this.classificacoes.forEach((linha) => {
            document.getElementById('tbody-standings').innerHTML +=  `<tr> <td>${linha.position}</td> <td>${linha.team.name}</td> <td>${linha.won}</td> <td>${linha.draw}</td> <td>${linha.lost}</td> <td>${linha.points}</td></tr>`;
        });
    }

    openModal(elementCompetitionCard) {
        const competitionId = elementCompetitionCard.getAttribute('data-id');
        const competitionName = elementCompetitionCard.getAttribute('data-name');
        document.getElementById('dialog__title').innerHTML = `<b>${competitionName}</b>`;
        this.obterClassificacaoPorCompeticao(competitionId);
    }
}

export default FootballApiService;