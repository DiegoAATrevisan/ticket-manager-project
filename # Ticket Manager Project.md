# Ticket Manager Project

Projeto para gerenciamento de tickets, com foco em organização, acompanhamento e atualização de chamados.

## Requisitos

- C# Dev Kit instalado
- PotgreSQL instalado e configurado

## Como rodar o projeto

### 1. Configurar variáveis de ambiente
Adicione arquivo de ambiente .env dentro da pasta ticket-manager e ajuste os parametros de acordo com a conexão do seu banco.

POSTGRES_CONNECTION_STRING=Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=senha;Encoding=UTF8;

### 2. Crie as tabelas do banco 

Utilize o script fornecido na raiz desse repositório.


### 2. Iniciar em modo de desenvolvimento

Acesse a pasta TicketManagerWeb no seu terminal utilizazando o comando:
```
cd ./TicketManagerWeb/
```

e então rode o comando:
```
dotnet run
```
## Como o projeto funciona

O projeto centraliza o fluxo de tickets em uma aplicação única. Em geral, ele segue esta ideia:

- **Criação de tickets**: um ticket é aberto com dados básicos do chamado.
- **Listagem e consulta**: os tickets podem ser visualizados e filtrados.
- **Atualização de status**: cada ticket pode mudar de estado ao longo do atendimento.
- **Organização da lógica**: a aplicação separa interface, regras de negócio e persistência de dados.
