// @ts-nocheck
import React from 'react';

import styles from './BookCard.module.css';

const BookPurchaseStatus = ({ purchaseStatus }) => {
    return (
        <li className={`${styles.footer} ${styles.li}`}>
            <>
                <div>
                    <strong>Book status:</strong>
                </div>
                <div>
                    <div>{purchaseStatus}</div>
                </div>
            </>
        </li>);
};

export default React.memo(BookPurchaseStatus);
