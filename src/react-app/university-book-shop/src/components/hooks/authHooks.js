// @ts-nocheck
import { useMutation, useQueryClient, useQuery } from '@tanstack/react-query';

import { useContext } from 'react';

import AuthApiService from '../../API/AuthUrls';
import AuthContext from '../contexts/AuthProvider';

const useAuth = () => {
    return useContext(AuthContext);
};
export default useAuth;

export const usePostLoginMutation = (setUserNameError, setPasswordError, setModalShow, setAuth) => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: ([userName, password]) => AuthApiService.loginByNameAndPassword(userName, password),
        onSuccess: (response) => {
            // if (response.data.isSucceeded) {
            if (response.status === 200) {
                if (!response.data.isSucceeded) {
                    if (response.data.error.statusCode === 998) {
                        setUserNameError('Invalid username or password');
                        setPasswordError('Invalid username or password');
                    }
                } else {
                    const accessToken = response.data.data.accessToken;
                    queryClient.invalidateQueries({ queryKey: ['getPaginatedUniversities'] }); //ToDo
                    setUserNameError('');
                    setPasswordError('');
                    setModalShow(false);
                    setAuth({ accessToken });
                }
            }
        },
        onError: (error) => {
            const statusCode = error?.response?.data?.error?.statusCode;
            const validationErrors = error?.response?.data?.data;

            if (statusCode === 998) {
                setUserNameError(validationErrors?.UserName?.[0]);
                setPasswordError(validationErrors?.Password?.[0]);
            }
            else {
                setPasswordError(error?.response?.data?.error?.message ?? 'Login Failed');
            };
            localStorage.removeItem('accessToken');
        },
    });
};