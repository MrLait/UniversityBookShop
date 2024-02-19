// @ts-nocheck
import React from 'react';

import { CSSTransition, TransitionGroup } from 'react-transition-group';

import { decrementPaginationTotalCount } from '../../../unitls/pagination';

import PurchasedBookCard from './PurchasedBookCard';
import styles from './PurchasedBooksList.module.css';

const PurchasedBooksList = ({ pageSize, setPaginationData, purchasedBooks, setPurchasedBooks, setIsDeleted, isDeleted }) => {
    const visiblePurchasedBooks = purchasedBooks.slice(0, pageSize);
    const deleteBook = (id) => {
        setPurchasedBooks(
            purchasedBooks.filter(p => p.id !== id)
        );
        decrementPaginationTotalCount(setPaginationData);
        setIsDeleted(!isDeleted);
    };

    const updateErrorMessage = (id, errorMessage) => {
        const updatePurchasedBooks = purchasedBooks.map(pb => {
            if (pb.id === id)
                return {
                    ...pb,
                    book: {
                        ...pb.book,
                        errorMessage,
                    },
                };
            return pb;
        });
        setPurchasedBooks(updatePurchasedBooks);
    };
    return (
        <>
            {purchasedBooks.length
                ?
                <TransitionGroup className={styles.gridSites}>
                    {visiblePurchasedBooks.map(b =>
                        <CSSTransition
                            key={b.id}
                            timeout={600}
                            classNames="pagination">
                            <div key={b.id}>
                                <PurchasedBookCard
                                    isPurchased={b.isPurchased}
                                    purchasedBookId={b.id}
                                    book={b.book}
                                    deleteBook={deleteBook}
                                    updateErrorMessage={updateErrorMessage}
                                />
                            </div>
                        </CSSTransition>
                    )}
                </TransitionGroup>
                :
                <div>
                    <hr />
                    There are no books
                </div>
            }
        </>

    );
};
export default PurchasedBooksList;