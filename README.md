#  Football Rankings API 

O projeto foi elaborado por Fellipe Versiani, com as seguintes tecnologias: HTML5, CSS3 e Javascript com o Visual Code (frontend) e C# ASP.NET API CORE 2.2 com Visual Studio 2019 (backend)

### Screenshots


- Versões Mobile (Iphone 8 Plus):<p align="center">
  <img src="https://cdn1.imggmi.com/uploads/2019/5/24/2b2cee8847685a5cf94974f75bed670b-full.png" width="350"/>
  <img src="https://cdn1.imggmi.com/uploads/2019/5/24/f7539beb2ea77e5bd416e7856169e4da-full.png" width="350"/>
</p>

### Estrutura dos arquivos

```sh
├── screenshots
│   └── desktop_version_01.png
│   └── desktop_version_02.png
│   └── mobile_version_01.png
│   └── mobile_version_02.png
├── src
│   └── Football.Api
│   └── Football.Business
│   └── Football.Infra
│   └── Football.Web
├── tests
│   └── Football.Tests
├── Readme.md
└── Football.sln
```
## 1. Instruções especiais para build:
**1.1** Para executar a API desenvolvida acesse o diretório **Football.Api** por meio de um terminal e execute o seguinte comando:
>dotnet run

 Isto fará com que a API funcione  por padrão na porta **http://localhost:5001**

**1.2** Acesse o diretório **Fotball.Web** e para instalar as dependências do projeto front end execute:
>npm install

**1.3** Para executar um servidor para o front end execute:
>http-server

A página estará disponível em qualquer um dos links listados no output do terminal após execução do comando, no path /index. Ex: **http://127.0.0.0/index**

## 2. Outros:

### 1. Trabalhos futuros

Melhorar testes implementados com xUnit; 
Rrealizar testes de interface com C# Selenium Webdriver (https://www.seleniumhq.org/projects/webdriver/); 
Realizar testes com o Mocha (https://mochajs.org/) em conjunto com Chai Assertions (https://www.chaijs.com/);
Utilizar decorador para realizar o cache server side, facilitando a leitura ao "limpar" o código, como também replicar para outros métodos, permitindo maior perfomance à aplicação. 
Apenas em caso do projeto tender a crescer, refator da arquitetura do frontend, reimplementando o código com auxílio de um framework/library como Angular 2+, React ou  Vue, ferramentas já consolidadas no mercado. 

### 2. Tecnologias

Para o desenvolvimento deste projeto foram utilizadas, em resumo, as seguintes tecnologias:
- Para o frontend: 
	- HTML5 e CSS3 (Sass) - Utilização da metodologia BEM e CSS Grid (descartando utilização do Bootstrap, por exemplo), obtendo um código com maior clareza e um layout responsivo.	
	- **"Vanilla" Javascript (JS puro)**

O motivo de não escolher um framework moderno, tal como **Angular 2+, React ou Vue** foi devido as mínimas funcionabilidades existentes no frontend para a solução que foi apresentada.
Em resumo não foi necessário implementar CRUDS complexos, troca de mensagens entre componentes ou alguma outra feature atrelada aos framweworks modernos que pudesse agregar muito valor ao projeto. 
Outro ponto especificamente, é que objetivei aprimorar conhecimentos em Javascript, o que pode auxiliar no desenvolvimento, seja qual for o framework JS utilizado no frontend.
	
	
- Para o backend: 
	- **C# ASP .NET CORE 2.2 - Template API**
---

**Além disso, diversas bibliotecas de terceiros foram utilizadas, entre elas:**

### Node JS
Facilitar instalação do compilador Sass e http-server, bem como download dessas dependências <br/>
https://github.com/nodejs/node
---

### Newtonsoft.Json 12.0.2
Realizar parser do JSON consumido da APi FootballData.org <br/>
https://www.newtonsoft.com/json
---

### xUnit 2.4.1
Facilitar o desenvolvimento de testes <br/>
https://github.com/xunit/xunit
---

### Material Design 3.0.0
Melhorar a UI para o usuário <br/>
https://github.com/material-components/material-components-web/
---

### Toastify JS 
Melhorar a UX do usuário <br/>
https://apvarun.github.io/toastify-js/
---

### Autommaper 6.1.0
Auxiliar na arquitetura das ViewModels/DTO's <br/>
https://github.com/AutoMapper/AutoMapper
---

### FluentAssertions 5.6.0
Melhorar e facilitar o entendimento do código <br/>
https://github.com/fluentassertions
---

### Swagger 4.0.1
Documentar a aplicação <br/>
https://github.com/swagger-api/swagger-core
---