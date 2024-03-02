// @ts-nocheck
import React, { useState } from 'react';

import styles from './BookCard.module.css';

import DeleteBook from './DeleteBook';
const BookHeader = ({ name, author, isDeleteVisible, bookId }) => {
    const [errorMessage, setErrorMessage] = useState('');
    return (
        <div className={styles.header}>
            <div className={styles.headerTop}>
                <div className={styles.headerLeft}>
                    <strong>
                        {name}
                    </strong>
                </div>
                <div className={styles.headerRight}>
                    {isDeleteVisible &&
                        <DeleteBook
                            bookId={bookId}
                            setErrorMessage={setErrorMessage}
                        />
                    }
                </div>
            </div>
            <div className={styles.headerBot}>
                by&nbsp;
                {author} (Author)
            </div>
            {isDeleteVisible && errorMessage &&
                <div className={styles.errorMessage}>
                    {errorMessage}
                </div>
            }
        </div>
    );
};

export default React.memo(BookHeader);
