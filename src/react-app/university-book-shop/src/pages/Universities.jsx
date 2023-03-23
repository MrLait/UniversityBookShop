import React from "react";
import { useEffect } from "react";
import { useState } from "react";
import UniversityApiService from "../API/UniversityApiService";
import { universitiesField } from "../components/constants/initialStates";
import CreateUniversity from "../components/screens/University/CreateUniversity";
import UniversityList from "../components/screens/University/UniversityList";

const Universities = () => {

    const [universities, setUniversities] = useState(universitiesField)
    useEffect(() => {
        getUniversities();
    }, [])

    const getUniversities = async () => {
        const response = await UniversityApiService.getAll()
        setUniversities(response.data)
    }

    const deleteUniversity = async (university) => {
        await UniversityApiService.delete(university.id)
            .then(response => {
                if (response.status == 204) {
                    setUniversities(universities.filter(u => u.id !== university.id))
                }
            }
            ).catch(error => {
                if (error.response.data) {
                    //"ToDo Universities error"
                }
            })
    }

    return (
        <div>
            <CreateUniversity setUniversities={setUniversities} universities={universities} />
            <UniversityList deleteUniversity={deleteUniversity} universities={universities} />
        </div >
    )
}
export default Universities;