// @ts-nocheck
import { useMutation, useQueryClient, useQuery } from '@tanstack/react-query';

import FacultyApiService from '../../API/FacultyApiService';


export const useGetFacultyByFacultyIdQuery = (facultyId) => {

    return useQuery({
        queryKey: ['getFacultyById', facultyId],
        queryFn: () => FacultyApiService.getFacultyByFacultyId(facultyId),
        staleTime: Infinity,
    });
};

export const useDeleteFacultyByFacultyIdMutation = (setErrorMessage) => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: ([facultyId]) => FacultyApiService.deleteFacultyByFacultyId(facultyId),
        onSuccess: (response) => {
            if (response.data.isSucceeded) {
                queryClient.invalidateQueries({ queryKey: ['getFacultyById'] });
                queryClient.invalidateQueries({ queryKey: ['getUniversityWithFacultiesByUniversityId'] });
                queryClient.invalidateQueries({ queryKey: ['getPaginatedUniversities'] });
            } else {
                setErrorMessage(response.data.error.message);
            }
        },
        onError: (error) => {
            const statusCode = error.response.status;
            if (statusCode === 404) {
                setErrorMessage('Faculty wasn\'t found');
            }
            if (statusCode === 400) {
                setErrorMessage(error.response.data.title);
            }
            else {
                setErrorMessage(error.response.data.error.message);
            }
        },
    });
};

export const usePostFacultyMutation = (setFacultyNameErrorMessage, setModalShow) => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: ([facultyName, universityId]) => FacultyApiService.post({ name: facultyName, universityId: universityId }),
        onSuccess: (response) => {
            if (response.data.isSucceeded) {
                queryClient.invalidateQueries({ queryKey: ['getUniversityWithFacultiesByUniversityId'] });
                queryClient.invalidateQueries({ queryKey: ['getPaginatedUniversities'] });
                setModalShow(false);
                setFacultyNameErrorMessage('');
            } else {
                setFacultyNameErrorMessage(response.data.error.message);
            }
        },
        onError: (error) => {
            const statusCode = error?.response?.status;
            const validationError = error?.response?.data?.data;
            if (statusCode === 400) {
                setFacultyNameErrorMessage(validationError?.Name?.[0]);
            }
            if (error?.code === 'ERR_NETWORK') {
                setFacultyNameErrorMessage('You are not authorized.');
            }
            else {
                setFacultyNameErrorMessage(error.response.data.error.message);
            }
        },
    });
};

