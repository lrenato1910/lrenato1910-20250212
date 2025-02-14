import React, { useState } from 'react';
import { useAuth } from './AuthContext';
import api from '../../api';
import { useNavigate } from 'react-router-dom';

const Login = () => {
  const { login } = useAuth();
  const [credentials, setCredentials] = useState({ login: '', senha: '' });
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  const handleChange = (e) => {
    const { name, value } = e.target;
    setCredentials((prev) => ({ ...prev, [name]: value }));
  };

  const handleSubmit = async (e) => {    
    e.preventDefault();
    setError(null); // Limpa erros anteriores

    try {
      // Faça a chamada para a API para autenticar o usuário
      const response = await api.post('Authenticate', credentials);
      if (response.status === 200) {
        debugger;

        console.log(response);
        let apiResultModel = response.data;

        if(!apiResultModel.success){
          setError('Credenciais inválidas. Tente novamente.');
          return false;
        }

        localStorage.setItem('authToken', apiResultModel.apiResultData);

        login();
        navigate('/dashboard');
      }
    } catch (err) {
      setError('Credenciais inválidas. Tente novamente.');
      console.error('Erro de login:', err);
    }
  };

  return (
    <div className="p-4" style={{ maxWidth: '400px', margin: '0 auto' }}>
      <h2 className="text-center mb-4">Login</h2>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <input
            type="text"
            name="login"
            className="form-control"
            value={credentials.login}
            onChange={handleChange}
            placeholder="Login"
            required
          />
        </div>
        <div className="mb-3">
          <input
            type="password"
            name="senha"
            className="form-control"
            value={credentials.senha}
            onChange={handleChange}
            placeholder="Senha"
            required
          />
        </div>
        <button type="submit" className="btn btn-success w-100">Login</button>
      </form>
    </div>
  );
};

export default Login;