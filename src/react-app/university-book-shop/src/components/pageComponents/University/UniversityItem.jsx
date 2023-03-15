import React from "react";
import { useNavigate } from "react-router-dom";
import { routePaths, routePathsNavigate } from "../../../router/routes";
import MyButton from "../../UI/button/MyButton";

const UniversityItem = ({ university, deleteUniversity }) => {
    const navigate = useNavigate();
    return (
        <div style={{ border: '2px solid teal', padding: '15px', marginTop: '15px' }}>
            <div>
                <strong>
                    University name: {university.name}
                </strong>
                <div>
                    Description: {university.description}
                </div>
                <div>
                    Total book price ToDO: 99999 currency code ToDo
                </div>
            </div>
            <div>
                <button onClick={() => deleteUniversity(university)} >delete</button>
                <MyButton onClick={() => navigate(routePathsNavigate.UniversityId(university.id,), { state: { university } })} >
                    Open
                </MyButton>
                <button> Vew purchased Books ToDo</button>
            </div>
        </div>
    )
}
export default UniversityItem;