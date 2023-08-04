import Parametr from "./Parametr";

class DynamicSystems
{
    Name: string;
    Result: Array<string>;
    Parametrs: Array<Parametr>;

    constructor(Name: string, Result: Array<string>, Parametrs: any) {
        this.Name = Name;
        this.Result = Result;
        this.Parametrs = new Array();
        // TODO тут у тебя какая-то фигня
        for(var item in Parametrs)
        {
            this.Parametrs.push(new Parametr(item, Parametrs[item]));
        }
      }
}

export default DynamicSystems;