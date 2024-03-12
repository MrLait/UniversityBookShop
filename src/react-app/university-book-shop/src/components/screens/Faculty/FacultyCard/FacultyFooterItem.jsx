// @ts-nocheck
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

import { routePathsNavigate } from '../../../../router/routes';
import ArrowDirectionLeftIcon from '../../../../Assets/ArrowDirectionLeftIcon';
import ArrowExpandIcon from '../../../../Assets/ArrowExpandIcon';
import { useGetPaginatedAvailableBooksByFacultyIdQuery } from '../../../hooks/booksAvailableForFacultyHooks';

import styles from './FacultyCard.module.css';

const FacultyFooterItem = ({ label, facultyId, universityId, isExpandable }) => {
    const navigate = useNavigate();
    const { refetch } = useGetPaginatedAvailableBooksByFacultyIdQuery(facultyId, 1, 4);
    const [isExpandVisible, setIsExpandVisible] = useState(false);

    const togglePurchasedBooksVisibility = async (universityId, facultyId) => {
        if (!isExpandVisible) {
            const { data } = await refetch();
            if (data?.validationIsSucceeded) {
                navigate(routePathsNavigate.PurchasedBooksByFacultyId(universityId, facultyId));
            } else {
                setIsExpandVisible(true);
                return;
            }
        }

        setIsExpandVisible(false);
    };


    return (
        <>
            <li className={`${styles.footer} ${styles.li}`}>
                <div>
                    <strong>{label}</strong>
                </div>
                {!isExpandable &&
                    <div className={styles.rolloverArrowDirectionLeft}
                        onClick={() => navigate(routePathsNavigate.SearchBookByFacultyId(facultyId),
                            { state: { universityId: universityId } })}
                    >
                        <ArrowDirectionLeftIcon
                            className={styles.arrowDirectionLeft}
                        />
                    </div>
                }
                {isExpandable &&
                    <div
                        className={styles.rolloverArrowDirectionLeft}
                        onClick={() => togglePurchasedBooksVisibility(universityId, facultyId)}
                    >
                        {isExpandVisible
                            ?
                            <ArrowExpandIcon />
                            :
                            <ArrowDirectionLeftIcon className={styles.arrowDirectionLeft} />
                        }
                    </div>
                }
            </li>
            {(isExpandVisible && isExpandable) ?
                <li className={`${styles.footer} ${styles.li} ${styles.errorMessage}`}>
                    <strong>There are no available books</strong>
                </li>
                : ''
            }
        </>
    );
};

export default React.memo(FacultyFooterItem);
