// @ts-nocheck
import React from 'react';

import MyPagination from '../../UI/pagination/MyPagination';

import styles from './ContentWithPaginationSection.module.css';

const ContentWithPaginationSection = ({ paginationData, defaultPageIndex, changePage }) => {
    return (
        <div className={styles.contentHeaderBot}>
            <div className={styles.headerBotFlexLeft}>
                <strong>{paginationData.totalCount ?? 0} </strong>
                number of books available.
            </div>
            <div className={styles.headerBotFlexRight}>
                <MyPagination
                    paginationData={paginationData}
                    pageIndex={defaultPageIndex}
                    changePage={changePage}
                    className={styles.pagination} />
            </div>
        </div>
    );
};
export default React.memo(ContentWithPaginationSection);
