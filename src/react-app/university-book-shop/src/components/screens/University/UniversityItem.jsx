// @ts-nocheck
import React from "react";
import { useNavigate } from "react-router-dom";
import { routePathsNavigate } from "../../../router/routes";
import MyButton from "../../UI/button/MyButton";
import UniversityDescription from "./UniversityDescription";
import styles from "./UniversityItem.module.css";

const UniversityItem = ({ university, deleteUniversity }) => {
    const navigate = useNavigate();
    return (
        <div className={styles.inner}>
            <UniversityDescription university={university} />
            <div>
                <MyButton onClick={() => deleteUniversity(university)} >
                    Delete university
                </MyButton>
                <MyButton onClick={() => navigate(routePathsNavigate.UniversityId(university.id), { state: { university } })} >
                    Open faculties
                </MyButton>
            </div>
        </div>

    )
}
export default UniversityItem;