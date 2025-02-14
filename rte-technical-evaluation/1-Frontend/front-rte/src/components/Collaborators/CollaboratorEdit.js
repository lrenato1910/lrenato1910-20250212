import React, { useEffect, useState } from 'react';
import api from '../../api';

const CollaboratorEdit = ({ collaboratorId, onSuccess }) => {
  const [nome, setNome] = useState('');
  const [codigoUnidade, setCodigoUnidade] = useState('');
  const [usuarioId, setUsuarioId] = useState('');
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchCollaborator = async () => {
      try {
        const response = await api.get(`/collaborators/${collaboratorId}`);
        const { nome, codigoUnidade, usuarioId } = response.data;
        setNome(nome);
        setCodigoUnidade(codigoUnidade);
        setUsuarioId(usuarioId);
      } catch (err) {
        setError('Erro ao carregar colaborador.');
      }
    };
    fetchCollaborator();
  }, [collaboratorId]);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await api.put(`/collaborators/${collaboratorId}`, { nome, codigoUnidade, usuarioId });
      onSuccess(); // chamar a função de callback em caso de sucesso
      alert('Colaborador atualizado com sucesso!');
    } catch (err) {
      setError('Erro ao atualizar colaborador. Tente novamente.');
    }
  };

  return (
    <div>
      <h2>Editar Colaborador</h2>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <form onSubmit={handleSubmit}>
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
        <button type="submit">Atualizar</button>
      </form>
    </div>
  );
};

export default CollaboratorEdit;