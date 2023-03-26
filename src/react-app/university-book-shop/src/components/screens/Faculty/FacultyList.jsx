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
        <div>
            {faculties.length
                ?
                <div className={styles.myFacultyItemWrapper}>
                    {faculties.map(faculty =>
                        <FacultyCard
                            key={faculty.id}
                            faculty={faculty}
                            removeFaculty={removeFaculty}
                        />
                    )}
                </div>
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
        </div>
    )
}

export default FacultyList
