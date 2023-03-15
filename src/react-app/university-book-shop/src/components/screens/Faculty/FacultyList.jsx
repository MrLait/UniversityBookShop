import React from 'react'
import MyButton from '../../UI/button/MyButton'
import FacultyItem from './FacultyItem'

const FacultyList = ({ faculties }) => {
    return (
        <div>
            {faculties.length
                ?
                <FacultyItem faculties={faculties} />
                :
                <div>
                    <div>
                        Faculty not found
                    </div>
                    <div>
                        <MyButton disabled>Add faculty ToDo?</MyButton>
                    </div>
                </div>
            }
        </div>
    )
}

export default FacultyList
