import React from 'react';
import { Link } from "react-router-dom";

import './menu.css';

const Menu = () => {



  return (
    <ul className='menu-container'>
        <li><Link to="/top3">TOP-3</Link></li>
        <li><Link to="/search">Search</Link></li>
        <li><Link to="/">Offers</Link></li>
    </ul>
  );
}

export default Menu;