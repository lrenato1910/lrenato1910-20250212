import React, { useEffect, useState } from 'react';
import api from '../../api';

const CollaboratorList = () => {
  const [collaborators, setCollaborators] = useState([]);

  useEffect(() => {
    const fetchCollaborators = async () => {
      const response = await api.get('/collaborators');
      setCollaborators(response.data);
    };
    fetchCollaborators();
  }, []);

  return (
    <ul>
      {collaborators.map((collaborator) => (
        <li key={collaborator.id}>{collaborator.name}</li>
      ))}
    </ul>
  );
};

export default CollaboratorList;