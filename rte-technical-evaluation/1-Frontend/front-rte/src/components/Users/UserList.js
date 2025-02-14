import React from 'react';
import { Link } from 'react-router-dom';

const Users = () => {
  return (
    <div>
      <h2>Lista de Usuários</h2>
      
      <Link to="create" className="btn btn-success mb-3">
        Criar Novo Usuário
      </Link>
      
      <table className="table">
        <thead>
          <tr>
            <th>ID</th>
            <th>Nome</th>
            <th>Email</th>
          </tr>
        </thead>
        <tbody>
          {/* Exemplo de dados */}
          <tr>
            <td>1</td>
            <td>Usuário 1</td>
            <td>usuario1@example.com</td>
          </tr>
          <tr>
            <td>2</td>
            <td>Usuário 2</td>
            <td>usuario2@example.com</td>
          </tr>
        </tbody>
      </table>
    </div>
  );
};

export default Users;