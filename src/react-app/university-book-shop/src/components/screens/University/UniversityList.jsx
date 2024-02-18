// @ts-nocheck
import React from "react";
import UniversityItem from "./UniversityItem";
import styles from "./UniversityList.module.css"
import { CSSTransition, TransitionGroup } from 'react-transition-group'
const UniversityList = ({ pageSize, universities, deleteUniversity }) => {
    const visibleUniversities = universities.slice(0, pageSize);
    return (
        <>
            <TransitionGroup className={styles.universities}>
                {visibleUniversities.map(u =>
                    <CSSTransition
                        key={u.id}
                        timeout={600}
                        classNames="pagination">
                        <div className={styles.universityHidden}>
                            <div className={styles.university}>
                                <UniversityItem deleteUniversity={deleteUniversity} university={u} />
                            </div>
                        </div>
                    </CSSTransition>
                )}
            </TransitionGroup>
        </>
    )
}
export default UniversityList;