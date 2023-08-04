import Parametr from "./Parametr"

class AttractorIn
{
    DynamicSystemName: string;
    Width: number;
    Height: number;
    CountIteration: number;
    Parametrs: Array<Parametr>;

    constructor() {
        this.DynamicSystemName = "";
        this.Width = 0;
        this.Height = 0;
        this.CountIteration = 0;
        this.Parametrs = new Array<Parametr>();
    }
}

export default AttractorIn;