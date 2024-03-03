// @ts-nocheck
import { useNavigate, useSearchParams } from 'react-router-dom';
import React, { useCallback, useState } from 'react';

import { useGetPaginatedUniversitiesQuery } from '../../components/hooks/universityHooks';
import UniversityList from '../../components/screens/Universities/UniversityList/UniversityList';
import MyPagination from '../../components/UI/pagination/MyPagination';
import { routePathsNavigate } from '../../router/routes';
import transition from '../../unitls/transition';
import UniversitiesHeaderSection from '../../components/screens/Universities/UniversitiesHeaderSection';

import styles from './UniversitiesPage.module.css';

const UniversitiesPage = () => {
    const [searchParams] = useSearchParams();
    const navigate = useNavigate();
    const pageIndex = parseInt(searchParams.get('page') || 1);
    const [pageSize] = useState(4);
    const { data: universitiesData } = useGetPaginatedUniversitiesQuery(pageIndex, pageSize);

    const changePage = useCallback((pageIndex) => {
        navigate(routePathsNavigate.UniversitiesPage(pageIndex));
    }, [navigate]);

    return (
        <>
            <UniversitiesHeaderSection />
            <div className={styles.block}>
                <div className={styles.inner}>
                    <div className={styles.contentBody}>
                        <div className={styles.headingCenter}>
                            <h3 className={styles.headingBig}>
                                Universities
                            </h3>
                        </div>
                        <MyPagination
                            paginationData={universitiesData?.paginationData}
                            pageIndex={pageIndex}
                            changePage={changePage}
                        />
                        <UniversityList
                            pageSize={pageSize}
                            universities={universitiesData?.universities}
                        />
                    </div>
                </div>
            </div >
        </>
    );
};
export default transition(UniversitiesPage);