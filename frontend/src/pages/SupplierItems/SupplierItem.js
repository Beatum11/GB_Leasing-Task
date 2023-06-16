//ONE TOP Supplier
import React from "react";

import "./supplier-item.css";

const SupplierItem = ({suppName, offerCount}) => {
  return (
    <ul className="supplierItem-container">
      <li>{suppName}</li>
      <li>{offerCount}</li>
    </ul>
  );
};

export default SupplierItem;
