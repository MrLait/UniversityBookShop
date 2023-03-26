// @ts-nocheck
import React from "react";
import { useNavigate } from "react-router-dom";
import { routePathsNavigate } from "../../../router/routes";
import MyButton from "../../UI/button/MyButton";
import UniversityDescription from "./UniversityDescription";
import styles from "./UniversityItem.module.css";
import { ReactComponent as OkLogo } from '../../../Assets/okSvg.svg';
import { CSSTransition, SwitchTransition, Transition } from 'react-transition-group'
import { useState } from "react";
const UniversityItem = ({ university, deleteUniversity }) => {
    const navigate = useNavigate();
    const [onMouseEntered, setOnMouseEntered] = useState(false);
    console.log(onMouseEntered);
    return (
        <div
            className={styles.inner}
            onMouseEnter={() => setOnMouseEntered(true)}
            onMouseLeave={() => setOnMouseEntered(false)}
        >
            <div className={styles.header}>
                <div className={styles.title}>{university.name}</div>
                <div className={styles.description}>{university.description}</div>
            </div>
            <CSSTransition
                in={onMouseEntered}
                timeout={1000}
                classNames="footer"
                mountOnEnter
                unmountOnExit
            >
                <div className={styles.footer}>
                    <ul className={styles.list}>
                        <li>
                            <OkLogo className={styles.okLogo} />
                            The total cost of books purchased : {university.totalBookPrice} {university.currencyCode.code}
                        </li>
                        <li> <OkLogo className={styles.okLogo} />
                            Number of faculties available : {university.facultyCount}</li>
                        <li> <OkLogo className={styles.okLogo} />
                            The number of books purchased : {university.bookCount}</li>
                    </ul>
                </div>
            </CSSTransition>

            <MyButton onClick={() => deleteUniversity(university)} >
                Delete university
            </MyButton>
            <MyButton onClick={() => navigate(routePathsNavigate.UniversityId(university.id), { state: { university } })} >
                Open faculties
            </MyButton>



        </div>

    )
}
export default UniversityItem;