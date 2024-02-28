// @ts-nocheck
import { useMutation, useQueryClient, useQuery } from '@tanstack/react-query';

import PurchasedBookApiService from '../../API/PurchasedBookApiService';
import BookApiService from '../../API/BookApiService';
import BooksAvailableForFacultyApiService from '../../API/BooksAvailableForFaculty';

export const useGetBooksWithPurchaseStatusByFacultyIdQuery = (facultyId, pageIndex, pageSize) => {

    return useQuery({
        queryKey: ['getBooks', pageIndex],
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

export const usePurchaseBookMutation = () => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: ([bookId, facultyId]) => PurchasedBookApiService.postPurchaseBookForFaculty(bookId, facultyId),
        onSuccess: () => {
            queryClient.invalidateQueries({ queryKey: ['getBooks'] });
        },
    });
};

export const useDeleteBookMutation = () => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: ([bookId, facultyId]) => PurchasedBookApiService.deleteByFacultyIdAndBookId(facultyId, bookId),
        onSuccess: () => {
            queryClient.invalidateQueries({ queryKey: ['getBooks'] });
        },
    });
};

export const useAddBookMutation = () => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: ([bookId, facultyId]) => BooksAvailableForFacultyApiService.postAddBook(bookId, facultyId),
        onSuccess: () => {
            queryClient.invalidateQueries({ queryKey: ['getBooks'] });
        },
    });
};

export const useRemoveAvailableBookMutation = () => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: (availableBookId) => BooksAvailableForFacultyApiService.deleteAvailableBook(availableBookId),
        onSuccess: () => {
            queryClient.invalidateQueries({ queryKey: ['getBooks'] });
        },
    });
};
