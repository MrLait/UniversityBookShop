// @ts-nocheck
import React from 'react'
import MyButton from '../../UI/button/MyButton'
import FacultyCard from './FacultyCard'
import styles from './FacultyItem.module.css'

const FacultyItem = ({ faculties }) => {
    return (
        <div >
            <div>
                <MyButton disabled>
                    Add faculty ToDo?
                </MyButton>
            </div>
            <div className={styles.myFacultyItemWrapper}>
                {faculties.map(faculty =>
                    <FacultyCard faculty={faculty} key={faculty.id} />
                )}
            </div>
        </div>
    )
}
export default FacultyItem
