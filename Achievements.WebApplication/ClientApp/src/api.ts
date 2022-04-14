export interface User{
  id: number|null;
  firstName:string;
  lastName: string;
  patronymic:string;
  userName:string;
  email:string;
  password:string;
  role: number;
}
export enum UserRole {
  User = 1,
  Admin = 2
}
export interface Group {
  id: number;
  name: string;
}
export interface Type {
  id: number|null;
  name: string;
  achievementGroup: Group;
}
