// @ts-nocheck
import React, { useCallback, useState } from 'react';
import { useParams, useSearchParams, useNavigate } from 'react-router-dom';

import BookList from '../../components/screens/PurchasedBooksByFacultyId/BookList/BookList';
import { useGetBooksWithPurchaseStatusByFacultyIdQuery } from '../../components/hooks/bookPurchaseActionsHooks';

import transition from '../../unitls/transition';
import { routePathsNavigate } from '../../router/routes';

import PurchaseBookHeaderSection from '../../components/screens/PurchasedBooksByFacultyId/PurchaseBookHeaderSection';
import ContentWithPaginationSection from '../../components/screens/PurchasedBooksByFacultyId/ContentWithPaginationSection';

import styles from './PurchaseBookByFacultyId.module.css';

const PurchaseBookByFacultyId = () => {
    const [searchParams] = useSearchParams();
    const navigate = useNavigate();
    const [pageIndex, setPageIndex] = useState(parseInt(searchParams.get('page') || 1));
    const pageSize = 4;
    const facultyId = parseInt(useParams().facultyId || 0);

    const { data: books } = useGetBooksWithPurchaseStatusByFacultyIdQuery(facultyId, pageIndex, pageSize);

    const changePage = useCallback((pageIndex) => {
        navigate(routePathsNavigate.SearchBookByFacultyIdPage(facultyId, pageIndex));
        setPageIndex(pageIndex);
    }, [facultyId, navigate]);

    return (
        <div className={styles.block}>
            <div className={styles.inner}>
                <PurchaseBookHeaderSection />
                <div className={styles.contentBody}>
                    <ContentWithPaginationSection
                        paginationData={books?.paginationData}
                        defaultPageIndex={pageIndex}
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
