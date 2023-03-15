import Universities from "../pages/Universities";
import UniversityIdPage from "../pages/UniversityIdPage";

export const routePaths = {
    Universities: '/universities',
    University: '/university',
    UniversityId: '/university/:id',
}
export const routePathsNavigate = {
    UniversityId(id) {
        return (`${routePaths.University}/${id}`)
    }
}

export const routes = [
    { path: routePaths.Universities, element: Universities },
    { path: routePaths.UniversityId, element: UniversityIdPage },
]