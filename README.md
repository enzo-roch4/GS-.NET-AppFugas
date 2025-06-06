
# GS-.NET-AppFugas
# API de Rotas de Fuga para Desastres Naturais — GS-.NET

## Descrição do Projeto
Este projeto consiste em uma API desenvolvida em **.NET 6/8** que funciona como backend do nosso app de rotas de fugas para desastres naturais (enchentes, terremotos, etc). A API auxilia usuários a encontrar as melhores rotas de fuga por meio do cadastro e consulta de pontos no mapa (ponto A e ponto B).

Além do CRUD tradicional, a arquitetura utiliza **microserviços** para processamento assíncrono de mensagens via **RabbitMQ**, garantindo escalabilidade e desacoplamento. Também incorporamos uma análise de sentimentos usando **ML.NET**, enriquecendo a solução com inteligência artificial para avaliar feedbacks ou comentários dos usuários.

A documentação dos endpoints é apresentada via **Swagger** e o projeto conta com cobertura de testes automatizados utilizando **xUnit**.

---

## Tecnologias Utilizadas

- **.NET 6/8** (.NET Core) para desenvolvimento backend  
- **Entity Framework Core** para acesso a dados  
- **Oracle SQL** como banco de dados relacional  
- **RabbitMQ** para comunicação assíncrona via microserviços  
- **ML.NET** para análise de sentimentos  
- **Swagger** para documentação automática dos endpoints REST  
- **xUnit** para testes unitários e de integração  

---

## Como Executar o Projeto

### Pré-requisitos

- .NET SDK 6 ou superior instalado  
- Banco de dados Oracle configurado com o esquema necessário  
- Docker instalado para rodar RabbitMQ (ou RabbitMQ instalado localmente)

### Passos

1. **Rodar RabbitMQ** (via Docker):


    docker run -d --hostname rabbit --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management

## Configurar Banco Oracle

Configure o esquema e atualize a string de conexão no arquivo appsettings.json do projeto API.

Executar a API principal:

    cd API.NET
    dotnet run

Acesse a documentação Swagger em:
https://localhost:7040/swagger/index.html

![image](https://github.com/user-attachments/assets/d3641501-e602-482e-b5e1-9a7981df7908)




## Executar Microserviços (Producer e Consumer):

Em terminais separados, navegue até as pastas dos microserviços e execute:

   
    cd MicroServices/ProducerService
    dotnet run
    
    cd MicroServices/ConsumerService
    dotnet run

# # Documentação dos Endpoints

## Usuário

    POST /api/usuario/cadastrar

*Cadastra um novo usuário no sistema.*

    GET /api/usuario/buscar/{id}

*Retorna informações do usuário pelo ID*.

    PUT /api/usuario/atualizar/{id}

*Atualiza dados do usuário.*

    DELETE /api/usuario/apagar/{id}

*Remove usuário do sistema.*

# Rotas de Fuga

    POST /api/rotas/cadastrar

*Registra pontos A e B no mapa com descrição para rotas de fuga.*

    GET /api/rotas/buscar/{id}

*Consulta rota pelo ID.*

    PUT /api/rotas/atualizar/{id}

*Atualiza informações da rota.*

    DELETE /api/rotas/apagar/{id}

*Remove rota do sistema.*

# Cobertura de Testes

Validação dos endpoints REST da API

Testes de integração para os microserviços com RabbitMQ

Testes unitários das funções de análise de sentimento implementadas com ML.NET

# Observações Finais

*A comunicação entre microserviços ocorre via RabbitMQ, garantindo escalabilidade e resiliência.
A análise de sentimentos via ML.NET está integrada para avaliar comentários ou feedbacks, podendo ser expandida conforme o projeto.*

![image](https://github.com/user-attachments/assets/847c08eb-e000-477b-9473-62eb7ef384f7)



# Autores

***Enzo Franco - RM: 553643
Herbert Santos de Sousa - RM: 553227
João Pedro Pereira - RM: 553698***


