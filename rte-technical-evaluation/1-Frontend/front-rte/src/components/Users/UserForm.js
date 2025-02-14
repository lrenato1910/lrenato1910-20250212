import React, { useState } from 'react';
import api from '../../api';
import { Link } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';

const UserForm = ({ onSuccess }) => {
  const [login, setLogin] = useState('');
  const [senha, setSenha] = useState('');
  const [status, setStatus] = useState('ativo');
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {      
      let Usuario = {
        Id: 0
        , Login: login
        , Senha: senha
        , Ativo: true
      };

      const token = localStorage.getItem('authToken');
      const response = await api.post('usuarios/Create', Usuario, {
        headers: {
          'Authorization': `Bearer ${token}`,
          'Content-Type': 'application/json'
        }
      });

      alert('Usuário cadastrado com sucesso!');
      navigate('../users');
    } catch (err) {
      setError('Erro ao cadastrar usuário. Tente novamente.');
    }
  };

  return (
    <div className="container mt-5">
      <h2 className="text-center mb-4">Cadastro de Usuário</h2>
      
      <Link to="../users" className="btn btn-outline-success mb-3">
        Voltar
      </Link>
  
      {error && <p className="text-danger">{error}</p>}
      
      <form onSubmit={handleSubmit} className="border p-4 rounded shadow">
        <div className="mb-3">
          <label className="form-label">Login:</label>
          <input
            type="text"
            className="form-control"
            value={login}
            onChange={(e) => setLogin(e.target.value)}
            required
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Senha:</label>
          <input
            type="password"
            className="form-control"
            value={senha}
            onChange={(e) => setSenha(e.target.value)}
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
            <option value="ativo">Ativo</option>
            <option value="inativo">Inativo</option>
          </select>
        </div>
        <button type="submit" className="btn btn-success w-100">
          Cadastrar
        </button>
      </form>
    </div>
  );
};

export default UserForm;