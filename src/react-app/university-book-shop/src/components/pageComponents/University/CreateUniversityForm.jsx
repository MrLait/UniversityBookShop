import React, { useState } from 'react'
import UniversityApi from '../../../API/UniversityApiService'
import { Currencies, universityField } from '../../initialStates/initialStates'
import MyButton from '../../UI/button/MyButton'
import MyInput from '../../UI/input/MyInput'

const CreateUniversityForm = ({ create }) => {
    const [university, setUniversity] = useState(universityField)

    const postUniversity = async (e) => {
        e.preventDefault()
        console.log("response");
        university.currencyCodeId = Currencies.Usd;

        await UniversityApi.post(university)
            .then(response => {
                if (response.data && response.status == 200) {

                    const newUniversity = {
                        ...university,
                        id: response.data
                    }
                    create(newUniversity);
                }

            }).catch(error => {
                if (error.response.data) {
                    //"ToDo Universities error"
                }
            })
    }
    return (
        <form>
            <MyInput
                value={university.name}
                onChange={e => setUniversity({ ...university, name: e.target.value })}
                type={'text'}
                placeholder={'university name'} />
            <MyInput
                value={university.description}
                onChange={e => setUniversity({ ...university, description: e.target.value })}
                type={'text'}
                placeholder={'university description'} />
            <MyButton onClick={postUniversity}> Create university</MyButton>
        </form>
    )
}

export default CreateUniversityForm
