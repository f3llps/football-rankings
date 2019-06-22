import Toastify from '../../node_modules/toastify-js/src/toastify.js'
import '../../node_modules/toastify-js/src/toastify.css'

export function HandlerErros(response) {

        if (!response.ok) { 
        // console.log(response);
        Toastify({
            text: 'Houve um erro na requisição.',
            duration: 7000,
            newWindow: true,
            close: true,
            gravity: "bottom", 
            positionLeft: true,
            backgroundColor: "linear-gradient(to right top, #91b1e1, #82bbd2, #92c0bf, #acc0b4, #bec0b9);",
            stopOnFocus: true
          }).showToast();
    }

    return response;
}    
    


export function HandlerNotificacoes(mensagem){
    
    return Toastify({
        text: mensagem,
        duration: 7000,
        newWindow: true,
        close: true,
        gravity: "bottom", 
        positionLeft: true,
        backgroundColor: "linear-gradient(to right top, #91b1e1, #82bbd2, #92c0bf, #acc0b4, #bec0b9);",
        stopOnFocus: true 
    }).showToast();
}