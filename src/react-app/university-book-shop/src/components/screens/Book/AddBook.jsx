// @ts-nocheck
import React from 'react';

import MyButton from '../../UI/button/MyButton';

const AddBook = ({ book, addBook }) => {
    return (
        <div>
            <div>
                <MyButton onClick={() => addBook(book.id)}>Add</MyButton>
            </div>
        </div >
    );
};

export default AddBook;
