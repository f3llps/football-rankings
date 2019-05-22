const HandleErros = function (response) {
    if (!response.ok) {
        alert('Houve um erro na requisição.');
    }
    return response;
}

export default HandleErros