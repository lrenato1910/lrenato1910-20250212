import React, { useEffect, useState } from 'react';
import api from '../../api';

const UnitEdit = ({ unitId, onSuccess }) => {
  const [codigo, setCodigo] = useState('');
  const [nome, setNome] = useState('');
  const [status, setStatus] = useState('ativo');
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchUnit = async () => {
      try {
        const response = await api.get(`/units/${unitId}`);
        const { codigo, nome, status } = response.data;
        setCodigo(codigo);
        setNome(nome);
        setStatus(status);
      } catch (err) {
        setError('Erro ao carregar unidade.');
      }
    };
    fetchUnit();
  }, [unitId]);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await api.put(`/units/${unitId}`, { codigo, nome, status });
      onSuccess(); // chamar a função de callback em caso de sucesso
      alert('Unidade atualizada com sucesso!');
    } catch (err) {
      setError('Erro ao atualizar unidade. Tente novamente.');
    }
  };

  return (
    <div>
      <h2>Editar Unidade</h2>
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
        <button type="submit">Atualizar</button>
      </form>
    </div>
  );
};

export default UnitEdit;