// @ts-nocheck
import React from 'react';

import MyPagination from './MyPagination';
import TotalCountSection from './TotalCountSection';

import styles from './ContentWithPaginationSection.module.css';

const ContentWithPaginationSection = ({ totalCountLabel, paginationData, pageIndex, changePage }) => {
    return (
        <div className={styles.contentHeaderBot}>
            <TotalCountSection
                totalCount={paginationData?.totalCount}
                totalCountLabel={totalCountLabel}
            />
            <div className={styles.headerBotFlexRight}>
                <MyPagination
                    paginationData={paginationData}
                    pageIndex={pageIndex}
                    changePage={changePage}
                    className={styles.pagination} />
            </div>
        </div>
    );
};
export default React.memo(ContentWithPaginationSection);
