import ActionTypes from 'state/action-types';
import { post } from 'shared/http';
import { RegisterUser } from 'models/user';
import { push } from 'react-router-redux';

export function registerUser(userInfo: RegisterUser) {
    return (dispatch: Function) => {
        dispatch({type: ActionTypes.REGISTERING_USER});

        return post('/api/users', userInfo)
            .then(res => {
                dispatch({type: ActionTypes.REGISTER_USER_SUCCESS});
                dispatch(push('/home'));
            })
            .catch(err => dispatch({type: ActionTypes.REGISTER_USER_ERROR}));
    }
}