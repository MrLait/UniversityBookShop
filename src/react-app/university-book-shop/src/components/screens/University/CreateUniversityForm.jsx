import React, { useState } from 'react'
import UniversityApiService from '../../../API/UniversityApiService'
import { Currencies, universityField } from '../../constants/initialStates'
import MyButton from '../../UI/button/MyButton'
import MyInput from '../../UI/input/MyInput'

const CreateUniversityForm = ({ create }) => {
    const [university, setUniversity] = useState(universityField)
    console.log(university);
    const postUniversity = async (e) => {
        e.preventDefault()
        university.currencyCodeId = Currencies.Usd;
        await UniversityApiService.post(university)
            .then(response => {
                if (response.data && response.status == 200) {
                    const newUniversity = {
                        ...university,
                        id: response.data
                    }
                    create(newUniversity);
                    setUniversity(universityField);
                }

            }).catch(error => {
                if (error.response.data) {
                    //"ToDo Universities error"
                }
            })
    }
    return (
        <form>
            <div>
                <strong>Переделать input для description в textarea и добавить error c проверкой на длину текста;
                    увеличить длину name до 150 символов
                </strong>

            </div>
            <MyInput
                value={university.name}
                onChange={e => setUniversity({ ...university, name: e.target.value })}
                type={'text'}
                placeholder={'university name'}
            />
            <MyInput
                value={university.description}
                onChange={e => setUniversity({ ...university, description: e.target.value })}
                type={'text'}
                placeholder={'university description'}
                maxLength={250}
                style={{
                    height: '300px',
                    resize: 'vertical',
                    wordWrap: 'break-word', // Add this to allow text wrapping
                }}
            />
            <MyButton onClick={postUniversity}>Create university</MyButton>
        </form>
    );
}

export default CreateUniversityForm
