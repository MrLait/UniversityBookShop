// @ts-nocheck
import React from 'react';

import styles from './BookCard.module.css';

const BookHeader = ({ name, author }) => {
    return (
        <div className={styles.header}>
            <div className={styles.headerTop}>
                <div className={styles.headerLeft}>
                    <strong>
                        {name}
                    </strong>
                </div>
                <div className={styles.headerRight}>
                </div>
            </div>
            <div className={styles.headerBot}>
                by&nbsp;
                {author} (Author)
            </div>
        </div>
    );
};

export default React.memo(BookHeader);
