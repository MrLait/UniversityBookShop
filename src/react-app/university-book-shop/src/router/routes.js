import PurchaseBookByFacultyId from '../pages/purchasedBooksByFacultyId/PurchaseBookByFacultyId';
import PurchasedBooksByFacultyId from '../pages/PurchasedBooksByFacultyId';
import Universities from '../pages/Universities';
import UniversityIdPage from '../pages/UniversityIdPage';

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
    UniversityIdPageIndex: '/university/:UniversityId?page:pageIndex',
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
    { path: routePaths.UniversityId, element: UniversityIdPage },
    // { path: routePaths.UniversityIdPageIndex, element: UniversityIdPage },
    { path: routePaths.SearchBookByFacultyId, element: PurchaseBookByFacultyId },
    // { path: routePaths.SearchBookByFacultyIdPageIndex, element: PurchaseBookByFacultyId },
    { path: routePaths.PurchasedBooksByFacultyId, element: PurchasedBooksByFacultyId },
    // { path: routePaths.PurchasedBooksByFacultyIdPageIndex, element: PurchasedBooksByFacultyId },
];