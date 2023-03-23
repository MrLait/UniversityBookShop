import React from "react";
import UniversityItem from "./UniversityItem";

const UniversityList = ({ universities, deleteUniversity }) => {
    return (
        <div>
            {universities.map(u =>
                <UniversityItem key={u.id} deleteUniversity={deleteUniversity} university={u} />
            )}
        </div>
    )
}
export default UniversityList;