// @ts-nocheck
import React from 'react';

import FacultyHeaderSection from './FacultyHeaderSection';
import FacultyFooterItem from './FacultyFooterItem';

import styles from './FacultyCard.module.css';

const FacultyCard = ({ name, id, universityId }) => {
    return (
        <>
            <div className={styles.facultyCard}>
                <FacultyHeaderSection
                    name={name}
                    facultyId={id}
                />
                <ul className={styles.footer}>
                    <FacultyFooterItem
                        label={'Add book to faculty'}
                        facultyId={id}
                        universityId={universityId}
                    />
                    <FacultyFooterItem
                        label={'Open available books'}
                        facultyId={id}
                        universityId={universityId}
                        isExpandable={true}
                    />
                </ul>
            </div >
        </>
    );
};

export default React.memo(FacultyCard);
