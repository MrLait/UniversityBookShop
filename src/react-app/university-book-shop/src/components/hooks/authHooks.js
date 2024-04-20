// @ts-nocheck
import { useMutation, useQueryClient, useQuery } from '@tanstack/react-query';

import AuthApiService from '../../API/AuthUrls';

export const usePostLoginMutation = (setUserNameError, setPasswordError, setModalShow) => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: ([userName, password]) => AuthApiService.loginByNameAndPassword(userName, password),
        onSuccess: (response) => {
            // if (response.data.isSucceeded) {
            if (response.status === 200) {
                const token = response.data.accessToken;
                queryClient.invalidateQueries({ queryKey: ['getPaginatedUniversities'] }); //ToDo
                setUserNameError('');
                setPasswordError('');
                setModalShow(false);
                localStorage.removeItem('accessToken');
                localStorage.setItem('accessToken', token);
            }
        },
        onError: (error) => {
            const statusCode = error?.response?.data?.error?.statusCode;
            const validationErrors = error?.response?.data?.data;

            if (statusCode === 998) {
                setUserNameError(validationErrors?.Name?.[0]);
                setPasswordError(validationErrors.Description?.[0]);
            }
            localStorage.removeItem('accessToken');
        },
    });
};