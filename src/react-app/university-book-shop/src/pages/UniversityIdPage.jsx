// @ts-nocheck
import React, { useEffect, useState } from 'react';
import { useNavigate, useParams, useSearchParams } from 'react-router-dom';

import UniversityApiService from '../API/UniversityApiService';
import FacultyList from '../components/screens/Faculty/FacultyList';
import CreateFaculty from '../components/screens/Faculty/CreateFaculty';
import { paginationField } from '../components/constants/initialStates';
import MyPagination from '../components/UI/pagination/MyPagination';
import { routePathsNavigate } from '../router/routes';
import transition from '../unitls/transition';

import styles from './UniversityIdPage.module.css';

const UniversityIdPage = () => {
    const [searchParams] = useSearchParams();
    const pageIndex = searchParams.get('page');
    const navigate = useNavigate();
    const defaultPageIndex = parseInt(pageIndex || 1);

    const universityId = parseInt(useParams().UniversityId);
    const [pageSize, setPageSize] = useState(4);
    const [faculties, setFaculties] = useState([]);
    const [university, setUniversity] = useState();
    const [paginationData, setPaginationData] = useState(paginationField);
    const [isDeleted, setIsDeleted] = useState(false);

    const getUniversityByUniversityIdAndWithPaginatedFaculties = async (universityId, pageIndex, pageSize) => {
        await UniversityApiService
            .getUniversityByUniversityIdWithPaginatedFaculties(universityId, pageIndex, pageSize)
            .then(response => {
                var isSucceeded = response.data.isSucceeded;
                //ToDo if false;
                if (isSucceeded) {
                    const data = response.data.data;
                    const facultiesWithPagination = data.facultiesWithPagination;

                    setUniversity(data);
                    setPaginationData(facultiesWithPagination);
                    setFaculties(facultiesWithPagination.items);
                }
            });
    };

    useEffect(() => {
        getUniversityByUniversityIdAndWithPaginatedFaculties(universityId, defaultPageIndex, pageSize);
    }, [isDeleted]);

    const changePage = (pageIndex) => {
        getUniversityByUniversityIdAndWithPaginatedFaculties(universityId, pageIndex, pageSize);
        navigate(routePathsNavigate.UniversityIdFacultiesPage(universityId, pageIndex));
    };

    return (
        <div className={styles.block}>
            {university
                ?
                <>
                    <div className={styles.inner}>
                        <div className={`${styles.contentHeaderTop} `}>
                            <div className={`${styles.headerTop} ${styles.textCenter}`} >
                                <h1 className={`${styles.textSizeMedium}`}>
                                    {university.name}
                                </h1>
                            </div>
                            <div className={`${styles.textCenter}`} >
                                <span className={styles.headerBotText}>
                                    {university.description}
                                </span>
                            </div>
                        </div>
                        <div className={styles.contentBody}>
                            <div className={styles.headingCenter}>
                                <h3 className={styles.headingBig}>
                                    Faculties
                                </h3>
                            </div>
                            <div className={styles.contentHeaderBot} >
                                <div className={styles.headerBotFlexLeft}>
                                    <strong>{paginationData.totalCount ?? 0} </strong>
                                    number of faculties available.
                                </div>
                                <div className={styles.headerBotFlexRight}>
                                    <MyPagination
                                        paginationData={paginationData}
                                        pageIndex={defaultPageIndex}
                                        changePage={changePage}
                                        className={styles.pagination}
                                    />
                                </div>
                            </div>
                            <FacultyList
                                pageSize={pageSize}
                                setPaginationData={setPaginationData}
                                setIsDeleted={setIsDeleted}
                                isDeleted={isDeleted}
                                faculties={faculties}
                                setFaculties={setFaculties}
                            />
                            <CreateFaculty
                                setPaginationData={setPaginationData}
                                btnStyles={styles.blackButton}
                                faculties={faculties}
                                setFaculties={setFaculties}
                            />
                        </div>
                    </div>
                </>
                :
                <div className={styles.inner}>
                    <div>There is no university.</div>
                </div>
            }
        </div >
    );
};

export default transition(UniversityIdPage);
