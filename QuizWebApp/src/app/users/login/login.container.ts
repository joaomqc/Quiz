import { connect } from 'react-redux';

import Login from './login';

import { logInUser } from 'state/users/actions';

import { isLoginLoading, hasLoginError } from 'state/users/selectors';
import { LoginUser } from 'models/user';

function mapStateToProps(state: any) {
    return {
        isLoginLoading: isLoginLoading(state),
        hasLoginError: hasLoginError(state)
    }
}

function mapDispatchToProps(dispatch: Function) {
    return {
        logInUser: (data: LoginUser) => dispatch(logInUser(data))
    }
}

const LoginContainer = connect(
    mapStateToProps,
    mapDispatchToProps
) (Login);

export default LoginContainer;