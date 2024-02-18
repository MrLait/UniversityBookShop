import React from 'react';

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
                Total book price: {university.totalBookPrice} {university.currencyCode.code}
            </div>
            <div>Number of faculties: {university.facultyCount} </div>
            <div>Number of books: {university.bookCount}</div>
        </div>
    );
};

export default UniversityDescription;
