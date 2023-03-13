import React from "react";
import { useEffect } from "react";
import { useState } from "react";
import UniversityApi from "../API/UniversityApiService";
import { Currencies, universitiesField, universityField } from "../components/initialStates/initialStates";
import CreateUniversityForm from "../components/pageComponents/University/CreateUniversityForm";
import UniversityList from "../components/pageComponents/University/UniversityList";

const Universities = () => {

    const [universities, setUniversities] = useState(universitiesField)
    const [universityModal, setUniversityModal] = useState(false);

    useEffect(() => {
        getUniversities();
    }, [])

    const getUniversities = async () => {
        const response = await UniversityApi.getAll()
        setUniversities(response.data)
    }

    const deleteUniversity = async (university) => {
        await UniversityApi.delete(university.id)
            .then(response => {
                console.log(response);
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
    const createUniversity = (university) => {
        setUniversities([...universities, university])
    }


    return (
        <div>
            <CreateUniversityForm create={createUniversity} />
            <div>
                <UniversityList deleteUniversity={deleteUniversity} universities={universities} />
            </div>
        </div >
    )
}
export default Universities;