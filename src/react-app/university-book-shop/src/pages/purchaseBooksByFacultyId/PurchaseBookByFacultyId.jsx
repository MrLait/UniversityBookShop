// @ts-nocheck
import React, { useCallback } from 'react';
import { useParams, useSearchParams, useNavigate } from 'react-router-dom';

import BookList from '../../components/screens/PurchaseBooksByFacultyId/BookList/BookList';
import { useGetBooksWithPurchaseStatusByFacultyIdQuery } from '../../components/hooks/bookPurchaseActionsHooks';
import transition from '../../unitls/transition';
import { routePathsNavigate } from '../../router/routes';
import PurchaseBookHeaderSection from '../../components/screens/PurchaseBooksByFacultyId/PurchaseBookHeaderSection';
import ContentWithPaginationSection from '../../components/UI/pagination/ContentWithPaginationSection';

import styles from './PurchaseBookByFacultyId.module.css';

const PurchaseBookByFacultyId = () => {
    const [searchParams] = useSearchParams();
    const navigate = useNavigate();
    const pageIndex = parseInt(searchParams.get('page') || 1);
    const pageSize = 4;
    const facultyId = parseInt(useParams().facultyId || 0);
    const { data: books } = useGetBooksWithPurchaseStatusByFacultyIdQuery(facultyId, pageIndex, pageSize);

    const changePage = useCallback((pageIndex) => {
        navigate(routePathsNavigate.SearchBookByFacultyIdPage(facultyId, pageIndex));
    }, [facultyId, navigate]);

    return (
        <div className={styles.block}>
            <div className={styles.inner}>
                <PurchaseBookHeaderSection />
                <div className={styles.contentBody}>
                    <ContentWithPaginationSection
                        totalCountLabel={'number of books available.'}
                        paginationData={books?.paginationData}
                        pageIndex={pageIndex}
                        changePage={changePage}
                    />
                    <BookList
                        pageSize={books?.paginationData?.pageSize}
                        books={books?.books}
                    />
                </div>
            </div>
        </div >
    );
};

export default transition(PurchaseBookByFacultyId);
