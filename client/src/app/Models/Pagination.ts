import { IProduct } from "./Product";

export interface IPagination {
    pageIndex: number;
    pagesize: number;
    count: number;
    data: IProduct[];
  }
  