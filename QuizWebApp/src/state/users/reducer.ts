import ActionTypes from 'state/action-types';
import { UserAction } from './types';

const initialState = {
    isRegisterLoading: false,
    hasRegisterError: false,
    isLoginLoading: false,
    hasLoginError: false
};

export default function reducer (state = initialState, action: UserAction) {
    switch(action.type) {
        case ActionTypes.REGISTERING_USER:
            return {
                ...state,
                isRegisterLoading: true,
                hasRegisterError: false
            };

        case ActionTypes.REGISTER_USER_SUCCESS:
            return {
                ...state,
                isRegisterLoading: false,
                hasRegisterError: false
            };

        case ActionTypes.REGISTER_USER_ERROR:
            return {
                ...state,
                isRegisterLoading: false,
                hasRegisterError: true
            };

        case ActionTypes.LOGGING_IN:
            return {
                ...state,
                isLoginLoading: true,
                hasLoginError: false
            }

        case ActionTypes.LOG_IN_SUCCESS:
            return {
                ...state,
                isLoginLoading: false,
                hasLoginError: false
            }

        case ActionTypes.LOG_IN_ERROR:
            return {
                ...state,
                isLoginLoading: false,
                hasLoginError: true
            }

        default:
            return state;
    }
}