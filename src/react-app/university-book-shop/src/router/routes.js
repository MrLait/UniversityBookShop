import PurchaseBookByFacultyId from "../pages/PurchaseBookByFacultyId";
import PurchasedBooksByFacultyId from "../pages/PurchasedBooksByFacultyId";
import Universities from "../pages/Universities";
import UniversityIdPage from "../pages/UniversityIdPage";

export const routePaths = {
    Home: '/',
    Universities: '/universities',
    Page: '/page',
    PageIndex: '/universities/page/:pageIndex',
    University: '/university',
    UniversityId: '/university/:UniversityId',
    UniversityIdPageIndex: `/university/:UniversityId/page/:pageIndex`,
    SearchBook: '/searchBook',
    SearchBookByFacultyId: '/searchBook/:facultyId',
    Faculty: '/faculty',
    FacultyId: '/faculty/:facultyId',
    PurchasedBooksByFacultyId: '/university/:UniversityId/faculty/:facultyId'
}
// university/id/faculty/id
export const routePathsNavigate = {
    Home() {
        return (`${routePaths.Home}`)
    },
    UniversityId(id) {
        return (`${routePaths.University}/${id}`)
    },
    UniversitiesPage(pageIndex) {
        return (`${routePaths.Universities}${routePaths.Page}/${pageIndex}`)
    },
    SearchBookByFacultyId(facultyId) {
        return (`${routePaths.SearchBook}/${facultyId}`)
    },
    FacultiesPage(universityId, pageIndex) {
        return (`${routePaths.University}/${universityId}${routePaths.Page}/${pageIndex}`)
    },
    FacultyBooksByFacultyId(universityId, facultyId) {
        return (`${routePaths.University}/${universityId}${routePaths.Faculty}/${facultyId}`)
    },
}

export const routes = [
    { path: routePaths.Home, element: Universities },
    // { path: routePaths.Universities, element: Universities },
    { path: routePaths.Universities, element: Universities },
    { path: routePaths.PageIndex, element: Universities },
    { path: routePaths.UniversityId, element: UniversityIdPage },
    { path: routePaths.UniversityIdPageIndex, element: UniversityIdPage },
    { path: routePaths.SearchBookByFacultyId, element: PurchaseBookByFacultyId },
    { path: routePaths.PurchasedBooksByFacultyId, element: PurchasedBooksByFacultyId },
]