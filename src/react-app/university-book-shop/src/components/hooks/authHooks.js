// @ts-nocheck
import { useMutation, useQueryClient } from '@tanstack/react-query';
import { useContext } from 'react';

import AuthApiService from '../../API/AuthUrls';
import AuthContext from '../contexts/AuthProvider';

const useAuth = () => {
    return useContext(AuthContext);
};
export default useAuth;

export const usePostLoginMutation = (setUserNameError, setPasswordError,
    setModalShow, setAuth, isRememberMe) => {
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

                    // if (isRememberMe) {
                    localStorage.setItem('accessToken', accessToken);
                    localStorage.setItem('isAuth', true);
                    localStorage.setItem('isRememberMe', true);
                    setAuth({ isAuth: true, accessToken: accessToken });
                    // } else {
                    //     setAuth({ isAuth: true, accessToken: accessToken });

                    //     bookShopApiPrivateInstance.interceptors.request.use(config => {
                    //         console.log(config.headers);
                    //         config.headers.Authorization = `Bearer ${accessToken}`;
                    //         return config;
                    //     });
                    // }
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
            localStorage.removeItem('isAuth');
            localStorage.removeItem('isRememberMe');
            setAuth({ isAuth: false, accessToken: null });
        },
    });
};

