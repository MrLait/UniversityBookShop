import PurchaseBookByFacultyId from '../pages/purchaseBooksByFacultyId/PurchaseBookByFacultyId';
import PurchasedBooksByFacultyId from '../pages/purchasedBooksByFacultyId/PurchasedBooksByFacultyId';
import Universities from '../pages/universitiesPage/UniversitiesPage';
import UniversityByUniversityIdPage from '../pages/universityByUniversityIdPage/UniversityByUniversityIdPage';

const routeConst = {
    Page: '?page=',
    Universities: '/',
    University: '/university',
    SearchBookByFacultyId: '/searchBook/facultyId',
    Faculty: '/faculty',
};

export const routePaths = {
    Home: '/',
    Universities: '/',
    UniversitiesPageIndex: '?page=:pageIndex',
    UniversityId: '/university/:UniversityId',
    UniversityByUniversityIdPageIndex: '/university/:UniversityId?page:pageIndex',
    SearchBookByFacultyId: '/searchBook/facultyId/:facultyId',
    SearchBookByFacultyIdPageIndex: '/searchBook/facultyId/:facultyId?page:pageIndex',
    PurchasedBooksByFacultyId: '/university/:UniversityId/faculty/:facultyId',
    PurchasedBooksByFacultyIdPageIndex: '/university/:UniversityId/faculty/:facultyId?page:pageIndex',
};

export const routePathsNavigate = {
    Home() {
        return (`${routePaths.Home}`);
    },
    UniversitiesPage(pageIndex) {
        return (`${routeConst.Universities}${routeConst.Page}${pageIndex}`);
    },
    UniversityId(id) {
        return (`${routeConst.University}/${id}`);
    },
    UniversityIdFacultiesPage(universityId, pageIndex) {
        return (`${routeConst.University}/${universityId}${routeConst.Page}${pageIndex}`);
    },
    SearchBookByFacultyId(facultyId) {
        return (`${routeConst.SearchBookByFacultyId}/${facultyId}`);
    },
    SearchBookByFacultyIdPage(facultyId, pageIndex) {
        return (`${routeConst.SearchBookByFacultyId}/${facultyId}${routeConst.Page}${pageIndex}`);
    },
    PurchasedBooksByFacultyId(universityId, facultyId) {
        return (`${routeConst.University}/${universityId}${routeConst.Faculty}/${facultyId}`);
    },
    PurchasedBooksByFacultyIdPage(universityId, facultyId, pageIndex) {
        return (`${routeConst.University}/${universityId}${routeConst.Faculty}/${facultyId}${routeConst.Page}${pageIndex}`);
    },
};

export const routes = [
    // { path: routePaths.Home, element: Universities },
    { path: routePaths.Universities, element: Universities },
    // { path: routePaths.UniversitiesPageIndex, element: Universities },
    { path: routePaths.UniversityId, element: UniversityByUniversityIdPage },
    // { path: routePaths.UniversityIdPageIndex, element: UniversityIdPage },
    { path: routePaths.SearchBookByFacultyId, element: PurchaseBookByFacultyId },
    // { path: routePaths.SearchBookByFacultyIdPageIndex, element: PurchaseBookByFacultyId },
    { path: routePaths.PurchasedBooksByFacultyId, element: PurchasedBooksByFacultyId },
    // { path: routePaths.PurchasedBooksByFacultyIdPageIndex, element: PurchasedBooksByFacultyId },
];