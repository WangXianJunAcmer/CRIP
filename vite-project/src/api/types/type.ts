
export interface IlistParams{

keyword:string,
OrderBy:string,
Desc:boolean,
PageNumber:number,
PageSize:number
}

export interface Drugs {
    id: string;
    name: string;
    price: number;
    info: string;
    quantity: number;
    link: {
      href: string | null;
      rel: string;
      method: string;
    };
  }

export interface Header{
    "set-cookie"?: string[],
  'x-pagination':string
  }
