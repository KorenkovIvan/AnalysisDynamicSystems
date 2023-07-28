import {
    ChromeFilled,
    CrownFilled,
    SmileFilled,
    TabletFilled,
    CalculatorFilled,
    HeatMapOutlined,
    HomeFilled,
    CiCircleFilled,
    TwitterOutlined
  } from '@ant-design/icons';
  
  export default {
    route: {
      path: '/',
      routes: [
        {
          path: '/welcome',
          name: 'Домашняя',
          icon: <HomeFilled />,
          component: './Welcome',
        },
        {
          name: 'Вычисления',
          icon: <CalculatorFilled />,
          path: '/list',
          component: './ListTableList',
          routes: [
            {
              path: '/list/sub-page',
              name: 'Карты',
              icon: <HeatMapOutlined />,
              routes: [
                {
                  path: 'sub-sub-page1',
                  name: 'карта 1',
                  icon: <CrownFilled />,
                  component: './Welcome',
                },
                {
                  path: 'sub-sub-page2',
                  name: 'карта 2',
                  icon: <CrownFilled />,
                  component: './Welcome',
                },
                {
                  path: 'sub-sub-page3',
                  name: 'карта 3',
                  icon: <CrownFilled />,
                  component: './Welcome',
                },
              ],
            },
            {
              path: '/list/sub-page1',
              name: 'Аттракторы',
              icon: <CiCircleFilled />,
              routes: [
                {
                  path: 'sub-sub-page1',
                  name: 'аттрактор 1',
                  icon: <CrownFilled />,
                  component: './Welcome',
                },
                {
                  path: 'sub-sub-page2',
                  name: 'аттрактор 2',
                  icon: <CrownFilled />,
                  component: './Welcome',
                },
                {
                  path: 'sub-sub-page3',
                  name: 'аттрактор 3',
                  icon: <CrownFilled />,
                  component: './Welcome',
                },
              ],
            },
            {
              path: '/list/sub-page2',
              name: 'Тернарные вычисления',
              icon: <TwitterOutlined />,
              routes: [
                {
                  path: 'sub-sub-page1',
                  name: 'вычисления 1',
                  icon: <CrownFilled />,
                  component: './Welcome',
                },
                {
                  path: 'sub-sub-page2',
                  name: 'вычисления 2',
                  icon: <CrownFilled />,
                  component: './Welcome',
                },
                {
                  path: 'sub-sub-page3',
                  name: 'вычисления 3',
                  icon: <CrownFilled />,
                  component: './Welcome',
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
        icon: 'https://gw.alipayobjects.com/zos/rmsportal/KDpgvguMpGfqaHPjicRK.svg',
        title: 'Ant Design',
        desc: '杭州市较知名的 UI 设计语言',
        url: 'https://ant.design',
      },
      {
        icon: 'https://gw.alipayobjects.com/zos/antfincdn/FLrTNDvlna/antv.png',
        title: 'AntV',
        desc: '蚂蚁集团全新一代数据可视化解决方案',
        url: 'https://antv.vision/',
        target: '_blank',
      },
      {
        icon: 'https://gw.alipayobjects.com/zos/antfincdn/upvrAjAPQX/Logo_Tech%252520UI.svg',
        title: 'Pro Components',
        desc: '专业级 UI 组件库',
        url: 'https://procomponents.ant.design/',
      },
      {
        icon: 'https://img.alicdn.com/tfs/TB1zomHwxv1gK0jSZFFXXb0sXXa-200-200.png',
        title: 'umi',
        desc: '插件化的企业级前端应用框架。',
        url: 'https://umijs.org/zh-CN/docs',
      },
  
      {
        icon: 'https://gw.alipayobjects.com/zos/bmw-prod/8a74c1d3-16f3-4719-be63-15e467a68a24/km0cv8vn_w500_h500.png',
        title: 'qiankun',
        desc: '可能是你见过最完善的微前端解决方案🧐',
        url: 'https://qiankun.umijs.org/',
      },
      {
        icon: 'https://gw.alipayobjects.com/zos/rmsportal/XuVpGqBFxXplzvLjJBZB.svg',
        title: '语雀',
        desc: '知识创作与分享工具',
        url: 'https://www.yuque.com/',
      },
      {
        icon: 'https://gw.alipayobjects.com/zos/rmsportal/LFooOLwmxGLsltmUjTAP.svg',
        title: 'Kitchen ',
        desc: 'Sketch 工具集',
        url: 'https://kitchen.alipay.com/',
      },
      {
        icon: 'https://gw.alipayobjects.com/zos/bmw-prod/d3e3eb39-1cd7-4aa5-827c-877deced6b7e/lalxt4g3_w256_h256.png',
        title: 'dumi',
        desc: '为组件开发场景而生的文档工具',
        url: 'https://d.umijs.org/zh-CN',
      },
    ],
  };