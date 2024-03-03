// @ts-nocheck
import React, { useCallback, useMemo } from 'react';

import { CSSTransition, TransitionGroup } from 'react-transition-group';

import FacultyCard from '../FacultyCard/FacultyCard';

import styles from './FacultyList.module.css';

const FacultyList = ({ pageSize, faculties }) => {
    const visibleFaculty = useMemo(() => {
        return faculties?.slice(0, pageSize);
    }, [faculties, pageSize]);

    return (
        <>
            <TransitionGroup className={styles.gridSites}>
                {visibleFaculty?.map(faculty =>
                    <CSSTransition
                        key={faculty.id}
                        timeout={600}
                        classNames="pagination">
                        <div key={faculty.id}>
                            <FacultyCard
                                name={faculty.name}
                                id={faculty.id}
                                universityId={faculty.universityId}
                            />
                        </div>
                    </CSSTransition>
                )}
            </TransitionGroup>
        </>
    );
};

export default React.memo(FacultyList);
