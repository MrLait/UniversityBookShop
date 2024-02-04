// @ts-nocheck
import React, { useEffect, useState } from 'react'
import { useLocation } from 'react-router';
import FacultyApiService from '../API/FacultyApiService';
import UniversityApiService from '../API/UniversityApiService';
import { facultyField, universityField } from '../components/constants/initialStates';
import FacultyList from '../components/screens/Faculty/FacultyList';
import UniversityDescription from '../components/screens/University/UniversityDescription';

const UniversityIdPage = () => {
    const state = useLocation().state
    const [faculties, setFaculties] = useState(state.university.faculties)

    const getFacultiesByUniversityId = async (universityId) => {
        const response = await FacultyApiService.getByUniversityId(universityId);
        setFaculties(response.data);
    }

    useEffect(() => {
        getFacultiesByUniversityId(state.university.id)
    }, [])

    return (
        <div >
            {state
                ?
                <div>
                    <div style={{ border: '2px solid teal', padding: '15px', marginTop: '15px', borderRadius: "16px" }}>
                        <strong>
                            University name: {state.university.name}
                        </strong>
                        <div>
                            Description: {state.university.description}
                        </div>
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
