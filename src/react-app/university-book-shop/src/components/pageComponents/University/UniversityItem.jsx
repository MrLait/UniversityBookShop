import React from "react";
import MyButton from "../../UI/button/MyButton";

const UniversityItem = ({ university, deleteUniversity }) => {
    return (
        <div style={{ border: '2px solid teal', padding: '15px', marginTop: '15px' }}>
            <div>
                University name: {university.name}
                <div>
                    Description: {university.description}
                </div>
                <div>
                    Total book price ToDO: 99999 currency code ToDo
                </div>
            </div>
            <div>
                <button onClick={() => deleteUniversity(university)} >delete</button>
                <MyButton onClick={university.faculties} > Vew faculties ToDo</MyButton>
                <button> Vew purchased Books ToDo</button>
            </div>
        </div>
    )
}
export default UniversityItem;