import PurchaseBookByFacultyId from "../pages/PurchaseBookByFacultyId";
import Universities from "../pages/Universities";
import UniversityIdPage from "../pages/UniversityIdPage";

export const routePaths = {
    Universities: '/',
    UniversitiesPage: '/page',
    UniversitiesPageIndex: '/page/:pageIndex',
    University: '/university',
    UniversityId: '/university/:UniversityId',
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
        return (`${routePaths.UniversitiesPage}/${pageIndex}`)
    }
}

export const routes = [
    { path: routePaths.Universities, element: Universities },
    { path: routePaths.UniversitiesPageIndex, element: Universities },
    { path: routePaths.UniversityId, element: UniversityIdPage },
    { path: routePaths.SearchBookByFacultyId, element: PurchaseBookByFacultyId },
]