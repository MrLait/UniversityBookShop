// @ts-nocheck
import React from 'react';
import { useNavigate } from 'react-router-dom';

import { CSSTransition } from 'react-transition-group';

import { useState } from 'react';

import { routePathsNavigate } from '../../../router/routes';

import OkLogoItem from '../../../Assets/OkLogoItem';
import { ReactComponent as OkLogo } from '../../../Assets/okSvg.svg';
import { ReactComponent as GoTo } from '../../../Assets/goTo.svg';
import { ReactComponent as ArrowCollapse } from '../../../Assets/arrowCollapse.svg';
import { ReactComponent as ArrowExpand } from '../../../Assets/arrowExpand.svg';

import styles from './UniversityItem.module.css';

const UniversityItem = ({ university, deleteUniversity }) => {
    const navigate = useNavigate();
    const [onMouseEntered, setOnMouseEntered] = useState(false);
    return (
        <div className={styles.inner}>
            <div className={styles.navbar}>
                <div className={styles.navbarInner}>
                    <a
                        className={styles.rolloverGoTo}
                        onClick={() => navigate(routePathsNavigate.UniversityId(university.id), { state: { university } })}
                    >
                        <GoTo className={styles.goTo} />
                    </a>
                    <span className={styles.remove}
                        onClick={() => deleteUniversity(university)} >
                        X
                    </span>
                </div>
            </div>
            <div className={styles.header}>
                <div
                    className={styles.title}
                    onClick={() => navigate(routePathsNavigate.UniversityId(university.id), { state: { university } })}
                >
                    {university.name}</div>
                <div className={styles.description}>{university.description}</div>
                {university.errorMessage &&
                    <div className={styles.errorMessage}>{university.errorMessage}
                    </div>
                }
            </div>
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
                            <li>
                                <OkLogoItem className={styles.okLogo} />
                                The total cost of books purchased : {university.totalBookPrice ?? 0}{university.currencyCode.code}
                            </li>
                            <li> <OkLogoItem className={styles.okLogo} />
                                Number of faculties available : {university.facultyCount}</li>
                            <li> <OkLogoItem className={styles.okLogo} />
                                The number of books purchased : {university.bookCount}</li>
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
export default UniversityItem;