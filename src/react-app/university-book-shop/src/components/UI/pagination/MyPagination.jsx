// @ts-nocheck
import React from 'react';

import { getPagesArray } from '../../../unitls/pagination';

import styles from './MyPagination.module.css';

const MyPagination = ({ paginationData, pageIndex, changePage }) => {
    const totalPages = Math.ceil(paginationData?.totalCount / paginationData?.pageSize);
    const pagesArray = getPagesArray(totalPages);
    return (
        <div className={styles.paginationWrapper}>
            {pagesArray.map
                (p =>
                    <span
                        key={p}
                        className={pageIndex === p ? `${styles.page} ${styles.pageCurrent}` : styles.page}
                        onClick={() => changePage(p)}>
                        {p}
                    </span>
                )
            }
        </div >
    );
};

export default MyPagination;
