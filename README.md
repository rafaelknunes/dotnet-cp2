# Checkpoint 2 - MVC+DbContext

# Autor

- Rafael Klanfer Nunes
- RM 99791
- Turma: TDS-A 2024

---

# Descrição do Projeto

Desenvolver uma aplicação MVC usando .net core 7.0 ou superior.

A aplicação deverá ter ao menos uma controller HOME e uma de usuários (Login e cadastro).

- Um READ para validar LOGIN, busca por email e comparação de senha - 2 pontos;
- Um CREATE para salvar um cadastro - 2 pontos;
- Conexão com banco de dados funcional - 4 pontos;
- Aplicação funcionado sem erros - 1 ponto;
- Entrega do CP por link do github - 1 ponto;
- Implementação de um CRUD completo gerará um ponto coringa.
- Implementação de uma controller funcional Com CRUD além do básico do projeto gerará um ponto coringa

---

# Atenção

Arquivo appsettings.json foi ocultado no Git. Por favor, crie o seu com a estrutura:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "OracleConnection": "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=SEURM;Password=SUASENHA;"
  }
}
````
