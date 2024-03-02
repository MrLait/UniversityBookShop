// @ts-nocheck
import React, { useCallback } from 'react';
import { useNavigate, useParams, useSearchParams } from 'react-router-dom';

import { useGetUniversityWithItsFacultiesByUniversityIdQuery } from '../../components/hooks/universityHooks';
import FacultyList from '../../components/screens/Faculty/FacultyList/FacultyList';
import CreateFaculty from '../../components/screens/Faculty/CreateFaculty';
import { routePathsNavigate } from '../../router/routes';
import transition from '../../unitls/transition';
import ContentWithPaginationSection from '../../components/UI/pagination/ContentWithPaginationSection';
import UniversityByUniversityIdHeaderSection from '../../components/screens/UniversityByUniversityId/UniversityByUniversityIdHeaderSection';


import styles from './UniversityIdPage.module.css';

const UniversityByUniversityIdPage = () => {
    const [searchParams] = useSearchParams();
    const navigate = useNavigate();
    const pageIndex = parseInt(searchParams.get('page') || 1);
    const universityId = useParams().UniversityId;
    const pageSize = 4;
    const { data: universityData } = useGetUniversityWithItsFacultiesByUniversityIdQuery(universityId, pageIndex, pageSize);

    const changePage = useCallback((pageIndex) => {
        navigate(routePathsNavigate.UniversityIdFacultiesPage(universityId, pageIndex));
    }, [navigate, universityId]);

    return (
        <div className={styles.block}>
            <>
                <div className={styles.inner}>
                    <UniversityByUniversityIdHeaderSection
                        name={universityData?.university?.name}
                        description={universityData?.university?.description}
                    />
                    <div className={styles.contentBody}>
                        <div className={styles.headingCenter}>
                            <h3 className={styles.headingBig}>
                                Faculties
                            </h3>
                        </div>
                        <ContentWithPaginationSection
                            totalCountLabel={'number of faculties available.'}
                            paginationData={universityData?.facultyPaginationData}
                            pageIndex={pageIndex}
                            changePage={changePage}
                        />
                        <FacultyList
                            pageSize={pageSize}
                            faculties={universityData?.faculties}
                        />
                        <CreateFaculty />
                    </div>
                </div>
            </>
        </div >
    );
};

export default transition(UniversityByUniversityIdPage);
