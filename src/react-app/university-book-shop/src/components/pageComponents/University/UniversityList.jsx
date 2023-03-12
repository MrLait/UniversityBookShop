import React from "react";
import UniversityItem from "./UniversityItem";

const UniversityList = (props) => {
    return (
        <div>
            {props.universities.map(u =>
                <UniversityItem key={u.id} university={u} />
            )}
        </div>
    )
}
export default UniversityList;