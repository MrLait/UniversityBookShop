import React from "react";
import { useNavigate } from "react-router-dom";
import { routePathsNavigate } from "../../../router/routes";
import MyButton from "../../UI/button/MyButton";
import UniversityDescription from "./UniversityDescription";

const UniversityItem = ({ university, deleteUniversity }) => {
    const navigate = useNavigate();
    return (
        <div style={{ border: '2px solid teal', padding: '15px', marginTop: '15px' }}>
            <UniversityDescription university={university} />
            <div>
                <button onClick={() => deleteUniversity(university)} >
                    Delete university
                </button>
                <MyButton onClick={() => navigate(routePathsNavigate.UniversityId(university.id,), { state: { university } })} >
                    Open faculties
                </MyButton>
                <button disabled>
                    Vew purchased Books ToDo
                </button>
            </div>
        </div>
    )
}
export default UniversityItem;