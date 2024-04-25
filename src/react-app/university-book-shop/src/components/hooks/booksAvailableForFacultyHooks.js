// @ts-nocheck
import { useMutation, useQueryClient, useQuery } from '@tanstack/react-query';

import BooksAvailableForFacultyApiService from '../../API/BooksAvailableForFaculty';

export const useGetPurchasedBooksByFacultyIdQuery = (facultyId, pageIndex, pageSize) => {
    return useQuery({
        queryKey: ['getPurchasedBooksByFacultyId', pageIndex, facultyId],
        queryFn: () => BooksAvailableForFacultyApiService.getByFacultyIdWithPagination(facultyId, pageIndex, pageSize),
        staleTime: Infinity,
    });
};

export const useGetPaginatedAvailableBooksByFacultyIdQuery = (facultyId, pageIndex, pageSize) => {
    return useQuery({
        queryKey: ['getAvailableBooksByFacultyId', facultyId, pageIndex],
        queryFn: () => BooksAvailableForFacultyApiService.getByFacultyIdWithPagination(facultyId, pageIndex, pageSize),
        staleTime: Infinity,
        enabled: false,
    });
};


export const useDeleteAvailableBookMutation = (setErrorMessage) => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: ([bookId]) => BooksAvailableForFacultyApiService.deleteAvailableBook(bookId),
        onSuccess: (response) => {
            if (response?.data?.isSucceeded) {
                queryClient.invalidateQueries({ queryKey: ['getPurchasedBooksByFacultyId'] });
                queryClient.invalidateQueries({ queryKey: ['getBooks'] });
            } else {
                setErrorMessage(response?.data?.error?.message);
            }
        },
        onError: (error) => {
            const statusCode = error?.response?.status;
            if (statusCode === 404) {
                setErrorMessage('Book wasn\'t found');
            }
            if (statusCode === 400) {
                setErrorMessage(error?.response?.data?.title);
            }
            if (error?.code === 'ERR_NETWORK') {
                setErrorMessage('You are not authorized');
            }
            if (error?.response?.status === 401) {
                setErrorMessage('You are not authorized');
            }
            else {
                setErrorMessage(error?.response?.data?.error?.message);
            }
        },
    });
};



