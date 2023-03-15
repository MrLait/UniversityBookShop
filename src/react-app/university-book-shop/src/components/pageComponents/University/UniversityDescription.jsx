import React from 'react'

const UniversityDescription = ({ university }) => {
    return (
        <div>
            <strong>
                University name: {university.name}
            </strong>
            <div>
                Description: {university.description}
            </div>
            <div>
                Total book price ToDO: 99999 currency code ToDo
            </div>
        </div>
    )
}

export default UniversityDescription
