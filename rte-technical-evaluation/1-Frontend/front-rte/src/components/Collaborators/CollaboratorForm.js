import React, { useEffect, useState, useRef } from 'react';
import api from '../../api';
import { Link } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';

const CollaboratorForm = ({ onSuccess }) => {
  const hasMounted = useRef(false);

  const [usuarios, setUsuarios] = useState([]);
  const [unidades, setUnidades] = useState([]);
  const [selectedUser, setSelectedUser] = useState('');
  const [selectedUnit, setSelectedUnit] = useState('');
  const [nome, setNome] = useState('');
  const [codigoid, setCodigoUnidade] = useState('');
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    if (hasMounted.current) return;
    hasMounted.current = true;

    const fetchUsuarios = async () => {
      try {
        const response = await api.get('usuarios', {
          headers: {
            'Authorization': `Bearer ${localStorage.getItem('authToken')}`,
            'Content-Type': 'application/json'
          }
        });
        setUsuarios(response.data.apiResultData);
      } catch (error) {
        console.error('Erro ao buscar usuários:', error);
      }
    };

    const fetchUnidades = async () => {
      try {
        const response = await api.get('unidade', {
          headers: {
            'Authorization': `Bearer ${localStorage.getItem('authToken')}`,
            'Content-Type': 'application/json'
          }
        });
        setUnidades(response.data.apiResultData);
      } catch (error) {
        console.error('Erro ao buscar unidades:', error);
      }
    };

    fetchUsuarios();
    fetchUnidades();
  }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!selectedUser || !selectedUnit) {
      setError('Por favor, selecione um usuário e uma unidade.');
      return;
    }
    try {
      let colaborador = {
        Id: 0
        , Nome: nome
        , UnidadeId: selectedUnit
        , UsuarioId: selectedUser
        , Unidade: null
        , Usuario: null
      };

      debugger;

      const response = await api.post('colaborador/Create', colaborador, {
        headers: {
          'Authorization': `Bearer ${localStorage.getItem('authToken')}`,
          'Content-Type': 'application/json'
        }
      });

      navigate('../collaborator');
    } catch (err) {
      setError('Erro ao cadastrar colaborador. Tente novamente.');
      console.error('Erro ao cadastrar:', err);
    }
  };

  return (
    <div className="container mt-5">
      <h2 className="text-center mb-4">Cadastro de Colaborador</h2>
      
      <Link to="../collaborator" className="btn btn-outline-success mb-3">
        Voltar
      </Link>
  
      {error && <p className="text-danger">{error}</p>}
      
      <form onSubmit={handleSubmit} className="border p-4 rounded shadow">
        <div className="mb-3">
          <label htmlFor="nome" className="form-label">Nome:</label>
          <input
            type="text"
            className="form-control"
            id="nome"
            value={nome}
            onChange={(e) => setNome(e.target.value)}
            required
          />
        </div>
        
        <div className="mb-3">
          <label className="form-label">Usuário:</label>
          <select
            id="userSelect"
            className="form-select"
            value={selectedUser}
            onChange={(e) => setSelectedUser(e.target.value)}
            required
          >
            <option value="">Escolha um usuário</option>
            {usuarios.map(usuario => (
              <option key={usuario.id} value={usuario.id}>
                {usuario.login}
              </option>
            ))}
          </select>
        </div>

        <div className="mb-3">
          <label htmlFor="unitSelect" className="form-label">Selecione uma Unidade</label>
          <select
            id="unitSelect"
            className="form-select"
            value={selectedUnit}
            onChange={(e) => setSelectedUnit(e.target.value)}
            required
          >
            <option value="">Escolha uma unidade</option>
            {unidades.map(unidade => (
              <option key={unidade.id} value={unidade.id}>
                {unidade.nome}
              </option>
            ))}
          </select>
        </div>

        <button type="submit" className="btn btn-success w-100">
          Cadastrar
        </button>
      </form>
    </div>
  );
};

export default CollaboratorForm;