// @ts-nocheck
import { useMutation, useQueryClient, useQuery } from '@tanstack/react-query';

import PurchasedBookApiService from '../../API/PurchasedBookApiService';
import BookApiService from '../../API/BookApiService';
import BooksAvailableForFacultyApiService from '../../API/BooksAvailableForFaculty';

export const useGetBooksWithPurchaseStatusByFacultyIdQuery = (facultyId, pageIndex, pageSize) => {

    return useQuery({
        queryKey: ['getBooks', pageIndex, facultyId],
        queryFn: () => BookApiService.getBooksWithPurchaseStatusByFacultyIdWithPagination(facultyId, pageIndex, pageSize),
        staleTime: Infinity,
    });
};

export const useGetAvailableBookQuery = (bookId, facultyId) => {
    return useQuery({
        queryKey: ['getAvailableBook', bookId, facultyId],
        queryFn: () => BooksAvailableForFacultyApiService.getByFacultyIdBookId(facultyId, bookId),
        staleTime: Infinity,
        enabled: false,
    });
};

export const usePurchaseBookMutation = (setErrorMessage) => {
    const queryClient = useQueryClient();
    return useMutation({
        mutationFn: ([bookId, facultyId]) => PurchasedBookApiService.postPurchaseBookForFaculty(bookId, facultyId),
        onSuccess: (response) => {
            if (response.data.isSucceeded) {
                queryClient.invalidateQueries({ queryKey: ['getBooks'] });
                queryClient.invalidateQueries({ queryKey: ['getPurchasedBooksByFacultyId'] });
            }
            else {
                setErrorMessage(response.data.error.message);
            }
        },
        onError: (error) => {
            const statusCode = error.response.status;
            if (statusCode === 404) {
                setErrorMessage('Book wasn\'t found');
            }
            else {
                setErrorMessage(error.response.data.error.message);
            }
        },
    });
};

export const useDeleteBookMutation = (setErrorMessage) => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: ([bookId, facultyId]) => PurchasedBookApiService.deleteByFacultyIdAndBookId(facultyId, bookId),
        onSuccess: (response) => {
            if (response.data.isSucceeded) {
                queryClient.invalidateQueries({ queryKey: ['getBooks'] });
                queryClient.invalidateQueries({ queryKey: ['getPurchasedBooksByFacultyId'] });
            } else {
                setErrorMessage(response.data.error.message);
            }
        },
        onError: (error) => {
            const statusCode = error.response.status;
            if (statusCode === 404) {
                setErrorMessage('Book wasn\'t found');
            }
            else {
                setErrorMessage(error.response.data.error.message);
            }
        },
    });
};

export const useAddBookMutation = (setErrorMessage) => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: ([bookId, facultyId]) => BooksAvailableForFacultyApiService.postAddBook(bookId, facultyId),
        onSuccess: (response) => {
            if (response.data.isSucceeded) {
                queryClient.invalidateQueries({ queryKey: ['getBooks'] });
                queryClient.invalidateQueries({ queryKey: ['getPurchasedBooksByFacultyId'] });
            } else {
                setErrorMessage(response.data.error.message);
            }
        },
        onError: (error) => {
            const statusCode = error.response.status;
            if (statusCode === 404) {
                setErrorMessage('Book wasn\'t found');
            }
            else {
                setErrorMessage(error.response.data.error.message);
            }
        },
    });
};

export const useRemoveAvailableBookMutation = (setErrorMessage) => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: (availableBookId) => BooksAvailableForFacultyApiService.deleteAvailableBook(availableBookId),
        onSuccess: (response) => {
            if (response.data.isSucceeded) {
                queryClient.invalidateQueries({ queryKey: ['getBooks'] });
                queryClient.invalidateQueries({ queryKey: ['getPurchasedBooksByFacultyId'] });
            } else {
                setErrorMessage(response.data.error.message);
            }
        },
        onError: (error) => {
            const statusCode = error.response.status;
            if (statusCode === 404) {
                setErrorMessage('Book wasn\'t found');
            }
            else {
                setErrorMessage(error.response.data.error.message);
            }
        },
    });
};
