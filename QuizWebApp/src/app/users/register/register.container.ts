import { connect } from 'react-redux';

import Register from './register';

import { registerUser } from 'state/users/actions';

import { isRegisterLoading, hasRegisterError } from 'state/users/selectors';
import { RegisterUser } from 'models/user';

function mapStateToProps(state: any) {
    return {
        isRegisterLoading: isRegisterLoading(state),
        hasRegisterError: hasRegisterError(state)
    }
}

function mapDispatchToProps(dispatch: Function) {
    return {
        registerUser: (data: RegisterUser) => dispatch(registerUser(data))
    }
}

const RegisterContainer = connect(
    mapStateToProps,
    mapDispatchToProps
) (Register);

export default RegisterContainer;