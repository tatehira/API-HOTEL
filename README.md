<!DOCTYPE html>
<html lang="pt-br">
<head>
  <meta charset="UTF-8">
</head>
<body>

<h1>API de Hotel</h1>

<h2>Esta API permite criar, atualizar, excluir e obter hotéis e quartos. Você também pode criar reservas para quartos.</h2>

<h3>A estrutura da sua API é a seguinte:</h3>

<ul>
  <li><strong>Controller</strong>: Os controllers são responsáveis por lidar com as solicitações HTTP e retornar as respostas.</li>
  <li><strong>Data</strong>: O diretório Data contém o contexto de dados e os modelos de dados.</li>
  <li><strong>Models</strong>: Os modelos de dados representam os dados que são armazenados no banco de dados.</li>
  <li><strong>appsettings.json</strong>: O arquivo appsettings.json contém as configurações da API, como a string de conexão do banco de dados.</li>
  <li><strong>program</strong>: O arquivo program é o ponto de entrada da API.</li>
</ul>

<p>O contexto de dados é uma classe que fornece acesso ao banco de dados. Ele é herdado da classe DbContext do Entity Framework Core.</p>

<p>Os modelos de dados são classes que representam os dados que são armazenados no banco de dados. Eles são anotados com atributos do Entity Framework Core para indicar como os dados são mapeados para as tabelas do banco de dados.</p>

<p>O arquivo appsettings.json contém as configurações da API, como a string de conexão do banco de dados.</p>

<p>O arquivo program é o ponto de entrada da API. Ele inicia o servidor da API e registra os controllers.</p>


<p>Os seguintes pacotes estão instalados no projeto:</p>

<ul>
  <li><strong>Mapster</strong>: Um pacote que permite mapear objetos .NET para modelos JSON.</li>
  <li><strong>Microsoft.AspNetCore.OpenApi</strong>: Um pacote que permite gerar e consumir APIs abertas.</li>
  <li><strong>Microsoft.EntityFrameworkCore</strong>: Um pacote que fornece um ORM para o .NET Core.</li>
  <li><strong>Microsoft.EntityFrameworkCore.Design</strong>: Um pacote que fornece suporte para o design de modelos de dados no Visual Studio.</li>
  <li><strong>Microsoft.EntityFrameworkCore.SqlServer</strong>: Um pacote que fornece um adaptador para o SQL Server.</li>
  <li><strong>Microsoft.EntityFrameworkCore.Tools</strong>: Um pacote que fornece ferramentas para o desenvolvimento de aplicativos EF Core.</li>
  <li><strong>Swashbuckle.AspNetCore</strong>: Um pacote que fornece suporte para a documentação de APIs.</li>
</ul>

<p>Para obter mais informações sobre esses pacotes, consulte os links abaixo:</p>

<ul>
  <li><a href="https://docs.microsoft.com/en-us/dotnet/api/mapster">Mapster</a></li>
  <li><a href="https://docs.microsoft.com/en-us/aspnet/core/mvc/open-api">Microsoft.AspNetCore.OpenApi</a></li>
  <li><a href="https://docs.microsoft.com/en-us/ef/core/providers/sqlserver">Microsoft.EntityFrameworkCore</a></li>
  <li><a href="https://docs.microsoft.com/en-us/ef/core/design/visual-studio">Microsoft.EntityFrameworkCore.Design</a></li>
  <li><a href="https://docs.microsoft.com/en-us/ef/core/providers/sqlserver">Microsoft.EntityFrameworkCore.SqlServer</a></li>
  <li><a href="https://docs.microsoft.com/en-us/ef/core/tools">Microsoft.EntityFrameworkCore.Tools</a></li>
  <li><a href="https://docs.swashbuckle.io/">Swashbuckle.AspNetCore</a></li>
</ul>


<h2>Pontos de extremidade</h2>

<table>
  <thead>
    <tr>
      <th>Ponto de extremidade</th>
      <th>Descrição</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><code>GET /hotels</code></td>
      <td>Obter todos os hotéis.</td>
    </tr>
    <tr>
      <td><code>GET /hotels/{id}</code></td>
      <td>Obter um hotel pelo ID.</td>
    </tr>
    <tr>
      <td><code>POST /hotels</code></td>
      <td>Criar um novo hotel.</td>
    </tr>
    <tr>
      <td><code>PUT /hotels/{id}</code></td>
      <td>Atualizar um hotel pelo ID.</td>
    </tr>
    <tr>
      <td><code>DELETE /hotels/{id}</code></td>
      <td>Excluir um hotel pelo ID.</td>
    </tr>
    <tr>
      <td><code>GET /hotels/{id}/rooms</code></td>
      <td>Obter todos os quartos para um hotel pelo ID.</td>
    </tr>
    <tr>
      <td><code>POST /hotels/{id}/rooms</code></td>
      <td>Criar um novo quarto para um hotel pelo ID.</td>
    </tr>
    <tr>
      <td><code>PUT /hotels/{id}/rooms/{roomId}</code></td>
      <td>Atualizar um quarto para um hotel pelo ID.</td>
    </tr>
    <tr>
      <td><code>DELETE /hotels/{id}/rooms/{roomId}</code></td>
      <td>Excluir um quarto para um hotel pelo ID.</td>
    </tr>
    <tr>
      <td><code>POST /hotels/{id}/rooms/{roomId}/reservations</code></td>
      <td>Criar uma nova reserva para um quarto em um hotel pelo ID.</td>
    </tr>
  </tbody>
</table>

<h2>Corpos de solicitação e resposta</h2>

<table>
  <thead>
    <tr>
      <th>Ponto de extremidade</th>
      <th>Corpo da solicitação</th>
      <th>Corpo da resposta</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><code>GET /hotels</code></td>
      <td>Nenhum</td>
      <td>Uma lista de hotéis.</td>
    </tr>
    <tr>
      <td><code>GET /hotels/{id}</code></td>
      <td>Nenhum</td>
      <td>Um hotel pelo ID.</td>
    </tr>
    <tr>
      <td><code>POST /hotels</code></td>
      <td>Um objeto de hotel.</td>
      <td>O ID do novo hotel criado.</td>
    </tr>
    <tr>
      <td><code>PUT /hotels/{id}</code></td>
      <td>Um objeto de hotel.</td>
      <td>O objeto de hotel atualizado.</td>
    </tr>
    <tr>
      <td><code>DELETE /hotels/{id}</code></td>
      <td>Nenhum</td>
      <td>Nenhum.</td>
