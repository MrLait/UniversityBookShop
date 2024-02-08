// @ts-nocheck
import React, { useEffect, useState } from 'react'
import { useNavigate, useLocation, useParams } from 'react-router-dom';
import FacultyApiService from '../API/FacultyApiService';
import UniversityApiService from '../API/UniversityApiService';
import { facultyField, universityField } from '../components/constants/initialStates';
import FacultyList from '../components/screens/Faculty/FacultyList';
import { paginationField } from "../components/constants/initialStates";
import CreateFaculty from '../components/screens/Faculty/CreateFaculty'
import styles from './UniversityIdPage.module.css'

const UniversityIdPage = () => {
    const navigate = useNavigate();
    const { pageIndex } = useParams();
    const universityId = parseInt(useParams().UniversityId);
    const universityState = useLocation().state?.university;
    const defaultPageIndex = parseInt(useLocation().state?.pageIndex || pageIndex) || 1;
    const [pageSize, setPageSize] = useState(4);
    const defaultFaculties = useLocation().state?.university?.faculties || [];
    const [faculties, setFaculties] = useState(defaultFaculties)
    const [university, setUniversity] = useState(universityState);
    const [paginationData, setPaginationData] = useState(paginationField);

    const getUniversityByUniversityIdAndWithPaginatedFaculties = async (universityId, pageIndex, pageSize) => {
        await UniversityApiService
            .getUniversityByUniversityIdWithPaginatedFaculties(universityId, pageIndex, pageSize)
            .then(response => {
                var isSucceeded = response.data.isSucceeded;
                //ToDo if false;
                if (isSucceeded) {
                    const data = response.data.data;
                    const facultiesWithPagination = data.facultiesWithPagination;

                    setUniversity(data)
                    setPaginationData(facultiesWithPagination);
                    setFaculties(facultiesWithPagination.items);
                }
            })
    }

    useEffect(() => {
        getUniversityByUniversityIdAndWithPaginatedFaculties(universityId, defaultPageIndex, pageSize);
    }, [])

    return (
        <div className={styles.block}>
            {university
                ?
                <>
                    <div className={styles.inner}>
                        <div className={`${styles.contentHeaderTop} ${styles.textCenter}`}>
                            <div className={styles.headerTop}>
                                <h1 className={`${styles.headerTopText} ${styles.upperCase}`}>
                                    University
                                    <br />
                                    {university.name}
                                </h1>
                            </div>
                            <div className={styles.headerBottom}>
                                <span className={styles.headerBotText}>
                                    {university.description}
                                </span>
                            </div>
                        </div>
                        <div className={styles.contentHeaderBot} >
                            <div className={styles.headerBotFlexLeft}>
                                <strong>{university?.facultiesWithPagination?.totalCount} </strong>
                                number of faculties available.
                            </div>
                            <div className={styles.headerBotFlexRight}>
                                <CreateFaculty
                                    btnStyles={styles.blackButton}
                                    faculties={faculties}
                                    setFaculties={setFaculties}
                                />
                            </div>
                        </div>
                    </div>
                    <div className={styles.contentBody}>
                        <div className={styles.inner}>
                            <FacultyList
                                faculties={faculties}
                                setFaculties={setFaculties}
                            />
                        </div>
                    </div>
                </>
                :
                <div className={styles.inner}>
                    <div> University not found</div>
                </div>
            }
        </div >
    )
}

export default UniversityIdPage
