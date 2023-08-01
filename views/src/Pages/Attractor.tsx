import { Col, Row } from 'antd';

export default () => {
    return (
        <Row gutter={16}>
            <Col className="gutter-row" span={18}>
                <div>col-6</div>
            </Col>
            <Col className="gutter-row" span={6}>
                <div>col-6</div>
            </Col>
        </Row>
    );
};