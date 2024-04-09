import React from 'react';
import { Link, Route, Routes } from 'react-router-dom';
import './App.css';


const StateSelect = () => {
  return <div>This is the StateSelect component</div>;
};

function App() {
  return (
    <>
      <nav className='Navbar'>
        <ul>
          <li>
            <Link to='/'>Home</Link>
          </li>
          <li>
            <Link to='/StateSelect'>State Select</Link>
          </li>
        </ul>
      </nav>
      <div>
        <h1 className='heading'>Want to Join NGOs?</h1>
        <button>Join now</button>
      </div>
      <Routes>
        <Route path='/StateSelect' element={<StateSelect />} />
      </Routes>
    </>
  );
}

export default App;
