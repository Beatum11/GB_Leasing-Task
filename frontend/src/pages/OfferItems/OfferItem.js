//ONE Item
import React from 'react';

import './offer-item.css';

const OfferItem = ({id='1', brand='lada', model='vesta', supplier='VAZ', date='21.01.2023'}) => {

  return (
    <div className='offerItem-container'>
        <ul>
            <li>{id}</li>
            <li>{brand}</li>
            <li>{model}</li>
            <li>{supplier}</li>
            <li>{date}</li>
        </ul>
    </div>
  );

}

export default OfferItem;