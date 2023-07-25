import axios from "axios"
import { message } from "antd"
import { IRepositoryCalculation } from "./IRepositoryCalculation"

class DynamicSystemRepository implements IRepositoryCalculation
{
    public GetSystems = (callBack: (data: Array<string>) => void, systems : number) => {
        axios<Array<string>>({
            url: `http://localhost:5225/GetListParametrs?dSystem=${systems}`,
            method: 'get'
        })
            .then((response) => callBack(response.data))
            .catch(message.error)
    }

    public GetImgForBase64 = (callBack: (data: string) => void,
        systems : number,
        steap: number,
        count: number,
        parametrs: any,
        width: number,
        height: number,
        background: string,
        colorLine: string,
        ) => {
        axios<string>(
            {
                url: `http://localhost:5225/GetBase64?dSystem=${systems}&Steap=${steap}&CountIteration=${count}&Params=${JSON.stringify(parametrs)}&Width=${width}&Height=${height}&strBackground=%23${background.slice(1, background.length)}&strColorLine=%23${colorLine.slice(1, background.length - 2)}ff`,
                method: "get"
            })
            .then((response) => callBack(response.data))
            .catch(message.error)
    }
}

export { DynamicSystemRepository }