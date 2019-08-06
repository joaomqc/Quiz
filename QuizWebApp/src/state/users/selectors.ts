import { AppState } from 'state';

export const root = 'users';

export function hasRegisterError(state: AppState) {
    return state[root].hasRegisterError;
}

export function isRegisterLoading(state: AppState) {
    return state[root].isRegisterLoading;
}
