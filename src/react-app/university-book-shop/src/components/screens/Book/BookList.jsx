// @ts-nocheck
import React from 'react';

import { CSSTransition, TransitionGroup } from 'react-transition-group';

import styles from './BookList.module.css';
import BookCard from './BookCard';

const BookList = ({ pageSize, books, buyBook, addBook, removeBook, deleteBook }) => {
    const visibleBooks = books.slice(0, pageSize);
    return (
        <>
            <TransitionGroup className={styles.gridSites}>
                {visibleBooks.map(book =>
                    <CSSTransition
                        key={book.id}
                        timeout={600}
                        classNames="pagination">
                        <div key={book.id}>
                            <BookCard
                                book={book}
                                buyBook={buyBook}
                                addBook={addBook}
                                removeBook={removeBook}
                                deleteBook={deleteBook}
                            />
                        </div>
                    </CSSTransition>
                )}
            </TransitionGroup>
        </>
    );
};
export default BookList;