import React, { useEffect, useState, useRef } from 'react';
import api from '../../api';
import { Link } from 'react-router-dom';
import { useParams, useNavigate } from 'react-router-dom';

const UnitEdit = () => {
  const hasMounted = useRef(false);

  const { id } = useParams();
  const [unidade, setUsuario] = useState({ codigo: '', nome: '' });
  let unidadeId = id;

  const [codigo, setCodigo] = useState('');
  const [nome, setNome] = useState('');
  const [status, setStatus] = useState('true');
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    if (hasMounted.current) return;
    hasMounted.current = true;
    
    const fetchUnit = async () => {
      try {
        const response = await api.get(`unidade/${unidadeId}`, {
          headers: {
            'Authorization': `Bearer ${localStorage.getItem('authToken')}`,
            'Content-Type': 'application/json'
          }
        });

        setCodigo(response.data.apiResultData.codigo);
        setNome(response.data.apiResultData.nome);
        setStatus(response.data.apiResultData.ativo);
      } catch (err) {
        setError('Erro ao carregar unidade.');
      }
    };
    fetchUnit();
  }, [unidadeId]);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      let Unidade = {
        Id: unidadeId
        , Codigo: codigo
        , Nome: nome
        , Ativo: status === "true" ? true : false
      };

      const response = await api.put('unidade', Unidade, {
        headers: {
          'Authorization': `Bearer ${localStorage.getItem('authToken')}`,
          'Content-Type': 'application/json'
        }
      });

      if(!response.data.apiResultData){
        alert('Erro ao atualizar unidade!');
        return false;
      }
      
      navigate('../units');
    } catch (err) {
      setError('Erro ao atualizar unidade. Tente novamente.');
    }
  };

  return (
      <div className="container mt-5">
        <h2 className="text-center mb-4">Alteração de Unidade</h2>
        
        <Link to="../units" className="btn btn-outline-success mb-3">
          Voltar
        </Link>
    
        {error && <p className="text-danger">{error}</p>}
        
        <form onSubmit={handleSubmit} className="border p-4 rounded shadow">
          <div className="mb-3">
            <label className="form-label">Código:</label>
            <input
              type="text"
              className="form-control"
              value={codigo}
              onChange={(e) => setCodigo(e.target.value)}
              required
              disabled
            />
          </div>
          <div className="mb-3">
            <label className="form-label">Nome:</label>
            <input
              type="text"
              className="form-control"
              value={nome}
              onChange={(e) => setNome(e.target.value)}
              required
            />
          </div>
          <div className="mb-3">
            <label className="form-label">Status:</label>
            <select 
              className="form-select" 
              value={status} 
              onChange={(e) => setStatus(e.target.value)}
            >
              <option value="true">Ativo</option>
              <option value="false">Inativo</option>
            </select>
          </div>
          <button type="submit" className="btn btn-success w-100">
            Alterar
          </button>
        </form>
      </div>
    );
};

export default UnitEdit;