import { AppState } from 'state';

export const root = 'users';

export function hasRegisterError(state: AppState) {
    return state[root].hasRegisterError;
}

export function isRegisterLoading(state: AppState) {
    return state[root].isRegisterLoading;
}

export function hasLoginError(state: AppState) {
    return state[root].hasLoginError;
}

export function isLoginLoading(state: AppState) {
    return state[root].isLoginLoading;
}