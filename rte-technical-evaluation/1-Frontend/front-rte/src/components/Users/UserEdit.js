import React, { useEffect, useState, useRef } from 'react';
import api from '../../api';
import { Link } from 'react-router-dom';
import { useParams, useNavigate } from 'react-router-dom';

const UserEdit = () => {
  const hasMounted = useRef(false);

  const { id } = useParams();
  const [usuario, setUsuario] = useState({ login: '', senha: '' });
  let userId = id;

  const [login, setLogin] = useState('');
  const [senha, setSenha] = useState('');
  const [status, setStatus] = useState('ativo');
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    if (hasMounted.current) return;
    hasMounted.current = true;

    const fetchUser = async () => {
      try {
        const response = await api.get(`usuarios/${userId}`, {
          headers: {
            'Authorization': `Bearer ${localStorage.getItem('authToken')}`,
            'Content-Type': 'application/json'
          }
        });
        
        setLogin(response.data.apiResultData.login);
        setSenha(response.data.apiResultData.senha);
        setStatus(response.data.apiResultData.ativo);
      } catch (err) {
        setError('Erro ao carregar usuário.');
      }
    };

    fetchUser();
  }, [userId]);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      let Usuario = {
        Id: userId
        , Login: login
        , Senha: senha
        , Ativo: status === "true" ? true : false
      };
      
      const response = await api.put('usuarios', Usuario, {
        headers: {
          'Authorization': `Bearer ${localStorage.getItem('authToken')}`,
          'Content-Type': 'application/json'
        }
      });

      if(!response.data.apiResultData){
        alert('Erro ao atualizar usuario!');
        return false;
      }
      
      navigate('../users');
    } catch (err) {
      setError('Erro ao atualizar usuário. Tente novamente.');
    }
  };

  return (
    <div className="container mt-5">
      <h2 className="text-center mb-4">Alteração de Usuário</h2>
      
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
            disabled
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

export default UserEdit;