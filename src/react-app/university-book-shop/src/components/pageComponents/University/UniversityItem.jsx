import React from "react";

const UniversityItem = ({ university }) => {
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
                <button> delete ToDo</button>
                <button> Vew faculties ToDo</button>
                <button> Vew purchased Books ToDo</button>
            </div>
        </div>
    )
}
export default UniversityItem;