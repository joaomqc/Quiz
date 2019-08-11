import ActionTypes from 'state/action-types';
import { post } from 'shared/http';
import { RegisterUser, LoginUser } from 'models/user';
import { push } from 'react-router-redux';
import { Routes } from 'app/routes';
import { authenticateUser } from 'shared/authentication';

export function registerUser(userInfo: RegisterUser) {
    return (dispatch: Function) => {
        dispatch({type: ActionTypes.REGISTERING_USER});

        return post('/api/users', userInfo)
            .then(() => {
                dispatch({type: ActionTypes.REGISTER_USER_SUCCESS});
                dispatch(push(Routes.Login.path));
            })
            .catch(() => dispatch({type: ActionTypes.REGISTER_USER_ERROR}));
    }
}

export function logInUser(userInfo: LoginUser) {
    return (dispatch: Function) => {
        dispatch({type: ActionTypes.LOGGING_IN});

        return post('/api/users/auth', userInfo)
            .then(res => {
                authenticateUser(res.data);
                dispatch({type: ActionTypes.LOG_IN_SUCCESS});
                dispatch(push(Routes.Home.path));
            })
            .catch(() => dispatch({type: ActionTypes.LOG_IN_ERROR}));
    }
}