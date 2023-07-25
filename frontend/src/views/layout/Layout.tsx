import {
    GithubFilled,
    InfoCircleFilled,
    QuestionCircleFilled,
    SearchOutlined,
    UserOutlined,
    LoginOutlined,
  } from '@ant-design/icons'
  import {
    PageContainer,
    ProCard,
    ProConfigProvider,
    ProLayout,
  } from '@ant-design/pro-components'
  import { Divider, Input, theme, Dropdown, Button, Modal, message } from 'antd'
  import MyContent from './Content'
  import React, { useState } from 'react'
  import { useSelector } from 'react-redux'
  import { useNavigate } from 'react-router-dom'
  import type { MenuProps } from 'antd'
  import axios from 'axios'
  
  
  const MenuCard = () => {
    return (
      <div
        style={{
          display: 'flex',
          alignItems: 'center',
        }}
      >
        <Divider
          style={{
            height: '1.5em',
          }}
          type="vertical"
        />
      </div>
    );
  };
  
  const SearchInput = () => {
    const { token } = theme.useToken();
    return (
      <div
        key="SearchOutlined"
        aria-hidden
        style={{
          display: 'flex',
          alignItems: 'center',
          marginInlineEnd: 24,
        }}
        onMouseDown={(e) => {
          e.stopPropagation();
          e.preventDefault();
        }}
      >
        <Input
          style={{
            borderRadius: 4,
            marginInlineEnd: 12,
            backgroundColor: token.colorBgTextHover,
          }}
          prefix={
            <SearchOutlined
              style={{
                color: token.colorTextLightSolid,
              }}
            />
          }
          placeholder="Поиск"
          bordered={false}
        />
      </div>
    );
  };
  
  const Layout: React.FC = () => {
  
    const [isModalOpen, setIsModalOpen] = useState(false);
  
    const showModal = () => {
      setIsModalOpen(true);
    };
  
    const handleOk = () => {
      setIsModalOpen(false);
    };
  
    const handleCancel = () => {
      setIsModalOpen(false);
    };
  
    const items: MenuProps['items'] = [
      {
        key: '1',
        label: (
          <a target="_blank" rel="noopener noreferrer" href="https://www.antgroup.com">
            1st menu item
          </a>
        ),
      },
      {
        key: '2',
        label: (
          <a target="_blank" rel="noopener noreferrer" href="https://www.aliyun.com">
            2nd menu item
          </a>
        ),
      },
      {
        key: '3',
        label: <><LoginOutlined /> Авторизоваться</>,
        onClick: () => {
          showModal()
          axios({
            method: 'post',
            url: 'http://localhost:5035/login?UserName=IMKorenkov&Password=123456789qwerty',
        })
            .then(console.log)
            .catch(message.error)
  
        },
      },
    ];
  
  
    const navigate = useNavigate()
    const settings =
    {
      fixSiderbar: true,
      layout: "mix",
      splitMenus: false,
      navTheme: "realDark",
      contentWidth: "Fluid",
      colorPrimary: "#52C41A",
      siderMenuType: "sub",
      colorWeak: false
    }
    const [pathname, setPathname] = useState('/')
  
    const defaultProps = useSelector((state: any) => state.defaultProps)
  
    return (
      <div
        id="test-pro-layout"
        style={{
          height: '100vh',
        }}
      >
        <ProConfigProvider hashed={false}>
          <Modal 
            title="Авторизация" 
            open={isModalOpen} 
            onOk={handleOk} 
            onCancel={handleCancel} 
            // TODO сделал перед тем как заработала кастомизация
            forceRender={true}>
            <p>Some contents...</p>
            <p>Some contents...</p>
            <p>Some contents...</p>
          </Modal>
          <ProLayout
            prefixCls="my-prefix"
            bgLayoutImgList={[
              {
                src: 'https://phonoteka.org/uploads/posts/2022-01/1643278885_93-phonoteka-org-p-fon-dlya-fizikov-i-matematikov-98.jpg',
              },
            ]}
            {...defaultProps}
            location={{
              pathname,
            }}
            menu={{
              collapsedShowGroupTitle: true,
            }}
            actionsRender={(props) => {
              if (props.isMobile) return [];
              return [
                props.layout !== 'side' && document.body.clientWidth > 1400 ? (
                  <SearchInput />
                ) : undefined,
                <Dropdown menu={{ items }} placement="bottomLeft">
                  <Button icon={<UserOutlined />} > Профиль</Button>
                </Dropdown>,
              ];
            }}
            headerTitleRender={(logo, title, _) => {
              const defaultDom = (
                <>
                  {logo}
                  {title}
                </>
              );
              if (document.body.clientWidth < 1400) {
                return defaultDom;
              }
              if (_.isMobile) return defaultDom;
              return (
                <>
                  {defaultDom}
                  <MenuCard />
                </>
              );
            }}
            menuFooterRender={(props) => {
              if (props?.collapsed) return undefined;
              return (
                <div
                  style={{
                    textAlign: 'center',
                    paddingBlockStart: 12,
                  }}
                >
                  <div>ТФОМС НН</div>
                </div>
              );
            }}
            onMenuHeaderClick={(e) => console.log(e)}
            menuItemRender={(item, dom) => (
              <div
                onClick={() => {
                  navigate(item.path || "/", { replace: true })
                  setPathname(item.path || '/welcome');
                }}
              >
                {dom}
              </div>
            )}
            {...settings}
          >
            <PageContainer>
              <ProCard
                style={{
                  minHeight: 800,
                }}
              >
                <MyContent />
              </ProCard>
            </PageContainer>
          </ProLayout>
        </ProConfigProvider>
      </div>
    )
  }
  
  export { Layout }
  