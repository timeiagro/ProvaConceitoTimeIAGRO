Um cliente tem necessidade de buscar livros em um catálogo. Esse cliente quer ler e buscar esse catálogo de um arquivo JSON, e esse arquivo não pode ser modificado. Então com essa informação, é preciso desenvolver:

- Criar uma API para buscar produtos no arquivo JSON disponibilizado.
- Que seja possível buscar livros por suas especificações(autor, nome do livro ou outro atributo)
- É preciso que o resultado possa ser ordenado pelo preço.(asc e desc)
- Disponibilizar um método que calcule o valor do frete em 20% o valor do livro.

Será avaliado no desafio:

- Organização de código;
- Manutenibilidade;
- Princípios de orientação à objetos;
- Padrões de projeto;
- Teste unitário

Para nos enviar o código, crie um fork desse repositório e quando finalizar, mande um pull-request para nós.

O projeto deve ser desenvolvido em C#, utilizando o .NET Core 3.1 ou superior.

Gostaríamos que fosse evitado a utilização de frameworks, e que tivesse uma explicação do que é necessário para funcionar o projeto e os testes.

## Finalização do teste Time IAGRO

Olá, me chamo Fabrizio Rodrigues e sou Desenvolvedor de Softwares há mais de 14 anos. Não tenho apego a linguagens de programação e paradigmas de desenvolvimento, o meu intuito é fazer a coisa acontecer e da forma mais simples e objetiva possível!

Tenho experiência nas linguagens C#, JavaScript, NodeJS, Python e PHP e mais um punhado de tecnologias e frameworks. 
Segue o teste com os quesitos descritos contemplados a contento. Fiz de forma que pudesse apresentar as habilidades OOP, Design Patterns, Tests, Clean Code e manutenabilidade.

## Ferramentas utilizadas:

- Visual Studio Community 2022;
- Target Framework .NET Core 3.1 LTS em todas as Class libraries e WebAPI;
- Swagger para apresentar a documentação da API.

## Bibliotecas do NuGet que foram utilizadas:

- Swashbuckle.AspNetCore 6.3.1 (IAGRO.API);
- Swashbuckle.AspNetCore.Swagger 6.3.1 (IAGRO.API);
- Microsoft.Extensions.DependencyInjection.Abstractions 6.0.0 (IAGRO.Application);coverlet.collector 1.2.0 (IAGRO.Application.Tests);
- Microsoft.NET.Test.Sdk 16.5.0 (IAGRO.Application.Tests);
- xunit 2.4.0 (IAGRO.Application.Tests);
- xunit.runner.visualstudio 2.4.0 (IAGRO.Application.Tests).

## Objetivos alcançados:

- Criar uma API para buscar produtos no arquivo JSON disponibilizado - **OK**;
- Que seja possível buscar livros por suas especificações(autor, nome do livro ou outro atributo) - **OK**;
- É preciso que o resultado possa ser ordenado pelo preço.(asc e desc) - **OK**;
- Disponibilizar um método que calcule o valor do frete em 20% o valor do livro - **OK**;
- Esse cliente quer ler e buscar esse catálogo de um arquivo JSON, e esse arquivo não pode ser modificado - **OK**;
- Organização de código - **OK**;
- Manutenibilidade - **OK**;
- Princípios de orientação à objetos - **OK**;
- Padrões de projeto - **OK**;
- Teste unitário - **OK**;
- O projeto deve ser desenvolvido em C#, utilizando o .NET Core 3.1 ou superior - **OK**;
- Gostaríamos que fosse evitado a utilização de frameworks - **OK**.

## Para executar este projeto

1. Instalar as bibliotecas do NuGet nas versões utilizadas ou superiores (pode ocorrer alguma incompatibilidade) já mencionadas;
2. Fazer o Rebuild da solução;
3. Para executar todos os testes, basta clicar com o botão direito sobre o projeto IAGRO.Application.Tests e selecionar a opção “Run Tests” e observar os resultados;
4. Finalmente executar o projeto IAGRO.API e navegar pelas api’s pelo Swagger.
