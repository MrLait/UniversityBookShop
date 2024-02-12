// @ts-nocheck
import React from "react";
import { useEffect } from "react";
import { useState } from "react";
import { useNavigate, useLocation, useParams } from 'react-router-dom';
import UniversityApiService from "../API/UniversityApiService";
import { paginationField } from "../components/constants/initialStates";
import CreateUniversity from "../components/screens/University/CreateUniversity";
import UniversityList from "../components/screens/University/UniversityList";
import MyPagination from "../components/UI/pagination/MyPagination";
import styles from './Universities.module.css'
import { decrementPaginationTotalCount } from '../unitls/pagination'
import { routePathsNavigate } from "../router/routes"
import transition from "../unitls/transition";

const Universities = () => {
    const navigate = useNavigate();
    const { pageIndex } = useParams();
    const defaultPageIndex = parseInt(useLocation().state?.pageIndex || pageIndex || 1);
    const [universities, setUniversities] = useState([])
    const [paginationData, setPaginationData] = useState(paginationField);
    const [pageSize, setPageSize] = useState(4);
    const [isDeleted, setIsDeleted] = useState(false);

    useEffect(() => {
        getPaginatedUniversities(defaultPageIndex, pageSize);
    }, [defaultPageIndex, isDeleted]);

    const getPaginatedUniversities = async (pageIndex, pageSize) => {
        await UniversityApiService.getAllWithPagination(pageIndex, pageSize)
            .then((response) => {
                var isSucceeded = response.data.isSucceeded;
                //"ToDo isSucceeded = false"
                if (isSucceeded) {
                    setUniversities(response.data.data.items)
                    setPaginationData(response.data.data);
                }
            })
    }

    const deleteUniversity = async (university) => {
        await UniversityApiService.delete(university.id)
            .then(response => {
                if (response.status == 200 && response.data.isSucceeded) {
                    setUniversities(universities.filter(u => u.id !== university.id))
                    decrementPaginationTotalCount(setPaginationData);
                    setIsDeleted(!isDeleted);
                }
                //"ToDo isSucceeded = false"
            }
            ).catch(error => {
                if (error.response.data) {
                    //"ToDo Universities error"
                }
            })
    }
    const changePage = (pageIndex) => {
        getPaginatedUniversities(pageIndex, pageSize);
        navigate(routePathsNavigate.UniversitiesPage(pageIndex), { state: { pageIndex } });
    }

    return (
        <>
            <div className={styles.contentHeader}>
                <div className={styles.inner}>
                    <div className={styles.createUniversity}>
                        <div className={styles.heading}>
                            <h3>
                                Welcome to my website
                                <br />
                                where you can create universities, faculties, and manage book purchases.
                            </h3>
                        </div>
                        <div className={styles.create}>
                            <div className={styles.createLeft}>
                                <CreateUniversity
                                    setPaginationData={setPaginationData} paginationData={paginationData}
                                    setUniversities={setUniversities} universities={universities} />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div className={styles.block}>
                <div className={styles.inner}>
                    <div className={styles.headingCenter}>
                        <h3 className={styles.headingBig}>
                            Universities
                        </h3>
                    </div>
                    <MyPagination
                        paginationData={paginationData}
                        pageIndex={defaultPageIndex}
                        changePage={changePage}
                        className={styles.pagination}
                    />
                    <div >
                        {universities.length === 0 ? <p>No universities found.</p> :
                            <UniversityList
                                pageSize={pageSize}
                                deleteUniversity={deleteUniversity} universities={universities} />
                        }
                    </div>
                </div>
            </div>
        </>
    );
}
export default transition(Universities);