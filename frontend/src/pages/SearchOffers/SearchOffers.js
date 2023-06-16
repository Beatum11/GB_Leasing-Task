import React, { useState } from "react";
import { useSearchOffersQuery } from "../../store/apiSlices/offersApi";
import OfferItem from "../OfferItems/OfferItem";
import Menu from "../Menu";
import Headline from "../../components/Headline";
import "./search-offers.css";

const SearchOffers = () => {
  const [searchLine, setSearchLine] = useState("");
  const {data: offers} = useSearchOffersQuery(searchLine);

  const handleSearch = (e) => {
    e.preventDefault();
    setSearchLine(e.target.value);
  };

  return (
    <div>
        <Menu/>
        <Headline text='Search on Brand, Model, Supplier'/>
      <input
        type="text"
        placeholder="Search"
        onChange={handleSearch}
        value={searchLine}
      />

      <ul className="searchOffers-container">
        {offers && offers.map((offer) => {

            let dateObj = new Date(offer.registrationDate);
            let formattedDate = dateObj.toLocaleDateString();

            return (
              <li key={offer.Id}>
                <OfferItem
                  id={offer.id}
                  brand={offer.brand}
                  model={offer.model}
                  supplier={offer.supplier.name}
                  date={formattedDate}
                />
              </li>
            );
          })}
      </ul>
    </div>
  );
};

export default SearchOffers;
