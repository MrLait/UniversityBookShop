import React, { useState } from 'react'
import { useParams } from 'react-router-dom'
import FacultyApiService from '../../../API/FacultyApiService'
import { facultyField } from '../../constants/initialStates'
import MyButton from '../../UI/button/MyButton'
import MyInput from '../../UI/input/MyInput'

const CreateFacultyForm = ({ createFaculty }) => {
    const [faculty, setFaculty] = useState(facultyField)
    const universityId = useParams().id;

    const postFaculty = async (e) => {
        e.preventDefault()
        await FacultyApiService.post({ ...faculty, universityId: universityId })
            .then(response => {
                if (response.data && response.status == 200) {
                    const newFaculty = {
                        ...faculty,
                        id: response.data
                    }
                    createFaculty(newFaculty);
                }
            })
    }
    return (
        <form>
            <MyInput
                value={faculty.name}
                onChange={e => setFaculty({ ...faculty, name: e.target.value })}
                type={'text'}
                placeholder={'faculty name'} />
            <MyButton onClick={postFaculty}> Create university</MyButton>
        </form>
    )
}

export default CreateFacultyForm
