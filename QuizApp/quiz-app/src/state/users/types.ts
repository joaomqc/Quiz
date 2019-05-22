import { RegisterUser, LoginUser } from "models/user";

export interface UserAction {
    type: string,
    payload: RegisterUser | LoginUser
}