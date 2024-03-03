
export const getPagesArray = (totalPages) => {
    const pagesArray = [];
    for (let i = 0; i < totalPages; i++) {
        pagesArray.push(i + 1);
    }
    return pagesArray;
};

export const incrementPaginationTotalCount = (setPaginationData) => {

    setPaginationData((prevPaginationData) => ({
        ...prevPaginationData,
        totalCount: prevPaginationData.totalCount + 1,
    }));
    return setPaginationData;
};

export const decrementPaginationTotalCount = (setPaginationData) => {

    setPaginationData((prevPaginationData) => ({
        ...prevPaginationData,
        totalCount: prevPaginationData.totalCount - 1,
    }));
    return setPaginationData;
};

