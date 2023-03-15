import React, { useState } from 'react'
import MyButton from '../../UI/button/MyButton'
import MyModal from '../../UI/modal/MyModal'
import CreateUniversityForm from './CreateUniversityForm'

const CreateUniversity = ({ universities, setUniversities }) => {
    const [modalShow, setModalShow] = useState(false)

    const createUniversity = (university) => {
        setUniversities([...universities, university])
        setModalShow(false)
    }
    return (
        <div>
            <MyButton onClick={setModalShow}>
                Create university
            </MyButton>
            <MyModal show={modalShow} setShow={setModalShow}>
                <CreateUniversityForm create={createUniversity} />
            </MyModal>
        </div>
    )
}

export default CreateUniversity
