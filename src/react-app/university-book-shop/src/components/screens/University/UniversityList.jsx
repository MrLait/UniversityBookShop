// @ts-nocheck
import React from "react";
import UniversityItem from "./UniversityItem";
import styles from "./UniversityList.module.css"
import { CSSTransition, SwitchTransition, Transition } from 'react-transition-group'
import { TransitionGroup } from "react-transition-group";
const UniversityList = ({ universities, deleteUniversity }) => {
    return (
        <>
            <TransitionGroup className={styles.universities}>
                {universities.map(u =>
                    <CSSTransition
                        key={u.id}
                        timeout={500}
                        classNames="university"
                    >
                        <div>
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