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

