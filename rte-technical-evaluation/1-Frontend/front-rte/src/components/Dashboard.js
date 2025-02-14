import React from 'react';
import { Link, Outlet } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
import { useAuth } from './Auth/AuthContext';
import './Dashboard.css';
import 'bootstrap/dist/css/bootstrap.min.css'; // Importe o Bootstrap
import '@fortawesome/fontawesome-free/css/all.min.css';

const Dashboard = () => {
    const { logout } = useAuth();
    const navigate = useNavigate();
    
    const handleLogout = () => {
        logout();
        navigate('/login');
    };

    return (
      <div className="d-flex" style={{ minHeight: '100vh' }}>
        <nav className="bg-light sidebar p-3" style={{ width: '250px' }}>
        <h2 className="text-center">Dashboard</h2>
        <ul className="nav flex-column">
          <li className="nav-item">
            <Link className="nav-link" to="users">
              <i className="fas fa-users"></i> Usuários
            </Link>
          </li>
          <li className="nav-item">
            <Link className="nav-link" to="units">
              <i className="fas fa-building"></i> Unidades
            </Link>
          </li>
        </ul>
        <button className="btn btn-danger mt-4" onClick={handleLogout}>
          <i className="fas fa-sign-out-alt"></i> Logout
        </button>
        </nav>
        <div className="content flex-grow-1 p-4">
          <h1 className="text-center">Bem-vindo à Dashboard</h1>
          <div className="card mt-4">
            <div className="card-body">
              <Outlet />
            </div>
          </div>
        </div>
      </div>
    );
};

export default Dashboard;