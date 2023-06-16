import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const suppliersApi = createApi({
    reducerPath: 'suppliersApi',
    baseQuery: fetchBaseQuery({baseUrl: 'https://localhost:7253/api'}),
    endpoints: (builder) => ({
        
        getSuppliers: builder.query({
            query: () => '/Suppliers'
        }),

        getTopSuppliers: builder.query({
            query: () => '/Suppliers/topCount'
        }),

        getSupplier: builder.query({
            query: (id) => `/Suppliers/${id}`
        }),

        createSupplier: builder.mutation({
            query: (supplier) => ({
                url: '/Suppliers',
                method: 'POST',
                body: supplier
            }),
        }),

        updateSupplier: builder.mutation({
            query: (supplier) => ({
                url: `/Suppliers/${supplier.id}`,
                method: 'PUT',
                body: supplier
            }),
        }),

        deleteSupplier: builder.mutation({
            query: (id) => ({
                url: `/Suppliers/${id}`,
                method: 'DELETE'
            }),
        })
    }),
});

export const {
    useGetSuppliersQuery,
    useGetTopSuppliersQuery,
    useGetSupplierQuery,
    useCreateSupplierMutation,
    useUpdateSupplierMutation,
    useDeleteSupplierMutation
} = suppliersApi;