import React, { useState } from 'react';
import api from '../../api';

const CollaboratorForm = ({ onSuccess }) => {
  const [nome, setNome] = useState('');
  const [codigoUnidade, setCodigoUnidade] = useState('');
  const [usuarioId, setUsuarioId] = useState('');
  const [error, setError] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await api.post('/collaborators', { nome, codigoUnidade, usuarioId });
      onSuccess(); // chamar a função de callback em caso de sucesso
      alert('Colaborador cadastrado com sucesso!');
    } catch (err) {
      setError('Erro ao cadastrar colaborador. Tente novamente.');
      console.error('Erro ao cadastrar:', err);
    }
  };

  return (
    <div>
      <h2>Cadastro de Colaborador</h2>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <form className="p-3 border rounded shadow" onSubmit={handleSubmit}>
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
          <label>Código da Unidade:</label>
          <input
            type="text"
            value={codigoUnidade}
            onChange={(e) => setCodigoUnidade(e.target.value)}
            required
          />
        </div>
        <div>
          <label>ID do Usuário:</label>
          <input
            type="text"
            value={usuarioId}
            onChange={(e) => setUsuarioId(e.target.value)}
            required
          />
        </div>
        <button type="submit">Cadastrar</button>
      </form>
    </div>
  );
};

export default CollaboratorForm;