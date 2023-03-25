// @ts-nocheck
import React from "react";
import UniversityItem from "./UniversityItem";
import styles from "./UniversityList.module.css"

const UniversityList = ({ universities, deleteUniversity }) => {
    return (
        <div className={styles.block}>
            <div>
                {universities.map(u =>
                    <UniversityItem key={u.id} deleteUniversity={deleteUniversity} university={u} />
                )}
            </div>
        </div>

    )
}
export default UniversityList;