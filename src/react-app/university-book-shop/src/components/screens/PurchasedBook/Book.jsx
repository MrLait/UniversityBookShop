import React from 'react'
import MyButton from '../../UI/button/MyButton';

const Book = ({ book }) => {
    return (
        <div style={{
            border: '2px solid teal',
            padding: '15px',
            marginTop: '15px',
            borderRadius: "16px",
            width: '280px'
        }}>
            <div>
                <h1>
                    {book.name}
                </h1>
            </div>
            <div>
                by&nbsp;
                <span>{book.author} (Author)</span>
            </div>
            <div>
                <hr />
                <div style={{ textAlign: 'right' }}>
                    <div style={{ marginRight: '10px' }}>
                        Price : {book.price} {book.currencyCode.code}
                    </div>
                    <div style={{ marginRight: '10px' }}>
                        <MyButton>Delete book</MyButton>
                    </div>
                </div>

            </div>
            <div>
                <hr />
                Product details :
                <div>
                    <ul>
                        <table>
                            <tbody>
                                <tr>
                                    <td>Name :&nbsp;&nbsp;</td>
                                    <td>{book.name}</td>
                                </tr>
                                <tr>
                                    <td>Author :&nbsp;&nbsp;</td>
                                    <td>{book.author}</td>
                                </tr>
                                <tr>
                                    <td>isbn 13 :&nbsp;&nbsp;</td>
                                    <td>{book.isbn}</td>
                                </tr>
                            </tbody>
                        </table>
                    </ul>
                </div>
            </div>
        </div >
    )
}

export default Book;