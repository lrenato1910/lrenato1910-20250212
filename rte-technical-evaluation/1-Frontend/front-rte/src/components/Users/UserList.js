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

  const deleteItem = async (id) => {
    try {
      const response = await api.delete(`usuarios/${id}`, {
        headers: {
          'Authorization': `Bearer ${localStorage.getItem('authToken')}`,
          'Content-Type': 'application/json'
        }
      });

      if (response.status === 200) {  // Verifique se o status é 200
          // Atualizar a tabela removendo o item excluído
          setUsuarios(usuarios.filter(usuario => usuario.id !== id));
      } else {
          console.error('Erro ao excluir o item');
      }
    } catch (error) {
      console.error('Erro ao excluir o item', error);
    }
  };

  if (loading) return <div>Loading...</div>;
  if (error) return <div>Error: {error.message}</div>;

  return (
    <div className="container mt-5">
    <h2 className="text-center mb-4 text-primary">Lista de Usuários</h2>

    {/* Botão para criar novo usuário */}
    <Link to="create" className="btn btn-success mb-3">
      <i className="fas fa-plus me-2"></i>Criar Novo Usuário
    </Link>

    {/* Tabela de usuários */}
    <div className="table-responsive">
      <table className="table table-striped table-bordered table-hover shadow-lg">
        <thead className="table-dark">
          <tr>
            <th>Ações</th>
            <th>ID</th>
            <th>Login</th>
            <th>Senha</th>
            <th>Status</th>
          </tr>
        </thead>
        <tbody>
          {usuarios.map((usuario) => (
            <tr key={usuario.id} className="align-middle">
              <td className="col-2">
                <div className="d-flex gap-2">
                  <Link
                    to={`./edit/${usuario.id}`}
                    className="btn btn-warning btn-sm flex-grow-1"
                  >
                    <i className="fas fa-edit me-1"></i>Editar
                  </Link>
                  <button
                    className="btn btn-danger btn-sm flex-grow-1"
                    onClick={() => deleteItem(usuario.id)}
                  >
                    <i className="fas fa-trash me-1"></i>Excluir
                  </button>
                </div>
              </td>
              <td className="col-1">{usuario.id}</td>
              <td className="col-4">{usuario.login}</td>
              <td className="col-4">{usuario.senha}</td>
              <td className="col-2">
                {usuario.ativo ? (
                  <span className="badge bg-success">Ativo</span>
                ) : (
                  <span className="badge bg-danger">Inativo</span>
                )}
              </td>
            </tr>
          ))}
          {usuarios.length === 0 && (
            <tr>
              <td colSpan="5" className="text-center text-muted py-4">
                Nenhum usuário encontrado.
              </td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  </div>
  );
};

export default Users;