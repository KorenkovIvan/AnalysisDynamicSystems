import {
    Col,
    Row,
    Select,
    Typography,
    Input,
    message,
    Image,
} from 'antd';
import axios, { AxiosError } from 'axios';
import React, { useEffect, useState } from 'react';
import { BaseOptions } from 'vm';
import type { SelectProps } from 'antd';
import DynamicSystems from '../Models/DynamicSystem';
import Parametr from '../Models/Parametr';



export default () => {
    const [listDynamicSystems, setListDynamicSystems] = useState<Array<any>>([]);
    const [currentDynamicSystem, setCurrentDynamicSystem] = useState<DynamicSystems | null>(null);
    const [messageApi, contextHolder] = message.useMessage();
    const [picture, setPicture] = useState("");
    const _parametr: any = {};

    useEffect(() => {
        axios.get(`https://localhost:7148/DynamicSystems/GetDynamicSystems`)
            .then(res => {
                const ds = res.data.map((x: string) => {
                    return {
                        value: x,
                        label: x,
                    }
                });
                setListDynamicSystems(ds);
            });
    }, []);

    const handleChange = (value: string) => {
        axios.get(`https://localhost:7148/DynamicSystems/GetDynamicSystemInfo`,
            {
                params: {
                    dynamicSystemName: value
                }
            })
            .then(result => {
                setCurrentDynamicSystem(new DynamicSystems(
                    result.data.name,
                    result.data.listCalculate,
                    result.data.parametrs
                ));
            })
            .catch((errors: AxiosError) => messageApi.open({
                type: 'error',
                content: errors?.response?.data + '',
            }));
    };

    const onChangeHandler = (e: React.FormEvent<HTMLInputElement>, parametrName: string) => {
        _parametr[parametrName] = e.currentTarget.value;
        console.log(_parametr);
    }

    return (
        <Row gutter={16}>
            {contextHolder}
            <Col className="gutter-row" span={18}>
                <Image
                    width={'100%'}
                    height={'100%'}
                    src={"data:image/png;base64," + picture}
                />
            </Col>
            <Col className="gutter-row" span={6}>
                <Select
                    style={{ width: '100%' }}
                    placeholder="Динамические системы"
                    onChange={handleChange}
                    options={listDynamicSystems} />

                <Typography.Title level={4}>{currentDynamicSystem?.Name}</ Typography.Title>

                <>
                    {currentDynamicSystem?.Parametrs.map((parametr: Parametr) =>
                        <Input
                            addonBefore={parametr.Name}
                            defaultValue={parametr.Value.toString()}
                            onChange={(e: React.FormEvent<HTMLInputElement>) => onChangeHandler(e, parametr.Name)}
                        />)}
                </>

                <>
                    <button
                        onClick={() => axios.get(`https://localhost:7148/DynamicSystems/CreateAttractor`)
                            .then(res => {
                                setPicture(res.data)
                            })}
                    >=)</button>
                </>
            </Col>
        </Row>
    );
};