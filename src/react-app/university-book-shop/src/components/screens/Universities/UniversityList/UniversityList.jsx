// @ts-nocheck
import React from 'react';

import { CSSTransition, TransitionGroup } from 'react-transition-group';

import UniversityCard from '../UniversityCard/UniversityCard';

import styles from './UniversityList.module.css';

const UniversityList = ({ pageSize, universities, deleteUniversity }) => {
    const visibleUniversities = universities?.slice(0, pageSize);

    return (
        <TransitionGroup className={styles.universities}>
            {visibleUniversities?.map(u =>
                <CSSTransition
                    key={u.id}
                    timeout={600}
                    classNames="pagination">
                    <div className={styles.universityHidden}>
                        <div className={styles.university}>
                            <UniversityCard university={u} />
                        </div>
                    </div>
                </CSSTransition>
            )}
        </TransitionGroup>
    );
};
export default React.memo(UniversityList);