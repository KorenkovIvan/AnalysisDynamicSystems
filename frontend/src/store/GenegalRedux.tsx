import React from "react"
import {
    HomeOutlined,
    ThunderboltOutlined,
    CalculatorOutlined, 
    SettingOutlined 
} from '@ant-design/icons'
import { CalculationFPA } from "../views/Page/CalculationFPA";
import { LyapynovExponent } from "../views/Page/LyapynovExponent";


const defaultState = {
    defaultProps:{
        route: {
            path: '/',
            routes: [
                {
                    path: '/home',
                    name: 'Домашняя',
                    icon: <HomeOutlined />,
                    page: <>Home</>
                },
                {
                    path: '/calculation',
                    name: 'Вычисления',
                    icon: <CalculatorOutlined />,
                    routes: [
                        {
                            path: 'fpa',
                            name: 'Фазовый портрет аттрактора',
                            page: <CalculationFPA />
                        },
                        {
                            path: 'lyapynov',
                            name: 'Значение старшего ляпуновского показателя',
                            page: <LyapynovExponent />
                        },
                    ],
                },
                {
                    path: '/settings',
                    name: 'Настройки',
                    icon: <SettingOutlined />,
                    page: <>Settings</>
                },
                {
                    path: '/admin',
                    name: 'Админ',
                    icon: <ThunderboltOutlined />,
                    routes: [
                        {
                            path: 'test',
                            name: 'Тестовые страници',
                            routes: [
                                {
                                    path: 'table',
                                    name: 'Таблица',
                                    page: <>Test</>
                                },
                            ],
                        },
                    ],
                },
            ],
        },
        location: {
            pathname: '/',
        },
        appList: [
            {
                icon: 'https://www.svgrepo.com/show/374111/swagger.svg',
                title: 'Swagger',
                url: 'https://ant.design',
            },
            {
                icon: 'https://cdn.iconscout.com/icon/free/png-256/rabbitmq-282296.png?f=webp&w=256',
                title: 'RabbitMQ',
                url: 'http://localhost:15672/',
            },
            {
                icon: 'https://cdn.iconscout.com/icon/free/png-256/graphql-3521468-2944912.png?f=webp&w=256',
                title: 'GraphQL',
                url: 'https://procomponents.ant.design/',
            },
            {
                icon: 'https://img.icons8.com/nolan/512/log.png',
                title: 'Sirelog',
                url: 'https://umijs.org/zh-CN/docs',
            },
    
            {
                icon: 'https://cdn.iconscout.com/icon/free/png-256/fire-1660433-1408702.png',
                title: 'HangFire',
                url: 'https://qiankun.umijs.org/',
            },
            {
                icon: 'https://cdn.iconscout.com/icon/free/png-256/gitlab-3521448-2944892.png',
                title: 'GitLab',
                url: 'http://192.168.13.93/',
            },
        ],
    },
    profile: {
        isActev: false,
        name: "default",
        id: 0,
    },
}

const reducer = (state = defaultState, action: any) => {
    return { ...state };
}

export default reducer
