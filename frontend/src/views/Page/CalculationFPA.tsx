import {
    Col,
    Row,
    Image
} from "antd"
import { useState } from 'react'
import { WindowSystems } from "./components/WindowSystems"
import { DynamicSystemRepository } from "../../services/repositiry/DynamicSystemsRepositiry"

const PREF_BASE_64 = "data:image/png;base64,"
const DEFAULT_STYLE_INPUT = {
    width: '100%',
    marginTop: 10
}

const repository = new DynamicSystemRepository()

const CalculationFPA = () => {
    const [img, setImg] = useState<string>('')

    return (
        <Row>
            <Col span={20}>
                {img ? <div style={{ ...DEFAULT_STYLE_INPUT, height: "100%", textAlign: 'center' }}>
                    <Image src={PREF_BASE_64 + img} style={{width: "100%", height: "100%"}} />
                </div > : <div style={{textAlign: 'center', width: '100%'}}>not data</div>}
            </Col>
            <Col span={4}>
                <WindowSystems repository={repository} setImg={setImg} />
            </Col>
        </Row>
    )
}

export { CalculationFPA }