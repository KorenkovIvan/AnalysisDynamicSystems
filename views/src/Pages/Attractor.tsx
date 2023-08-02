import { Col, Row } from 'antd';
import axios from 'axios';
import React, { useState } from 'react';

export default () => {

    const [per, setPer] = useState<Array<string>>([]);

    var a = axios.get(`https://localhost:7148/DynamicSystems`)
    .then(res => {
      const persons = res.data;
      debugger;
      setPer(persons);
    })

    return (
        <Row gutter={16}>
            <Col className="gutter-row" span={18}>
                <div>col-6</div>
            </Col>
            <Col className="gutter-row" span={6}>
                <div>col-6</div>
                <li>{per}</li>
            </Col>
        </Row>
    );
};