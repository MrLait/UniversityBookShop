// @ts-nocheck
import React, { useState } from 'react'
import MyButton from '../../UI/button/MyButton'
import MyModal from '../../UI/modal/MyModal'
import CreateFacultyForm from './CreateFacultyForm'

const CreateFaculty = ({ faculties, setFaculties }) => {
    const [modalShow, setModalShow] = useState(false)

    const createFaculty = (faculty) => {
        setFaculties([...faculties, faculty])
        setModalShow(false)
    }
    return (
        <>
            <MyButton onClick={setModalShow}>
                Create faculty
            </MyButton>
            <MyModal modalShow={modalShow} setModalShow={setModalShow}>
                <CreateFacultyForm modalShow={modalShow} createFaculty={createFaculty} />
            </MyModal>
        </>
    )
}

export default CreateFaculty
