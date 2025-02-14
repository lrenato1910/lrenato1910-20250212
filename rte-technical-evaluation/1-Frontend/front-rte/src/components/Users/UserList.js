import React, { useEffect, useState, useRef } from 'react';
import api from '../../api';
import { Link } from 'react-router-dom';

const Users = () => {
  const hasMounted = useRef(false);
  const [usuarios, setUsuarios] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    if (hasMounted.current) return;
    hasMounted.current = true;

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
  <div className="container mt-5">
      <h2 className="text-center mb-4">Lista de Usuários</h2>
      
      <Link to="create" className="btn btn-outline-success mb-3">
          Criar Novo Usuário
      </Link>
      
      <div className="mb-3">
          <table className="table table-striped table-bordered table-hover shadow">
              <thead className="table-light">
                  <tr>
                    <th>#</th>
                    <th>ID</th>
                    <th>Login</th>
                    <th>Senha</th>
                    <th>Status</th>
                  </tr>
              </thead>
              <tbody>
                  {usuarios.map(usuario => (
                      <tr key={usuario.id}>
                          <td className='col-2'>
                            <Link to={`./edit/${usuario.id}`} className="btn btn-warning btn-sm">Editar</Link>
                            <Link to={`./delete/${usuario.id}`} className="btn btn-danger btn-sm">Excluir</Link>
                          </td>
                          <td className='col-1'>{usuario.id}</td>
                          <td className='col-4'>{usuario.login}</td>
                          <td className='col-4'>{usuario.senha}</td>
                          <td className='col-2'>
                            {usuario.ativo ? (<span className="badge bg-success">Ativo</span>) : (<span className="badge bg-danger">Inativo</span>)}                       
                          </td>
                      </tr>
                  ))}
                  {usuarios.length === 0 && (
                      <tr>
                          <td colSpan="3" className="text-center">Nenhum usuário encontrado.</td>
                      </tr>
                  )}
              </tbody>
          </table>
      </div>      
  </div>
);
};

export default Users;