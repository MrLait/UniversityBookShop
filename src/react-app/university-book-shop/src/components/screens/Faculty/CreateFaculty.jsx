// @ts-nocheck
import React, { useState } from 'react'
import MyButton from '../../UI/button/MyButton'
import MyModal from '../../UI/modal/MyModal'
import CreateFacultyForm from './CreateFacultyForm'
import styles from './CreateFaculty.module.css'

const CreateFaculty = ({ btnStyles, faculties, setFaculties }) => {
    const [modalShow, setModalShow] = useState(false)

    const createFaculty = (faculty) => {
        setFaculties([...faculties, faculty])
        setModalShow(false)
    }

    return (
        <>
            <MyButton setStyles={btnStyles} onClick={setModalShow}>
                Create faculty
            </MyButton>
            <MyModal modalShow={modalShow} setModalShow={setModalShow}>
                <CreateFacultyForm modalShow={modalShow} createFaculty={createFaculty} />
            </MyModal>
        </>
    )
}

export default CreateFaculty
