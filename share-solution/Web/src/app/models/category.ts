export interface ICategory {
  name?: string;
  id?: string;
  parent?: ICategory | null,
  childs: ICategory[]
}