// @ts-nocheck
import React from 'react'
import FacultyCard from './FacultyCard'
import styles from './FacultyItem.module.css'
import { CSSTransition, TransitionGroup } from 'react-transition-group'

const FacultyList = ({ pageSize, faculties, setFaculties }) => {
    const visibleFaculty = faculties.slice(0, pageSize);
    const removeFaculty = (faculty) => {
        setFaculties(faculties.filter(f => f.id !== faculty.id))
    }
    return (
        <>
            {faculties.length
                ?
                <TransitionGroup className={styles.gridSites}>
                    {visibleFaculty.map(faculty =>
                        <CSSTransition
                            key={faculty.id}
                            timeout={600}
                            classNames="pagination">
                            <div className={styles.li} key={faculty.id}>
                                <FacultyCard
                                    key={faculty.id}
                                    faculty={faculty}
                                    removeFaculty={removeFaculty}
                                />
                            </div>
                        </CSSTransition>
                    )}
                </TransitionGroup>
                :
                <div>
                    Faculty not found
                </div>
            }
        </>
    )
}

export default FacultyList
