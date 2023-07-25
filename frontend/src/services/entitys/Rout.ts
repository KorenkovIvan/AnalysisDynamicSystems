import React from 'react'

type Rout =
{
    path : string
    name : string
    icon? : React.Component
    page? : React.Component
    routes? : Array<Rout>
}

export { type Rout }
