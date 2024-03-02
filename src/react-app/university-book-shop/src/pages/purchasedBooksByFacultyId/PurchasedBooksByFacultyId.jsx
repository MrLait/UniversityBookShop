// @ts-nocheck
import React from 'react';
import { useParams, useSearchParams, useNavigate } from 'react-router-dom';

import PurchasedBooksList from '../../components/screens/PurchasedBooksByFacultyId/PurchasedBookList/PurchasedBooksList';
import { useGetFacultyByFacultyIdQuery } from '../../components/hooks/facultyHooks';
import { useGetPurchasedBooksByFacultyIdQuery } from '../../components/hooks/booksAvailableForFacultyHooks';
import { routePathsNavigate } from '../../router/routes';

import transition from '../../unitls/transition';
import ContentWithPaginationSection from '../../components/UI/pagination/ContentWithPaginationSection';
import PurchasedBookHeaderSection from '../../components/screens/PurchasedBooksByFacultyId/PurchasedBookHeaderSection';

import styles from './PurchasedBooksByFacultyId.module.css';

const PurchasedBooksByFacultyId = () => {
    const [searchParams] = useSearchParams();
    const navigate = useNavigate();
    const pageIndex = parseInt(searchParams.get('page') || 1);
    const pageSize = 4;
    const facultyId = parseInt(useParams().facultyId || 0);

    const universityId = parseInt(useParams().UniversityId || 0);

    const { data: faculty } = useGetFacultyByFacultyIdQuery(facultyId);
    const { data: purchasedBooks } = useGetPurchasedBooksByFacultyIdQuery(facultyId, pageIndex, pageSize);

    const changePage = (pageIndex) => {
        navigate(routePathsNavigate.PurchasedBooksByFacultyIdPage(universityId, facultyId, pageIndex));
    };
    return (
        <div className={styles.block}>
            <div className={styles.inner}>
                <PurchasedBookHeaderSection
                    facultyName={faculty?.faculty?.name}
                />
                <div className={styles.contentBody}>
                    <div className={styles.headingCenter}>
                        <h3 className={styles.headingBig}>
                            Available books
                        </h3>
                    </div>
                    <ContentWithPaginationSection
                        totalCountLabel={'number of books available.'}
                        paginationData={purchasedBooks?.paginationData}
                        pageIndex={pageIndex}
                        changePage={changePage}
                    />
                    <PurchasedBooksList
                        pageSize={pageSize}
                        availableBooks={purchasedBooks?.availableBooks}
                    />
                </div>
            </div>
        </div>
    );
};
export default transition(PurchasedBooksByFacultyId);