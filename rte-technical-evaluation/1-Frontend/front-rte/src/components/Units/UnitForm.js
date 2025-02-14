import React, { useState } from 'react';
import api from '../../api';

const UnitForm = ({ onSuccess }) => {
  const [codigo, setCodigo] = useState('');
  const [nome, setNome] = useState('');
  const [status, setStatus] = useState('ativo');
  const [error, setError] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await api.post('/units', { codigo, nome, status });
      onSuccess(); // chamar a função de callback em caso de sucesso
      alert('Unidade cadastrada com sucesso!');
    } catch (err) {
      setError('Erro ao cadastrar unidade. Tente novamente.');
    }
  };

  return (
    <div>
      <h2>Cadastro de Unidade</h2>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <form onSubmit={handleSubmit}>
        <div>
          <label>Código:</label>
          <input
            type="text"
            value={codigo}
            onChange={(e) => setCodigo(e.target.value)}
            required
          />
        </div>
        <div>
          <label>Nome:</label>
          <input
            type="text"
            value={nome}
            onChange={(e) => setNome(e.target.value)}
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
        <button type="submit">Cadastrar</button>
      </form>
    </div>
  );
};

export default UnitForm;