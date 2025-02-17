import React, { useEffect, useState, useRef } from 'react';
import api from '../../api';
import { Link } from 'react-router-dom';
import useToast from '../Libs/toast/useToast';
import useSweetAlert from '../Libs/swal/useSwal';

const Units = () => {
  const hasMounted = useRef(false);
  const [unidades, setUnidades] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const showToast = useToast();
  const { showSuccess, showError, showConfirmation } = useSweetAlert();

  useEffect(() => {
    if (hasMounted.current) return;
    hasMounted.current = true;

    const fetchUnidades = async () => {
        try {
          const token = localStorage.getItem('authToken');
          const response = await api.get('unidade', {
            headers: {
              'Authorization': `Bearer ${token}`,
              'Content-Type': 'application/json'
            }
          });
          
          showToast('Unidades listadas com sucesso!', 'success');
          setUnidades(response.data.apiResultData);
        } catch (err) {
            setError(err);
        } finally {
            setLoading(false);
        }
    };

    fetchUnidades();
  }, []);

  const deleteItem = async (id) => {
    const result = await showConfirmation('Tem certeza?', 'Você não poderá reverter isso!');

    if (result.isConfirmed) {
      try {
        const response = await api.delete(`unidade/${id}`, {
          headers: {
            'Authorization': `Bearer ${localStorage.getItem('authToken')}`,
            'Content-Type': 'application/json'
          }
        });
  
        if (response.status === 200) {
            setUnidades(unidades.filter(unidades => unidades.id !== id));
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
      <h2 className="text-center mb-4 text-primary">Lista de Unidades</h2>
  
      <Link to="create" className="btn btn-success mb-3">
        <i className="fas fa-plus me-2"></i>Criar Nova Unidade
      </Link>
  
      <div className="table-responsive">
        <table className="table table-striped table-bordered table-hover shadow-lg">
          <thead className="table-dark">
            <tr>
              <th>Ações</th>
              <th>ID</th>
              <th>Código</th>
              <th>Nome</th>
              <th>Status</th>
            </tr>
          </thead>
          <tbody>
            {unidades.map((unidades) => (
              <tr key={unidades.id} className="align-middle">
                <td className="col-2">
                  <div className="d-flex gap-2">
                    <Link to={`./edit/${unidades.id}`} className="btn btn-warning btn-sm flex-grow-1"> 
                      <i className="fas fa-edit me-1"></i>Editar
                    </Link>
                    <button className="btn btn-danger btn-sm flex-grow-1" onClick={() => deleteItem(unidades.id)}>
                      <i className="fas fa-trash me-1"></i>Excluir
                    </button>
                  </div>
                </td>
                <td className="col-1">{unidades.id}</td>
                <td className="col-4">{unidades.codigo}</td>
                <td className="col-4">{unidades.nome}</td>
                <td className="col-2">
                  {unidades.ativo ? (
                    <span className="badge bg-success">Ativo</span>
                  ) : (
                    <span className="badge bg-danger">Inativo</span>
                  )}
                </td>
              </tr>
            ))}
            {unidades.length === 0 && (
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

export default Units;