// @ts-nocheck
import React from 'react'
import FacultyCard from './FacultyCard'
import styles from './FacultyItem.module.css'
import { CSSTransition, TransitionGroup } from 'react-transition-group'
import { decrementPaginationTotalCount } from '../../../unitls/pagination'

const FacultyList = ({ pageSize, setPaginationData, setIsDeleted, isDeleted, faculties, setFaculties }) => {
    const visibleFaculty = faculties.slice(0, pageSize);
    const removeFaculty = (faculty) => {
        setFaculties(faculties.filter(f => f.id !== faculty.id))
        decrementPaginationTotalCount(setPaginationData);
        setIsDeleted(!isDeleted);
    }

    const updateFaculty = (updatedFaculty) => {
        const index = faculties.findIndex(faculty => faculty.id === updatedFaculty.id);
        faculties[index] = updatedFaculty;
        setFaculties([...faculties])
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
                            <div key={faculty.id}>
                                <FacultyCard
                                    faculty={faculty}
                                    removeFaculty={removeFaculty}
                                    updateFaculty={updateFaculty}
                                />
                            </div>
                        </CSSTransition>
                    )}
                </TransitionGroup>
                :
                <div>
                    There are no facilities
                </div>
            }
        </>
    )
}

export default FacultyList
