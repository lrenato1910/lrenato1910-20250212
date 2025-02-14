import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

import { AuthProvider } from './components/Auth/AuthContext'; 
import Login from './components/Auth/Login'; 
import Register from './components/Auth/Register'; 
import Collaborator from './components/Collaborators/CollaboratorList'; 
import Unit from './components/Units/UnitList'; 
import Users from './components/Users/UserList'; 
import UserCreate from './components/Users/UserForm';
import UserEdit from './components/Users/UserEdit';
import Dashboard from './components/Dashboard';
import ProtectedRoute from './ProtectedRoute'; 
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css'; // Estilos do toast

const App = () => {
  return (
      <AuthProvider>
        <ToastContainer />
          <Router>
              <Routes>
                  <Route path="/login" element={<Login />} />
                  <Route path="/dashboard" element={
                      <ProtectedRoute>
                          <Dashboard />
                      </ProtectedRoute>
                  }>
                      <Route path="users" element={<Users />} />
                      <Route path="units" element={<Unit />} />
                      <Route path="users/create" element={<UserCreate />} />
                      <Route path="users/edit/:id" element={<UserEdit />} />
                  </Route>
              </Routes>
          </Router>
      </AuthProvider>
  );
};

export default App;