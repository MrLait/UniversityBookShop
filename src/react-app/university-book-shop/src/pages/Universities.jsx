import React from "react";
import { useEffect } from "react";
import { useState } from "react";
import UniversityApi from "../API/UniversityApiService";
import { universitiesField } from "../components/initialStates/initialStates";
import UniversityList from "../components/pageComponents/University/UniversityList";

const Universities = () => {

    const [universities, setUniversities] = useState(universitiesField)

    const getUniversities = async () => {
        const response = await UniversityApi.getAll()
        setUniversities(response.data)
    }

    const deleteUniversity = async (university) => {
        console.log(university.id);
        await UniversityApi.delete(university.id)
            .then(response => {
                console.log(response);
                if (response.status == 204) {
                    setUniversities(universities.filter(u => u.id !== university.id))
                }
            }
            ).catch(error => {
                if (error.response.data) {
                    console.log("ToDo Universities error");
                }
            })
    }

    useEffect(() => {
        getUniversities();
    }, [])

    return (
        <div>
            <div>
                <button> Create university ToDo</button>
            </div>
            <div>
                <UniversityList deleteUniversity={deleteUniversity} universities={universities} />
            </div>
        </div>
    )
}
export default Universities;