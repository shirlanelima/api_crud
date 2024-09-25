# API CRUD de Estudantes

Este é um projeto simples de uma API CRUD (Create, Read, Update, Delete) para gerenciar informações de estudantes. O projeto foi desenvolvido em C# utilizando o Entity Framework Core e o banco de dados SQLite.

## Funcionalidades

- **Criar**: Adicionar um novo estudante ao banco de dados.
- **Ler**: Obter uma lista de todos os estudantes ou buscar um estudante específico pelo ID.
- **Atualizar**: Atualizar as informações de um estudante existente.
- **Excluir**: Remover um estudante do banco de dados.

## Tecnologias Utilizadas

- **C#**: Linguagem de programação utilizada para desenvolver a API.
- **.NET Core**: Framework utilizado para criar a aplicação.
- **Entity Framework Core**: ORM (Object-Relational Mapping) utilizado para interagir com o banco de dados.
- **SQLite**: Banco de dados leve utilizado para armazenamento das informações.

## Estrutura do Projeto

- **Models**: Contém as classes que representam as entidades do banco de dados (neste caso, `Student`).
- **Data**: Contém o contexto do banco de dados (`AppDbContext`) e a configuração do Entity Framework.
- **Controllers**: Contém os controladores da API que definem os endpoints e as ações (CRUD) correspondentes.
- **Migrations**: Contém as migrações geradas pelo Entity Framework para manter o banco de dados sincronizado com os modelos.

## Endpoints

- **GET /api/students**: Retorna uma lista de todos os estudantes.
- **GET /api/students/{id}**: Retorna os detalhes de um estudante específico.
- **POST /api/students**: Adiciona um novo estudante.
- **PUT /api/students/{id}**: Atualiza as informações de um estudante existente.
- **DELETE /api/students/{id}**: Remove um estudante.
