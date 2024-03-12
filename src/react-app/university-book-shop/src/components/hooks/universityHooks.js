// @ts-nocheck
import { useMutation, useQueryClient, useQuery } from '@tanstack/react-query';

import UniversityApiService from '../../API/UniversityApiService';

export const useGetUniversityWithItsFacultiesByUniversityIdQuery = (universityId, pageIndex, pageSize) => {
    return useQuery({
        queryKey: ['getUniversityWithFacultiesByUniversityId', universityId, pageIndex, pageSize],
        queryFn: () => UniversityApiService.getUniversityByUniversityIdWithPaginatedFaculties(universityId, pageIndex, pageSize),
        staleTime: Infinity,
    });
};

export const useGetPaginatedUniversitiesQuery = (pageIndex, pageSize) => {
    return useQuery({
        queryKey: ['getPaginatedUniversities', pageIndex, pageSize],
        queryFn: () => UniversityApiService.getAllWithPagination(pageIndex, pageSize),
        staleTime: Infinity,
    });
};

export const useDeleteUniversityByUniversityIdMutation = (setErrorMessage) => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: ([universityId]) => UniversityApiService.deleteUniversityByUniversityId(universityId),
        onSuccess: (response) => {
            if (response.data.isSucceeded) {
                queryClient.invalidateQueries({ queryKey: ['getPaginatedUniversities'] });
                setErrorMessage('');
            } else {
                setErrorMessage(response.data.error.message);
            }
        },
        onError: (error) => {
            const statusCode = error?.response?.data?.status;
            const validationError = error?.response?.data;
            if (statusCode === 400) {
                setErrorMessage(validationError?.errors?.id?.[0]);
            }
            if (statusCode === 404) {
                setErrorMessage(validationError?.error?.message);
            }
            else {
                setErrorMessage(validationError?.error?.message);
            }
        },
    });
};

export const usePostUniversityMutation = (setNameError, setDescriptionError, setModalShow) => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: ([universityId]) => UniversityApiService.post(universityId),
        onSuccess: (response) => {
            if (response.data.isSucceeded) {
                queryClient.invalidateQueries({ queryKey: ['getPaginatedUniversities'] });
                setNameError('');
                setDescriptionError('');
                setModalShow(false);
            }
        },
        onError: (error) => {
            const statusCode = error?.response?.data?.error?.statusCode;
            const validationErrors = error?.response?.data?.data;

            if (statusCode === 998) {
                setNameError(validationErrors?.Name?.[0]);
                setDescriptionError(validationErrors.Description?.[0]);
            }
        },
    });
};