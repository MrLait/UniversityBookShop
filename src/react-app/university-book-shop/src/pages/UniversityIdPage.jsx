import React, { useEffect, useState } from 'react'
import { useLocation } from 'react-router';
import FacultyApiService from '../API/FacultyApiService';
import UniversityApiService from '../API/UniversityApiService';
import { facultyField, universityField } from '../components/constants/initialStates';
import FacultyList from '../components/screens/Faculty/FacultyList';
import UniversityDescription from '../components/screens/University/UniversityDescription';

const UniversityIdPage = () => {
    const state = useLocation().state
    //const [university, setUniversity] = useState(universityField)
    const [faculties, setFaculties] = useState(state.university.faculties)

    // const getGaulties = async() ={
    //     const response = await FacultyApiService.
    // }
    // const getUniversityById = async () => {
    //     const response = await UniversityApiService.getByUniversityId(state.university.id);
    //     setUniversity(response.data);
    //     setFaculties(response.data.faculties)
    // }

    // useEffect(() => {
    //     getUniversityById()
    // }, [])

    return (
        <div >
            {state
                ?
                <div>
                    <h1>getByFacultyId</h1>
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
