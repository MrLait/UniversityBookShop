import PurchaseBookByFacultyId from "../pages/PurchaseBookByFacultyId";
import Universities from "../pages/Universities";
import UniversityIdPage from "../pages/UniversityIdPage";

export const routePaths = {
    Universities: '/',
    University: '/university',
    UniversityId: '/university/:id',
    SearchBook: '/searchBook',
    SearchBookByFacultyId: '/searchBook/:faculty_id',
    Test: '/searchBook/:faculty_id',
}
export const routePathsNavigate = {
    UniversityId(id) {
        return (`${routePaths.University}/${id}`)
    },
    SearchBookByFacultyId(faculty_id) {
        return (`${routePaths.SearchBook}/${faculty_id}`)
    }
}

export const routes = [
    { path: routePaths.Universities, element: Universities },
    { path: routePaths.UniversityId, element: UniversityIdPage },
    { path: routePaths.SearchBookByFacultyId, element: PurchaseBookByFacultyId },
]