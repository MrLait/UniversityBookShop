import React from "react";
import UniversityItem from "./UniversityItem";

const UniversityList = (props) => {
    return (
        <div>
            {props.universities.map(u =>
                <UniversityItem key={u.id} deleteUniversity={props.deleteUniversity} university={u} />
            )}
        </div>
    )
}
export default UniversityList;