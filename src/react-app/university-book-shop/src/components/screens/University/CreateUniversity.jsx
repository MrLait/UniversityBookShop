// @ts-nocheck
import React, { useState } from 'react'
import MyButton from '../../UI/button/MyButton'
import MyModal from '../../UI/modal/MyModal'
import CreateUniversityForm from './CreateUniversityForm'
import { incrementPaginationTotalCount } from '../../../unitls/pagination'

const CreateUniversity = ({ paginationData, setPaginationData, universities, setUniversities }) => {
    const [modalShow, setModalShow] = useState(false)

    const createUniversity = (university) => {
        setUniversities([...universities, university])
        setModalShow(false)
        incrementPaginationTotalCount(setPaginationData)
    }
    return (
        < >
            <MyButton onClick={setModalShow}>
                Create University
            </MyButton>
            <MyModal modalShow={modalShow} setModalShow={setModalShow}>
                <CreateUniversityForm modalShow={modalShow} create={createUniversity} />
            </MyModal>
        </>
    )
}

export default CreateUniversity


