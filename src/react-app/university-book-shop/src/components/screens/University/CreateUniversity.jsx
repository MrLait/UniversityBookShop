// @ts-nocheck
import React, { useState } from 'react';

import MyButton from '../../UI/button/MyButton';
import MyModal from '../../UI/modal/MyModal';

import { incrementPaginationTotalCount } from '../../../unitls/pagination';

import CreateUniversityForm from './CreateUniversityForm';

const CreateUniversity = ({ setPaginationData, universities, setUniversities }) => {
    const [modalShow, setModalShow] = useState(false);

    const createUniversity = (university) => {
        setUniversities([...universities, university]);
        setModalShow(false);
        incrementPaginationTotalCount(setPaginationData);
    };
    return (
        < >
            <MyButton onClick={setModalShow}>
                Create University
            </MyButton>
            <MyModal modalShow={modalShow} setModalShow={setModalShow}>
                <CreateUniversityForm modalShow={modalShow} create={createUniversity} />
            </MyModal>
        </>
    );
};

export default CreateUniversity;


