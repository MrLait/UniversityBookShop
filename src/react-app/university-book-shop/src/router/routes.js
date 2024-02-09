import PurchaseBookByFacultyId from "../pages/PurchaseBookByFacultyId";
import PurchasedBooksByFacultyId from "../pages/PurchasedBooksByFacultyId";
import Universities from "../pages/Universities";
import UniversityIdPage from "../pages/UniversityIdPage";

export const routePaths = {
    Universities: '/',
    Page: '/page',
    PageIndex: '/page/:pageIndex',
    University: '/university',
    UniversityId: '/university/:UniversityId',
    UniversityIdPageIndex: `/university/:UniversityId/page/:pageIndex`,
    SearchBook: '/searchBook',
    SearchBookByFacultyId: '/searchBook/:faculty_id',
    Faculty: '/faculty',
    FacultyId: '/faculty/:faculty_id',
    PurchasedBooksByFacultyId: '/university/:UniversityId/faculty/:faculty_id'
}
// university/id/faculty/id
export const routePathsNavigate = {
    UniversityId(id) {
        return (`${routePaths.University}/${id}`)
    },
    UniversitiesPage(pageIndex) {
        return (`${routePaths.Page}/${pageIndex}`)
    },
    SearchBookByFacultyId(faculty_id) {
        return (`${routePaths.SearchBook}/${faculty_id}`)
    },
    FacultiesPage(universityId, pageIndex) {
        return (`${routePaths.University}/${universityId}${routePaths.Page}/${pageIndex}`)
    },
    FacultyBooksByFacultyId(universityId, faculty_id) {
        return (`${routePaths.University}/${universityId}${routePaths.Faculty}/${faculty_id}`)
    },
}

export const routes = [
    { path: routePaths.Universities, element: Universities },
    { path: routePaths.PageIndex, element: Universities },
    { path: routePaths.UniversityId, element: UniversityIdPage },
    { path: routePaths.UniversityIdPageIndex, element: UniversityIdPage },
    { path: routePaths.SearchBookByFacultyId, element: PurchaseBookByFacultyId },
    { path: routePaths.PurchasedBooksByFacultyId, element: PurchasedBooksByFacultyId },
]