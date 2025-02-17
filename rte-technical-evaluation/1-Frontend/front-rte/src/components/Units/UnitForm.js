import React, { useState } from 'react';
import api from '../../api';
import { Link } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';

const UnitForm = ({ onSuccess }) => {
  const [codigo, setCodigo] = useState('');
  const [nome, setNome] = useState('');
  const [status, setStatus] = useState('true');
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      let Unidade = {
        Id: 0
        , Codigo: codigo
        , Nome: nome
        , Ativo: status === "true" ? true : false
      };

      const response = await api.post('unidade/Create', Unidade, {
        headers: {
          'Authorization': `Bearer ${localStorage.getItem('authToken')}`,
          'Content-Type': 'application/json'
        }
      });

      navigate('../units');
    } catch (err) {
      setError('Erro ao cadastrar unidade. Tente novamente.');
    }
  };

  return (
      <div className="container mt-5">
        <h2 className="text-center mb-4">Cadastro de Unidades</h2>
        
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
            Cadastrar
          </button>
        </form>
      </div>
    );
  };

export default UnitForm;