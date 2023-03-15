import React from 'react'
import { useLocation, useParams } from 'react-router';

const UniversityIdPage = () => {

    const state = useLocation().state
    const universityId = useParams();
    console.log(state);
    return (
        <div >
            {state
                ?
                <div>
                    <div style={{ border: '2px solid teal', padding: '15px', marginTop: '15px' }}>
                        <strong>
                            University name: {state.university.name}
                        </strong>
                        <div>
                            Description: {state.university.description}
                        </div>
                        <div>
                            Total book price ToDO: 99999 currency code ToDo
                        </div>
                    </div>
                    <div>
                        {state.university.faculties.length
                            ?
                            <div>
                                {state.university.faculties.map(f =>
                                    <div key={f.id}>
                                        Faculty name:  {f.name}
                                    </div>
                                )}
                            </div>
                            :
                            <div>
                                Faculty not found
                            </div>
                        }
                    </div>
                </div>
                :
                <div> University not found</div>
            }

        </div >
    )
}

export default UniversityIdPage
