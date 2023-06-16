//ALL of the TOP suppliers
import React from 'react';
import { useGetTopSuppliersQuery } from '../../store/apiSlices/suppliersApi';
import SupplierItem from './SupplierItem';
import Menu from '../Menu';
import Headline from '../../components/Headline';
import './supplier-items.css';

const SupplierItems = () => {
    
    const { data: topSuppliers, isLoading, isError, error } = useGetTopSuppliersQuery();
    console.log(topSuppliers);

    if (isLoading) {
        return <div>Loading...</div>;
      }
    
      if (isError) {
        return <div>{error.message}</div>;
      }

      const displaySuppliers = topSuppliers.map(topSup => {
        return(
            <li key={topSup.supplierId}>
                <SupplierItem
                    suppName={topSup.supplierName}
                    offerCount={topSup.offerCount}
                />
            </li>
        )
      })


  return (
    <>
    <Menu/>
    <Headline text='Top 3 suppliers by number of offers'/>
    <ul className='supplierItems-container'>
        {displaySuppliers}
    </ul>
    </>
    
  )
}

export default SupplierItems;