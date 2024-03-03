// @ts-nocheck
import React, { useState } from 'react';

import MyButton from '../../../UI/button/MyButton';
import MyModal from '../../../UI/modal/MyModal';

import CreateUniversityForm from './CreateUniversityForm';

const CreateUniversity = () => {
    const [modalShow, setModalShow] = useState(false);

    return (
        < >
            <MyButton onClick={setModalShow}>
                Create University
            </MyButton>
            <MyModal modalShow={modalShow} setModalShow={setModalShow}>
                <CreateUniversityForm
                    modalShow={modalShow}
                    setModalShow={setModalShow}
                />
            </MyModal>
        </>
    );
};

export default React.memo(CreateUniversity);


