import PurchaseBookByFacultyId from "../pages/PurchaseBookByFacultyId";
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
}
export const routePathsNavigate = {
    UniversityId(id) {
        return (`${routePaths.University}/${id}`)
    },
    SearchBookByFacultyId(faculty_id) {
        return (`${routePaths.SearchBook}/${faculty_id}`)
    },

    UniversitiesPage(pageIndex) {
        return (`${routePaths.Page}/${pageIndex}`)
    },

    FacultiesPage(universityId, pageIndex) {
        return (`${routePaths.University}/${universityId}${routePaths.Page}/${pageIndex}`)
    }
}

export const routes = [
    { path: routePaths.Universities, element: Universities },
    { path: routePaths.PageIndex, element: Universities },
    { path: routePaths.UniversityId, element: UniversityIdPage },
    { path: routePaths.UniversityIdPageIndex, element: UniversityIdPage },
    { path: routePaths.SearchBookByFacultyId, element: PurchaseBookByFacultyId },
]