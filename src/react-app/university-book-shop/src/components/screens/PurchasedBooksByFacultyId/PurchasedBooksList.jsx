// @ts-nocheck
import React from 'react';

import { CSSTransition, TransitionGroup } from 'react-transition-group';

import PurchasedBookCard from './PurchasedBookCard/PurchasedBookCard';
import styles from './PurchasedBooksList.module.css';

const PurchasedBooksList = ({ pageSize, purchasedBooks, setPurchasedBooks, setIsDeleted, isDeleted }) => {
    const visiblePurchasedBooks = purchasedBooks?.slice(0, pageSize);

    return (
        <>
            <TransitionGroup className={styles.gridSites}>
                {visiblePurchasedBooks?.map(b =>
                    <CSSTransition
                        key={b.id}
                        timeout={600}
                        classNames="pagination">
                        <div key={b.id}>
                            <PurchasedBookCard
                                isPurchased={b.isPurchased}
                                purchasedBookId={b.id}
                                book={b.book}
                            />
                        </div>
                    </CSSTransition>
                )}
            </TransitionGroup>
        </>

    );
};
export default PurchasedBooksList;