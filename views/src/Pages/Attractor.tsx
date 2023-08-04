import { 
    Col, 
    Row, 
    Select 
} from 'antd';
import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { BaseOptions } from 'vm';
import type { SelectProps } from 'antd';

const handleChange = (value: string) => {
    console.log(`selected ${value}`);
  };

export default () => {
    const [dynamicSystems, setDynamicSystems] = useState<Array<any>>([]);

    useEffect(() => {
        axios.get(`https://localhost:7148/DynamicSystems/GetDynamicSystems`)
        .then(res => {
            const ds = res.data.map((x : string) => { return {
                value: x,
                label: x,
            }});
            setDynamicSystems(ds);
      });}, []);

    

    return (
        <Row gutter={16}>
            <Col className="gutter-row" span={18}>
                <div>col-6</div>
            </Col>
            <Col className="gutter-row" span={6}>
                <Select
                    mode="tags"
                    style={{ width: '100%' }}
                    placeholder="Динамические системы"
                    onChange={handleChange}
                    options={dynamicSystems} />
            </Col>
        </Row>
    );
};