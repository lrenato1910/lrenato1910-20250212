import React from 'react';
import { Link, Outlet } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
import { useAuth } from './Auth/AuthContext';
import './Dashboard.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import '@fortawesome/fontawesome-free/css/all.min.css';

const Dashboard = () => {
  const { logout } = useAuth();
  const navigate = useNavigate();

  const handleLogout = () => {
    localStorage.removeItem('authToken');
    logout();
    navigate('/login');
  };

  return (
    <div className="dashboard-container">
      {/* Sidebar */}
      <nav className="sidebar p-3">
        <h2 className="text-center mb-4">Dashboard</h2>
        <ul className="nav flex-column">
          <li className="nav-item">
            <Link className="nav-link" to="users">
              <i className="fas fa-users me-2"></i> Usuários
            </Link>
          </li>
          <li className="nav-item">
            <Link className="nav-link" to="units">
              <i className="fas fa-building me-2"></i> Unidades
            </Link>
          </li>
        </ul>
        <button className="btn btn-logout w-100 mt-4" onClick={handleLogout}>
          <i className="fas fa-sign-out-alt me-2"></i> Logout
        </button>
      </nav>

      {/* Main Content */}
      <div className="main-content p-4">
        <div className="card">
          <div className="card-body">
            <Outlet />
          </div>
        </div>
      </div>
    </div>
  );
};

export default Dashboard;