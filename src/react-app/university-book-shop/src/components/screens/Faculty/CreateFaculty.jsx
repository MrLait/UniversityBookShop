// @ts-nocheck
import React, { useState } from 'react';

import MyButton from '../../UI/button/MyButton';
import MyModal from '../../UI/modal/MyModal';

import CreateFacultyForm from './CreateFacultyForm';

import styles from './CreateFaculty.module.css';

const CreateFaculty = () => {
    const [modalShow, setModalShow] = useState(false);

    return (
        <>
            <MyButton setStyles={styles.blackButton} onClick={setModalShow}>
                Create faculty
            </MyButton>
            <MyModal
                modalShow={modalShow}
                setModalShow={setModalShow}>
                <CreateFacultyForm
                    modalShow={modalShow}
                    setModalShow={setModalShow}
                />
            </MyModal>
        </>
    );
};

export default React.memo(CreateFaculty);
