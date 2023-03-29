import requestArea from "../utils/drug";
import { IlistParams } from "./types/type";
import { Drugs,Header } from "./types/type";


export const getData = (params: IlistParams) => {
//返回的数据类型
    return requestArea<
    {
        data: Drugs[],
        headers: Header


    }
    >
        (
            {
                method: 'GET',
                url: `/api/Goods?Keyword=${params.keyword}&OrderBy=${params.OrderBy}&Desc=${params.Desc}&PageNumber=${params.PageNumber}&PageSize=${params.PageSize}`,
                params,
                headers:{
                    Accept: 'application/json' 
                }
            }
        )
}