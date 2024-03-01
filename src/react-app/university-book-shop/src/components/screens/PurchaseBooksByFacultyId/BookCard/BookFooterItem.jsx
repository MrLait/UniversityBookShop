// @ts-nocheck
import React from 'react';

import styles from './BookCard.module.css';

const BookFooterItem = ({ label, value }) => {
    return (
        <li className={`${styles.footer} ${styles.li}`}>
            <div>
                <strong>{label}:</strong>
            </div>
            <div>
                {value}
            </div>
        </li>);
};

export default React.memo(BookFooterItem);
