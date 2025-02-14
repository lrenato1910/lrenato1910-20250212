import React from 'react';
import { Link } from 'react-router-dom';

const Units = () => {
  return (
    <div>
      <div className='row col-12'>
        <div className='col-10'>
          <h2>Lista de Unidades</h2>
        </div>

        <div className='col-2'>
          <Link to="UserForm" className="btn btn-success mb-3">
            Criar Nova Unidade
          </Link>
        </div>
      </div>
      <ul className="list-group">
        <li className="list-group-item">Unidade 1</li>
        <li className="list-group-item">Unidade 2</li>
      </ul>
    </div>
  );
};

export default Units;