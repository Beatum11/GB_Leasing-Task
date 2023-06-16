import { configureStore} from "@reduxjs/toolkit";
import { offersApi } from "./apiSlices/offersApi";
import {suppliersApi} from "./apiSlices/suppliersApi";

const store = configureStore({
    reducer : {
        [offersApi.reducerPath] : offersApi.reducer,
        [suppliersApi.reducerPath] : suppliersApi.reducer
    }, 
    
    middleware: (getDefaultMiddleware) => 
    getDefaultMiddleware({thunk: true}).concat(offersApi.middleware, 
                                               suppliersApi.middleware),

});


export default store;