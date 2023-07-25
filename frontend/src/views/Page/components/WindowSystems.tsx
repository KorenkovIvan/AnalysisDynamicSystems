import {
    Col,
    Row,
    Image,
    Button,
    message,
    Select,
    Input,
    Checkbox,
    Typography
} from "antd"

import axios from "axios"
import { useState } from 'react'
import { DynamicSystemRepository } from "../../../services/repositiry/DynamicSystemsRepositiry"
import { IRepositoryCalculation } from "../../../services/repositiry/IRepositoryCalculation"

const { Text, Link } = Typography
const PREF_BASE_64 = "data:image/png;base64,"
const DEFAULT_STYLE_INPUT = {
    width: '100%',
    marginTop: 10
}
const DEFAULT_TEXT = {
    paddingTop: 10
}

interface DynamicSystemsProps
{
    repository: IRepositoryCalculation
    setImg: (img: string) => void
}

const WindowSystems = (props: DynamicSystemsProps) => {

    // const [img, setImg] = useState<string>('')
    const [systems, setSystems] = useState<number>(0)
    const [count, setCount] = useState<number>(1000000)
    const [steap, setSteap] = useState<number>(0.01)
    const [listParametrs, setListParametrs] = useState<Array<string>>([])
    const [background, setBackground] = useState<string>("#00000000")
    const [colorLine, setColorLine] = useState<string>("#ff0000ff")
    const [width, setWidth] = useState<number>(400)
    const [height, setHeight] = useState<number>(400)
    const parametrs: any = {}

    return (
        <>
            <Text style={DEFAULT_TEXT}>Динамическя система</Text>
            <Select
                style={DEFAULT_STYLE_INPUT}
                onChange={(index) => {
                    setSystems(index)
                    props.repository.GetSystems(setListParametrs, systems)
                }}
                options={[
                    { value: 0, label: 'Lorenz System' },
                    { value: 1, label: 'Shmzy-Morioka System' },
                ]} />
            <Input
                addonBefore="Count Iteration"
                style={DEFAULT_STYLE_INPUT}
                value={count}
                type={'number'}
                onChange={(data) => setCount(Number(data.target.value))} />
            <Input
                addonBefore="Steap"
                style={DEFAULT_STYLE_INPUT}
                value={steap}
                type={'number'}
                onChange={(data) => setSteap(Number(data.target.value))} />
            {listParametrs.length !== 0 ? <Text style={DEFAULT_TEXT}>Параметры</Text> : <></>}
            {
                listParametrs.map(
                    (parametr) => <Input
                        key={parametr}
                        addonBefore={parametr}
                        style={DEFAULT_STYLE_INPUT}
                        type={'number'}
                        defaultValue={"0.0"}
                        onChange={(data) => { parametrs[parametr] = Number(data.target.value) }} />)
            }
            <Text style={DEFAULT_TEXT}>Цвета</Text>
            <Input
                style={DEFAULT_STYLE_INPUT}
                addonBefore="Color line"
                onChange={(data) => setColorLine(data.target.value)}
                type="color" />
            <Input
                style={DEFAULT_STYLE_INPUT}
                addonBefore="Background"
                defaultValue={"#000000"}
                onChange={(data) => setBackground(data.target.value)}
                type="color" />
            <div style={{ ...DEFAULT_STYLE_INPUT, textAlign: 'right' }}>
                <Checkbox onChange={console.log}>Alpha</Checkbox>
            </div>
            <Text style={DEFAULT_TEXT}>Отображение</Text>
            <Input
                addonBefore="Width"
                defaultValue={400}
                style={DEFAULT_STYLE_INPUT}
                type={'number'}
                onChange={(data) => setWidth(Number(data.target.value))} />
            <Input
                addonBefore="Height"
                style={DEFAULT_STYLE_INPUT}
                defaultValue={400}
                type={'number'}
                onChange={(data) => setHeight(Number(data.target.value))} />
            <Button
                style={DEFAULT_STYLE_INPUT}
                onClick={() => {
                    props.repository.GetImgForBase64(props.setImg, systems, steap, count, parametrs, height, width, background, colorLine)
                }}>
                Create
            </Button>
        </>
    )
}

export { WindowSystems }