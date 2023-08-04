import Parametr from "./Parametr";

class DynamicSystems
{
    Name: string;
    Result: Array<string>;
    Parametrs: Array<Parametr>;

    constructor(Name: string, Result: Array<string>, Parametrs: Array<Parametr>) {
        this.Name = Name;
        this.Result = Result;
        this.Parametrs = Parametrs;
      }
}

export default DynamicSystems;