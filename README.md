**Instruções de como rodar o projeto**
- Baixar o código pela url: https://github.com/victoreiras/frogpay-teste/tree/master
- Executar o Docker
- Rodar o comando: docker compose --project-name frogpay up -d

**O que foi feito**
- CRUD para pessoa, dados bancários, endereço e loja.
- Endpoint para consultar os dados bancário e endereço da pessoa pelo atributo do “id_pessoa”;
- Endpoint para consultar o endereço a partir de uma parte do nome da pessoa.
- Mecanismo de autorização e autenticação

**O que não foi feito**
- Testes unitários
