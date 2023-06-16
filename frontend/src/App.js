import './App.css';
import { BrowserRouter, Route, Routes } from "react-router-dom";
import OfferItems from './pages/OfferItems/OfferItems';
import SupplierItems from './pages/SupplierItems/SupplierItems';
import SearchOffers from './pages/SearchOffers/SearchOffers';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route exact path="/" element={<OfferItems/>}/>
        <Route exact path="/top3" element={<SupplierItems/>}/>
        <Route exact path="/search" element={<SearchOffers/>}/>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
