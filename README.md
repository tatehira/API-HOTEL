<!DOCTYPE html>
<html lang="pt-br">
<head>
  <meta charset="UTF-8">
</head>
<body>

<h1>API de Hotel</h1>

<p>Esta API permite criar, atualizar, excluir e obter hotéis e quartos. Você também pode criar reservas para quartos.</p>

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
