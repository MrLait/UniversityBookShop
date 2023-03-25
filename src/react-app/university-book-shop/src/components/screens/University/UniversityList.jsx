// @ts-nocheck
import React from "react";
import UniversityItem from "./UniversityItem";
import styles from "./UniversityList.module.css"

const UniversityList = ({ universities, deleteUniversity }) => {
    return (
        <>
            {universities.map(u =>
                <div className={styles.university}>
                    <UniversityItem key={u.id} deleteUniversity={deleteUniversity} university={u} />
                </div>
            )}
        </>

    )
}
export default UniversityList;