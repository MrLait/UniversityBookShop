// @ts-nocheck
import React from 'react';

import styles from './TotalCountSection.module.css';

const TotalCountSection = ({ totalCount, totalCountLabel }) => {
    return (
        <div className={styles.headerBotFlexLeft}>
            <strong>{totalCount ?? 0} </strong>
            {totalCountLabel}
        </div>
    );
};

export default React.memo(TotalCountSection);
