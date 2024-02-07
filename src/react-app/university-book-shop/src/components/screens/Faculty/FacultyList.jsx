// @ts-nocheck
import React from 'react'
import CreateFaculty from './CreateFaculty'
import FacultyCard from './FacultyCard'
import styles from './FacultyItem.module.css'

const FacultyList = ({ faculties, setFaculties }) => {
    const removeFaculty = (faculty) => {
        setFaculties(faculties.filter(f => f.id !== faculty.id))
    }
    return (
        <>
            {faculties.length
                ?
                <ul className={styles.gridSites}>
                    {faculties.map(faculty =>
                        <li className={styles.li} key={faculty.id}>
                            <FacultyCard
                                key={faculty.id}
                                faculty={faculty}
                                removeFaculty={removeFaculty}
                            />
                        </li>
                    )}
                </ul>
                :
                <div>
                    <div>
                        Faculty not found
                    </div>

                </div>
            }
            <CreateFaculty
                faculties={faculties}
                setFaculties={setFaculties}
            />
        </>
    )
}

export default FacultyList
