import { useMutation, useQueryClient, useQuery } from '@tanstack/react-query';

import UniversityApiService from '../../API/UniversityApiService';

export const useGetUniversityWithItsFacultiesByUniversityIdQuery = (universityId, pageIndex, pageSize) => {
    return useQuery({
        queryKey: ['getUniversityWithFacultiesByUniversityId', pageIndex],
        queryFn: () => UniversityApiService.getUniversityByUniversityIdWithPaginatedFaculties(universityId, pageIndex, pageSize),
        staleTime: Infinity,
    });
};

