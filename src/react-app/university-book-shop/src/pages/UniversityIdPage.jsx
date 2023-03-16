import React from 'react'
import { useLocation } from 'react-router';
import FacultyList from '../components/screens/Faculty/FacultyList';
import UniversityDescription from '../components/screens/University/UniversityDescription';

const UniversityIdPage = () => {

    const state = useLocation().state
    console.log(state);
    return (
        <div >
            {state
                ?
                <div>
                    <div style={{ border: '2px solid teal', padding: '15px', marginTop: '15px' }}>
                        <UniversityDescription university={state.university} />
                    </div>
                    <FacultyList faculties={state.university.faculties} />
                </div>
                :
                <div> University not found</div>
            }

        </div >
    )
}

export default UniversityIdPage
