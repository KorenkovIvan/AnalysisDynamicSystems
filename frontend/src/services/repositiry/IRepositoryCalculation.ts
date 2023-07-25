interface IRepositoryCalculation
{
    GetSystems: (callBack: (data: Array<string>) => void, systems : number) => void,
    GetImgForBase64: (callBack: (data: string) => void,
    systems : number,
    steap: number,
    count: number,
    parametrs: any,
    width: number,
    height: number,
    background: string,
    colorLine: string,) => void
}

export { type IRepositoryCalculation }