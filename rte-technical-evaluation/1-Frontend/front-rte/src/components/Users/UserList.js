import React, { useEffect, useState } from 'react';
import api from '../../api';
import { Link } from 'react-router-dom';

const Users = () => {
  const [usuarios, setUsuarios] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchUsuarios = async () => {
        try {
          const token = localStorage.getItem('authToken');
          const response = await api.get('usuarios', {
            headers: {
              'Authorization': `Bearer ${token}`,
              'Content-Type': 'application/json'
            }
          });

          setUsuarios(response.data.apiResultData);
        } catch (err) {
            setError(err);
        } finally {
            setLoading(false);
        }
    };

    fetchUsuarios();
}, []);


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
            <th>Login</th>
            <th>Senha</th>
          </tr>
        </thead>
        <tbody>
            {usuarios.map(usuario => (
                <tr key={usuario.id}>
                    <td>{usuario.id}</td>
                    <td>{usuario.login}</td>
                    <td>{usuario.senha}</td>
                </tr>
            ))}
        </tbody>
      </table>
    </div>
  );
};

export default Users;