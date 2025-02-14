import React, { useEffect, useState } from 'react';
import api from '../../api';

const UserEdit = ({ userId, onSuccess }) => {
  const [login, setLogin] = useState('');
  const [senha, setSenha] = useState('');
  const [status, setStatus] = useState('ativo');
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchUser = async () => {
      try {
        const response = await api.get(`/users/${userId}`);
        const { login, status } = response.data;
        setLogin(login);
        setStatus(status);
      } catch (err) {
        setError('Erro ao carregar usuário.');
      }
    };
    fetchUser();
  }, [userId]);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await api.put(`/users/${userId}`, { login, senha, status });
      onSuccess(); // chamar a função de callback em caso de sucesso
      alert('Usuário atualizado com sucesso!');
    } catch (err) {
      setError('Erro ao atualizar usuário. Tente novamente.');
    }
  };

  return (
    <div>
      <h2>Editar Usuário</h2>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <form onSubmit={handleSubmit}>
        <div>
          <label>Login:</label>
          <input
            type="text"
            value={login}
            onChange={(e) => setLogin(e.target.value)}
            required
          />
        </div>
        <div>
          <label>Senha:</label>
          <input
            type="password"
            value={senha}
            onChange={(e) => setSenha(e.target.value)}
          />
        </div>
        <div>
          <label>Status:</label>
          <select value={status} onChange={(e) => setStatus(e.target.value)}>
            <option value="ativo">Ativo</option>
            <option value="inativo">Inativo</option>
          </select>
        </div>
        <button type="submit">Atualizar</button>
      </form>
    </div>
  );
};

export default UserEdit;