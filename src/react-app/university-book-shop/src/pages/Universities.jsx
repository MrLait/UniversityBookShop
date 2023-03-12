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

    useEffect(() => {
        getUniversities();
    }, [])

    return (
        <div>
            <div>
                <button> Create university ToDo</button>
            </div>
            <div>
                <UniversityList universities={universities} />
            </div>
        </div>
    )
}
export default Universities;