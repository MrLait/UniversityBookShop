// @ts-nocheck
import React, { useEffect, useState } from 'react'
import PurchasedBooksList from '../components/screens/PurchasedBook/PurchasedBooksList'
import { useParams, useSearchParams, useNavigate } from 'react-router-dom'
import styles from './PurchasedBooksByFacultyId.module.css'
import FacultyApiService from '../API/FacultyApiService'
import MyPagination from '../components/UI/pagination/MyPagination'
import { paginationField } from "../components/constants/initialStates";
import { routePathsNavigate } from "../router/routes"
import BooksAvailableForFacultyApiService from '../API/BooksAvailableForFaculty';
import transition from '../unitls/transition'

const PurchasedBooksByFacultyId = () => {
    const [searchParams] = useSearchParams();
    const pageIndex = searchParams.get('page')
    const navigate = useNavigate();
    const defaultPageIndex = parseInt(pageIndex || 1);

    const [faculty, setFaculty] = useState('');
    const [paginationData, setPaginationData] = useState(paginationField);
    const [pageSize, setPageSize] = useState(4);

    const facultyId = parseInt(useParams().facultyId || 0);
    const universityId = parseInt(useParams().UniversityId || 0);
    const [purchasedBooks, setPurchasedBooks] = useState([]);
    const [isDeleted, setIsDeleted] = useState(false);
    useEffect(() => {
        if (faculty.length === 0) {
            getFacultyByFacultyId(facultyId);
        }
        getPurchasedBooks(facultyId, defaultPageIndex, pageSize)
    }, [isDeleted])

    const getFacultyByFacultyId = async (facultyId) => {
        await FacultyApiService
            .getFacultyByFacultyId(facultyId)
            .then(response => {
                var isSucceeded = response.data.isSucceeded;
                var data = response.data.data;
                //ToDo if false;
                if (isSucceeded) {
                    setFaculty(data)
                }
            })
    }

    const getPurchasedBooks = async (facultyId, pageIndex, pageSize) => {
        await BooksAvailableForFacultyApiService.getByFacultyIdWithPagination(facultyId, pageIndex, pageSize)
            .then((response) => {
                var isSucceeded = response.data.isSucceeded;
                if (response.status === 200 && isSucceeded) {
                    const books = response.data.data.items;
                    setPurchasedBooks(books)
                    setPaginationData(response.data.data);
                }
            });
    }

    const changePage = (pageIndex) => {
        getPurchasedBooks(facultyId, pageIndex, pageSize);
        navigate(routePathsNavigate.PurchasedBooksByFacultyIdPage(universityId, facultyId, pageIndex));
    }
    return (
        <div className={styles.block}>
            <div className={styles.inner}>
                <div className={`${styles.contentHeaderTop}`}>
                    <div className={`${styles.headerTop} ${styles.textCenter}`} >
                        <h1 className={`${styles.textSizeMedium}`}>
                            {faculty.name}
                        </h1>
                    </div>
                </div>
                <div className={styles.contentBody}>
                    <div className={styles.headingCenter}>
                        <h3 className={styles.headingBig}>
                            Available books
                        </h3>
                    </div>
                    <div className={styles.contentHeaderBot} >
                        <div className={styles.headerBotFlexLeft}>
                            <strong>{paginationData.totalCount ?? 0} </strong>
                            number of available books.
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
    )
}
export default transition(PurchasedBooksByFacultyId);