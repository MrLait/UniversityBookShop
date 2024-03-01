// @ts-nocheck
import React, { useEffect, useState } from 'react';

import { useParams, useSearchParams, useNavigate } from 'react-router-dom';

import PurchasedBooksList from '../../components/screens/PurchasedBooksByFacultyId/PurchasedBooksList';


import FacultyApiService from '../../API/FacultyApiService';
import { paginationField } from '../../components/constants/initialStates';
import { routePathsNavigate } from '../../router/routes';
import BooksAvailableForFacultyApiService from '../../API/BooksAvailableForFaculty';
import transition from '../../unitls/transition';
import ContentWithPaginationSection from '../../components/screens/PurchaseBooksByFacultyId/ContentWithPaginationSection';
import PurchasedBookHeaderSection from '../../components/screens/PurchasedBooksByFacultyId/PurchasedBookHeaderSection';

import styles from './PurchasedBooksByFacultyId.module.css';

const PurchasedBooksByFacultyId = () => {
    const [searchParams] = useSearchParams();
    const pageIndex = searchParams.get('page');
    const navigate = useNavigate();
    const defaultPageIndex = parseInt(pageIndex || 1);

    const [faculty, setFaculty] = useState('');
    const [paginationData, setPaginationData] = useState(paginationField);
    const pageSize = 4;

    const facultyId = parseInt(useParams().facultyId || 0);
    const universityId = parseInt(useParams().UniversityId || 0);
    const [purchasedBooks, setPurchasedBooks] = useState([]);
    const [isDeleted, setIsDeleted] = useState(false);

    useEffect(() => {
        if (faculty.length === 0) {
            getFacultyByFacultyId(facultyId);
        }
        else {
            getPurchasedBooks(facultyId, defaultPageIndex, pageSize);
        }

    }, [defaultPageIndex, faculty.length, facultyId]);

    const getFacultyByFacultyId = async (facultyId) => {
        await FacultyApiService
            .getFacultyByFacultyId(facultyId)
            .then(response => {
                var isSucceeded = response.data.isSucceeded;
                var data = response.data.data;
                //ToDo if false;
                if (isSucceeded) {
                    setFaculty(data);
                }
            });
    };

    const getPurchasedBooks = async (facultyId, pageIndex, pageSize) => {
        await BooksAvailableForFacultyApiService.getByFacultyIdWithPagination(facultyId, pageIndex, pageSize)
            .then((response) => {
                var isSucceeded = response.data.isSucceeded;
                if (response.status === 200)
                    if (isSucceeded) {
                        const books = response.data.data.items;
                        setPurchasedBooks(books);
                        setPaginationData(response.data.data);
                    } else {
                        setPaginationData(response.data.data);
                    }
            });
    };

    const changePage = (pageIndex) => {
        navigate(routePathsNavigate.PurchasedBooksByFacultyIdPage(universityId, facultyId, pageIndex));
    };

    return (
        <div className={styles.block}>
            <div className={styles.inner}>
                <PurchasedBookHeaderSection
                    facultyName={faculty?.name}
                />
                <div className={styles.contentBody}>
                    <div className={styles.headingCenter}>
                        <h3 className={styles.headingBig}>
                            Available books
                        </h3>
                    </div>
                    <ContentWithPaginationSection
                        paginationData={paginationData}
                        defaultPageIndex={defaultPageIndex}
                        changePage={changePage}
                    />
                    <PurchasedBooksList
                        pageSize={pageSize}
                        setPaginationData={setPaginationData}
                        setIsDeleted={setIsDeleted}
                        isDeleted={isDeleted}
                        purchasedBooks={purchasedBooks}
                        setPurchasedBooks={setPurchasedBooks}
                    />
                </div>
            </div>
        </div>
    );
};
export default transition(PurchasedBooksByFacultyId);