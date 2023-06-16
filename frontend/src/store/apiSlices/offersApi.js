import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const offersApi = createApi({
    reducerPath: 'offersApi',
    baseQuery: fetchBaseQuery({baseUrl: 'https://localhost:7253/api'}),
    endpoints: (builder) => ({
        
        getOffers: builder.query({
            query: () => '/Offers'
        }),

        getOffer: builder.query({
            query: (id) => `/Offers/${id}`
        }),

        searchOffers: builder.query({
            query: (searchTerm) => `Offers/search/${searchTerm}`
        }),

        createOffer: builder.mutation({
            query: (offer) => ({
                url: '/Offers',
                method: 'POST',
                body: offer
            }),
        }),

        updateOffer: builder.mutation({
            query: (offer) => ({
                url: `/Offers/${offer.id}`,
                method: 'PUT',
                body: offer
            }),
        }),

        deleteOffer: builder.mutation({
            query: (id) => ({
                url: `/Offers/${id}`,
                method: 'DELETE'
            }),
        })
    }),
});

export const {
    useGetOffersQuery,
    useGetOfferQuery,
    useSearchOffersQuery,
    useCreateOfferMutation,
    useUpdateOfferMutation,
    useDeleteOfferMutation
} = offersApi;