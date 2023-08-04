import {
    Col,
    Row,
    Select,
    Typography,
    Input,
} from 'antd';
import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { BaseOptions } from 'vm';
import type { SelectProps } from 'antd';
import DynamicSystems from '../Models/DynamicSystem';
import Parametr from '../Models/Parametr';



export default () => {
    const [listDynamicSystems, setListDynamicSystems] = useState<Array<any>>([]);
    const [currentDynamicSystem, setCurrentDynamicSystem] = useState<DynamicSystems | null>(null);

    useEffect(() => {
        axios.get(`https://localhost:7148/DynamicSystems/GetDynamicSystems`,
            {
                params: {
                    dynamicSystemName: 42
                }
            })
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
        axios.get(`https://localhost:7148/DynamicSystems/GetDynamicSystemInfo?dynamicSystemName=%D0%A1%D0%B8%D1%81%D1%82%D0%B5%D0%BC%D0%B0%20%D0%9B%D0%BE%D1%80%D0%BD%D0%B5%D1%86%D0%B0`)
            .then(result => {
                setCurrentDynamicSystem(new DynamicSystems(
                    result.data.name,
                    result.data.listCalculate,
                    result.data.parametrs
                ));
            });
    };

    var x = currentDynamicSystem?.Parametrs.map((parametr : Parametr) => <Input prefix={parametr.Name} suffix={parametr.Value.toString()} />);

    return (
        <Row gutter={16}>
            <Col className="gutter-row" span={18}>
                <div>col-6</div>
            </Col>
            <Col className="gutter-row" span={6}>
                <Select
                    style={{ width: '100%' }}
                    placeholder="Динамические системы"
                    onChange={handleChange}
                    options={listDynamicSystems} />

                <Typography.Title level={4}>{currentDynamicSystem?.Name}</ Typography.Title>

                <>{x}</>
            </Col>
        </Row>
    );
};