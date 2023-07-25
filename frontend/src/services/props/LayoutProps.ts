import { App } from "../entitys/App"
import { Rout } from "../entitys/Rout"
import { Location } from "../entitys/Location"

interface LayoutProps
{
    route : Rout
    location : Location
    appList : Array<App>
}

export { type LayoutProps }
