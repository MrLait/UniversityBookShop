import React from 'react'
import FacultyItem from './FacultyItem'

const FacultyList = ({ faculties }) => {
    return (
        <div>
            {faculties.length
                ?
                <FacultyItem faculties={faculties} />
                :
                <div>
                    Faculty not found
                </div>
            }
        </div>
    )
}

export default FacultyList
