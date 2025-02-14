import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

import { AuthProvider } from './components/Auth/AuthContext'; 
import Login from './components/Auth/Login'; 
import Register from './components/Auth/Register'; 
import Collaborator from './components/Collaborators/CollaboratorList'; 
import Unit from './components/Units/UnitList'; 
import Users from './components/Users/UserList'; 
import UserCreate from './components/Users/UserForm';
import Dashboard from './components/Dashboard';
import ProtectedRoute from './ProtectedRoute'; 

const App = () => {
  return (
    <AuthProvider>
      <Router>
        <Routes>
        <Route path="/login" element={<Login />} />
        <Route path="/dashboard" element={<Dashboard />}>
          <Route path="users" element={<Users />} />
          <Route path="units" element={<Unit />} />
          <Route path="users/create" element={<UserCreate />} />
        </Route>
        </Routes>
      </Router>
    </AuthProvider>
  );
};

export default App;