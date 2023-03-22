import React, { useState } from 'react'
import { useParams } from 'react-router-dom'
import FacultyApiService from '../../../API/FacultyApiService'
import { facultyField } from '../../constants/initialStates'
import MyButton from '../../UI/button/MyButton'

const DeleteFaculty = ({ faculty, removeFaculty }) => {

    const deleteFaculty = async () => {
        console.log(faculty.id);
        await FacultyApiService.delete(faculty.id)
            .then(response => {
                if (response.status == 204) {
                    removeFaculty(faculty)
                }
            })
    }
    return (
        <div>
            <MyButton onClick={deleteFaculty}> Delete faculty</MyButton>
        </div>
    )
}

export default DeleteFaculty
