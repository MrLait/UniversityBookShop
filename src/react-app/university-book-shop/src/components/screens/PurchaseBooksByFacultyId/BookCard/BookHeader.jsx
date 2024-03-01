// @ts-nocheck
import React from 'react';

import styles from './BookCard.module.css';

import DeleteBook from './DeleteBook';
const BookHeader = ({ name, author, isDelete, deleteBook, bookId, errorMessage }) => {
    return (
        <div className={styles.header}>
            <div className={styles.headerTop}>
                <div className={styles.headerLeft}>
                    <strong>
                        {name}
                    </strong>
                </div>
                <div className={styles.headerRight}>
                    {isDelete &&
                        <DeleteBook
                            bookId={bookId}
                            deleteBook={deleteBook}
                        />
                    }
                </div>
            </div>
            <div className={styles.headerBot}>
                by&nbsp;
                {author} (Author)
            </div>
            {isDelete && errorMessage &&
                <div className={styles.errorMessage}>
                    {errorMessage}
                </div>
            }
        </div>
    );
};

export default React.memo(BookHeader);
