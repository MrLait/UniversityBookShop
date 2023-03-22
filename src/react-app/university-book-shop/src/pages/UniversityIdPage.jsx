import React, { useState } from 'react'
import { useLocation } from 'react-router';
import FacultyList from '../components/screens/Faculty/FacultyList';
import UniversityDescription from '../components/screens/University/UniversityDescription';

const UniversityIdPage = () => {
    const state = useLocation().state
    const [faculties, setFaculties] = useState(state.university.faculties)

    return (
        <div >
            {state
                ?
                <div>
                    <div style={{ border: '2px solid teal', padding: '15px', marginTop: '15px', borderRadius: "16px" }}>
                        To Do GetUniversityById state
                        <UniversityDescription university={state.university} />
                    </div>
                    <FacultyList
                        faculties={faculties}
                        setFaculties={setFaculties}
                    />
                </div>
                :
                <div> University not found</div>
            }

        </div >
    )
}

export default UniversityIdPage
