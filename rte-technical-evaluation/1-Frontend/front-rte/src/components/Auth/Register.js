import React, { useState } from 'react';
import api from '../../api';

const Register = () => {
  const [login, setLogin] = useState('');
  const [senha, setSenha] = useState('');
  const [status, setStatus] = useState('ativo'); // ou 'inativo' conforme necessário
  const [error, setError] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await api.post('/auth/register', { login, senha, status });
      // Redirecionar após o registro bem-sucedido ou exibir mensagem
      alert('Usuário registrado com sucesso!');
    } catch (err) {
      setError('Erro ao registrar usuário. Tente novamente.');
      console.error('Erro ao registrar:', err);
    }
  };

  return (
    <div>
      <h2>Registro de Usuário</h2>
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
            required
          />
        </div>
        <div>
          <label>Status:</label>
          <select value={status} onChange={(e) => setStatus(e.target.value)}>
            <option value="ativo">Ativo</option>
            <option value="inativo">Inativo</option>
          </select>
        </div>
        <button type="submit">Registrar</button>
      </form>
    </div>
  );
};

export default Register;