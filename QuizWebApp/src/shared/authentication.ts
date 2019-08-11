import moment, { Moment } from 'moment';
import { Token } from "models/user";

const localStorageKey = 'quiz';

let accessToken: string;
let expirationDate: Moment;

export const authenticateUser = (token: Token): void => {
    accessToken = token.accessToken;
    expirationDate = moment().add(token.expiresIn, 's');
    localStorage.setItem(localStorageKey, JSON.stringify({
        accessToken,
        expirationDate
    }));
}

export const isUserAuthenticated = (): boolean => {
    if(!accessToken){
        const tokenDataString = localStorage.getItem(localStorageKey);
        
        if(!tokenDataString){
            return false;
        }
        
        const tokenData = JSON.parse(tokenDataString);

        accessToken = tokenData.accessToken;
        expirationDate = moment(tokenData.expirationDate);
    }

    return !!accessToken && expirationDate.isAfter(moment());
}

export const revokeAuthentication = (): void => {
    accessToken = '';
    expirationDate = moment();
    localStorage.removeItem(localStorageKey);
}
