// @ts-nocheck
import React from 'react';

import { CSSTransition, TransitionGroup } from 'react-transition-group';

import BookCard from '../BookCard/BookCard';

import styles from './BookList.module.css';


const BookList = ({ pageSize, books }) => {
    const visibleBooks = books?.slice(0, pageSize);
    return (
        <>
            <TransitionGroup className={styles.gridSites}>
                {visibleBooks?.map(book =>
                    <CSSTransition
                        key={book.id}
                        timeout={600}
                        classNames="pagination">
                        <div key={book.id}>
                            <BookCard
                                book={book}
                            />
                        </div>
                    </CSSTransition>
                )}
            </TransitionGroup>
        </>
    );
};
export default BookList;