// @ts-nocheck
import React from 'react';

import { CSSTransition, TransitionGroup } from 'react-transition-group';

import PurchasedBookCard from '../PurchasedBookCard/PurchasedBookCard';

import styles from './PurchasedBooksList.module.css';

const PurchasedBooksList = ({ pageSize, availableBooks }) => {
    const visibleAvailableBooks = availableBooks?.slice(0, pageSize);

    return (
        <>
            <TransitionGroup className={styles.gridSites}>
                {visibleAvailableBooks?.map(b =>
                    <CSSTransition
                        key={b.id}
                        timeout={600}
                        classNames="pagination">
                        <div key={b.id}>
                            <PurchasedBookCard
                                isPurchased={b.isPurchased}
                                availableBookId={b.id}
                                book={b.book}
                            />
                        </div>
                    </CSSTransition>
                )}
            </TransitionGroup>
        </>

    );
};
export default React.memo(PurchasedBooksList);