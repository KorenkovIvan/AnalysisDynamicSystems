import { Routes, Route } from "react-router-dom"
import React from 'react'
import { useSelector } from "react-redux"
import { LayoutProps } from "../../services/props/LayoutProps"
import { Rout } from "../../services/entitys/Rout"

interface TypeRoute
{
    key: string
    path: string
    element: React.Component
}

function getRoutes(routes : Array<Rout>, root : string): Array<TypeRoute>
{
    var result: Array<TypeRoute> = []
    for (var index = 0, max = routes.length; index < max; index++)
    {
        const currentUrl = root + '/' + routes[index].path
        if(routes[index].page) 
            result.push({
                key: currentUrl, 
                path: currentUrl, 
                element: routes[index].page
            } as TypeRoute)
        if (routes[index].routes)
            result = [...result, ...getRoutes(routes[index].routes || [], currentUrl)]
    }
    return result;
}

export default function Content() {
    const defaultProps : any = useSelector<LayoutProps>((state: any) => state.defaultProps)
    var path : Array<TypeRoute> = []
    // TODO здесь я не уверен что route не массив
    if (defaultProps.route)
        path = getRoutes([(defaultProps as LayoutProps).route], (defaultProps as LayoutProps).location.pathname)

    return (
        <Routes>
            {path.map((page: TypeRoute) => <Route key={page.key} path={page.path} element={page.element as any} />)}
        </Routes>
    )
}
