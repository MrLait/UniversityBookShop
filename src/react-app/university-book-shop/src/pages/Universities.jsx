import React from "react";
import { useEffect } from "react";
import { useState } from "react";
import UniversityApiService from "../API/UniversityApiService";
import { paginationField, paginationHeader, universitiesField } from "../components/constants/initialStates";
import CreateUniversity from "../components/screens/University/CreateUniversity";
import UniversityList from "../components/screens/University/UniversityList";
import MyPagination from "../components/UI/pagination/MyPagination";
import { getPagesArray } from "../unitls/pagination";

const Universities = () => {
    const [universities, setUniversities] = useState([])
    const [paginationData, setPaginationData] = useState(paginationField);
    const [pageSize, setPageSize] = useState(3);
    const [pageIndex, setPageIndex] = useState(1);

    useEffect(() => {
        getPaginatedUniversities(pageIndex, pageSize);
    }, [])

    const getPaginatedUniversities = async (pageIndex, pageSize) => {
        await UniversityApiService.getAllWithPagination(pageIndex, pageSize)
            .then((response) => {
                setUniversities(response.data)
                setPaginationData(JSON.parse(response.headers[paginationHeader]));
            })
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
    const changePage = (pageIndex) => {
        setPageIndex(pageIndex)
        getPaginatedUniversities(pageIndex, pageSize);
    }

    return (
        <div>
            <CreateUniversity setUniversities={setUniversities} universities={universities} />
            {universities.length === 0 ? <p>No universities found.</p> :
                <>
                    <UniversityList deleteUniversity={deleteUniversity} universities={universities} />
                    <MyPagination
                        paginationData={paginationData}
                        pageIndex={pageIndex}
                        changePage={changePage}
                    />
                </>
            }
        </div>
    );
}
export default Universities;