// React
import React from 'react'
import ReactDOM from 'react-dom/client'
import { Layout } from './views/layout/Layout'

// Redux
import { Provider } from "react-redux"
import { createStore } from "redux"
import reducer from './store/GenegalRedux'

// routers
import { BrowserRouter } from "react-router-dom"

import { ConfigProvider } from 'antd'
import ruRU from 'antd/locale/ru_RU'


const store = createStore(reducer)

const root = ReactDOM.createRoot(document.getElementById('root') as any)
root.render(
    <React.StrictMode>
        <BrowserRouter>
            <Provider store={store}>
                <ConfigProvider locale={ruRU}>
                    <Layout />
                </ConfigProvider>
            </Provider>
        </BrowserRouter>
    </React.StrictMode>
)