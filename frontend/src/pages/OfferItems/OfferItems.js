//ALL Items
import React from 'react';
import { useGetOffersQuery } from '../../store/apiSlices/offersApi';
import OfferItem from './OfferItem';
import Headline from '../../components/Headline';
import Menu from '../Menu';
import './offer-items.css';

const OfferItems = () => {

    const { data: offers, isLoading, isError, error } = useGetOffersQuery();

    if (isLoading) {
        return <div>Loading...</div>;
      }
    
      if (isError) {
        return <div>{error.message}</div>;
      }

      const displayOffers = offers.map(offer => {

        let dateObj = new Date(offer.registrationDate);
        let formattedDate = dateObj.toLocaleDateString();

        return(
        <li key={offer.Id}>
            <OfferItem
                id={offer.id}
                brand={offer.brand}
                model={offer.model}
                supplier={offer.supplier.name}
                date={formattedDate}
            />
        </li>)
      })

  return (
    <>
    <Menu/>
    <Headline text='All available Offers'/>
    <p className='offers-amount'>Total amount: {displayOffers.length}</p>
     <ul className='offerItems-container'>
        {displayOffers}
     </ul>
    </>
  )

}

export default OfferItems;