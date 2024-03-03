// @ts-nocheck
import React from 'react';

import { CSSTransition } from 'react-transition-group';
import { useState } from 'react';

import { ReactComponent as ArrowCollapse } from '../../../../Assets/arrowCollapse.svg';
import { ReactComponent as ArrowExpand } from '../../../../Assets/arrowExpand.svg';

import styles from './UniversityCard.module.css';
import UniversityCardNavBarSection from './UniversityCardNavBarSection';
import UniversityCardHeaderSection from './UniversityCardHeaderSection';
import UniversityCardFooterItem from './UniversityCardFooterItem';

const UniversityCard = ({ university }) => {
    const [errorMessage, setErrorMessage] = useState('');
    const [onMouseEntered, setOnMouseEntered] = useState(false);

    return (
        <div className={styles.inner}>
            <div className={styles.navbar}>
                <UniversityCardNavBarSection
                    universityId={university.id}
                    setErrorMessage={setErrorMessage}
                />
            </div>
            <UniversityCardHeaderSection
                id={university.id}
                name={university.name}
                description={university.description}
                errorMessage={errorMessage}
            />
            <div className={styles.footer}>
                <CSSTransition
                    in={onMouseEntered}
                    timeout={270}
                    classNames="footer"
                    mountOnEnter
                    unmountOnExit
                >
                    <div className={styles.footerInner}>
                        <ul className={styles.list}>
                            <UniversityCardFooterItem
                                label="The total cost of books purchased : "
                                value={`${university.totalBookPrice ?? 0}${university?.currencyCode?.code} `}
                            />
                            <UniversityCardFooterItem
                                label=" Number of faculties available : "
                                value={university?.facultyCount}
                            />
                            <UniversityCardFooterItem
                                label="The number of books purchased : "
                                value={university?.bookCount}
                            />
                        </ul>
                    </div>
                </CSSTransition>
                <div
                    className={styles.expandableBtn}
                    onClick={() => setOnMouseEntered(prevState => !prevState)}>
                    {onMouseEntered
                        ? <ArrowCollapse className={styles.arrow} />
                        : <ArrowExpand className={styles.arrow} />
                    }
                </div>
            </div>
        </div >
    );
};
export default React.memo(UniversityCard);