import React from 'react'
import MyButton from '../../UI/button/MyButton'

const FacultyItem = ({ faculties }) => {
    return (
        <div style={{ margin: 10, padding: 10 }}>
            {faculties.map(f =>
                <div style={{ padding: 5, border: '1px solid teal', margin: 5 }} key={f.id}>
                    <strong>
                        Faculty name:  {f.name}
                    </strong>
                    <div>
                        <MyButton disabled>Delete faculty ToDo?</MyButton>
                        <MyButton disabled>Add faculty ToDo?</MyButton>
                        <MyButton>Open purchased books</MyButton>
                    </div>
                </div>

            )}
        </div>
    )
}

export default FacultyItem
