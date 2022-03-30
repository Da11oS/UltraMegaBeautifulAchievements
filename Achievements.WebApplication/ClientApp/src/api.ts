export interface User{
  id: number|null;
  firstName:string;
  lastName: string;
  patronymic:string;
  userName:string;
  email:string;
  password:string;
}
export interface Group {
  id: number|null;
  name: string;
}
export interface Type {
  id: number|null;
  groupId: number;
  name: string;
}
