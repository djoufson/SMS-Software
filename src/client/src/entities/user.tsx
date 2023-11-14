import { Roles } from "./role"

export interface User{
    id?: string,
    firstName: string,
    lastName: string,
    email: string,
    street: string,
    city: string,
    zipCode?:string,
    province: string,
    telefon: string,
    inactive?: true
    roles?: Roles,
    personalId?: string,
    image?: string

}