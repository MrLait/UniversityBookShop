import React from 'react'
import Book from './Book'

const PurchasedBooks = ({ purchasedBooks }) => {
    return (
        <div>
            {purchasedBooks.length
                ?
                <div>

                    {purchasedBooks[0].id != 0
                        ?
                        <div >
                            <hr />
                            <div style={{
                                display: 'flex',
                                flexWrap: 'wrap',
                                justifyContent: 'flex-start'
                            }}>

                                {purchasedBooks.map(b =>
                                    <div key={b.id}

                                        style={{ flex: '1 1' }}
                                    >
                                        <Book book={b.book} />
                                    </div>)
                                }
                            </div>


                        </div>
                        : <div />
                    }
                </div>
                :
                <div>
                    <hr />
                    There is no books
                </div>
            }
        </div >
    )
}
// .myFacultyItemWrapper {
//     display: flex;
//     flex-wrap: wrap;
//     justify-content: space-around;
//     padding: 20px;
//     flex-direction: column;
// }
export default PurchasedBooks