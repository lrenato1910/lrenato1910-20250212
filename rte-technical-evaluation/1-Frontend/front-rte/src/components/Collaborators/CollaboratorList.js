import React, { useEffect, useState, useRef } from 'react';
import api from '../../api';
import { Link } from 'react-router-dom';
import useToast from '../Libs/toast/useToast';
import useSweetAlert from '../Libs/swal/useSwal';

const CollaboratorList = () => {
  const hasMounted = useRef(false);
  const [collaborators, setCollaborators] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const showToast = useToast();
  const { showSuccess, showError, showConfirmation } = useSweetAlert();


  
  useEffect(() => {
    if (hasMounted.current) return;
    hasMounted.current = true;

    const fetchCollaborators = async () => {
      try {
        const token = localStorage.getItem('authToken');
        const response = await api.get('Colaborador', {
          headers: {
            'Authorization': `Bearer ${token}`,
            'Content-Type': 'application/json'
          }
        });
        
        showToast('Colaboradores listados com sucesso!', 'success');
        setCollaborators(response.data.apiResultData);
      } catch (err) {
          setError(err);
      } finally {
          setLoading(false);
      }
    };

    fetchCollaborators();
  }, []);

  const deleteItem = async (id) => {
    const result = await showConfirmation('Tem certeza?', 'Você não poderá reverter isso!');

    if (result.isConfirmed) {
      try {
        const response = await api.delete(`colaborador/${id}`, {
          headers: {
            'Authorization': `Bearer ${localStorage.getItem('authToken')}`,
            'Content-Type': 'application/json'
          }
        });
  
        if (response.status === 200) {
          setCollaborators(collaborators.filter(collaborators => collaborators.id !== id));
        } else {
            console.error('Erro ao excluir o item');
        }
      } catch (error) {
        console.error('Erro ao excluir o item', error);
      }
    }
  };

  return (
      <div className="container mt-5">
      <h2 className="text-center mb-4 text-primary">Lista de Colaboradores</h2>
  
      <Link to="create" className="btn btn-success mb-3">
        <i className="fas fa-plus me-2"></i>Criar Novo Usuário
      </Link>
  
      <div className="table-responsive">
        <table className="table table-striped table-bordered table-hover shadow-lg">
          <thead className="table-dark">
            <tr>
              <th>Ações</th>
              <th>ID</th>
              <th>Nome</th>
              <th>Unidade</th>
              <th>Usuario</th>
            </tr>
          </thead>
          <tbody>
            {collaborators.map((usuario) => (
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
                <td className="col-4">{usuario.nome}</td>
                <td className="col-4">{usuario.unidade}</td>
                <td className="col-4">{usuario.usuario}</td>
                <td className="col-2">
                  {usuario.ativo ? (
                    <span className="badge bg-success">Ativo</span>
                  ) : (
                    <span className="badge bg-danger">Inativo</span>
                  )}
                </td>
              </tr>
            ))}
            {collaborators.length === 0 && (
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

export default CollaboratorList;