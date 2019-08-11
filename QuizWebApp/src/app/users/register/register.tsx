import * as React from 'react';
import InputGroup from 'react-bootstrap/InputGroup';
import FormControl from 'react-bootstrap/FormControl';
import Button from 'react-bootstrap/Button';
import Spinner from 'react-bootstrap/Spinner';
import { RegisterUser } from 'models/user';
import { isEmailValid, isUsernameValid, isPasswordValid } from 'shared/validators';

type Props = {
    isRegisterLoading: boolean,
    hasRegisterError: boolean,
    registerUser: Function,
}

type State = {
    user: RegisterUser,
    hasEmailError: boolean,
    hasUsernameError: boolean,
    hasPasswordError: boolean
}

export default class Register extends React.Component<Props, State> {

    constructor(props: Props){
        super(props);

        this.state = {
            user: {
                email: '',
                username: '',
                password: ''
            },
            hasEmailError: false,
            hasUsernameError: false,
            hasPasswordError: false
        }
    }

    updateUserField = (field: string, value: string) => {
        this.setState({
            user: {
                ...this.state.user,
                [field]: value
            }
        });
    }

    isUserValid = () => {
        const { user } = this.state;

        return isEmailValid(user.email)
            && isUsernameValid(user.username)
            && isPasswordValid(user.password);
    }

    handleRegister = () => {
        if(!this.props.isRegisterLoading){
            if(this.isUserValid()){
                this.props.registerUser(
                    this.state.user
                );
            }else {
                this.checkEmailIsValid();
                this.checkUsernameIsValid();
                this.checkPasswordIsValid();
            }
        }
    }

    onKeyDown = (evt: React.KeyboardEvent<HTMLInputElement>): void => {
        if(evt.key === 'Enter'){
            this.handleRegister();
        }
    }

    checkEmailIsValid = () => {
        const emailIsValid = isEmailValid(this.state.user.email);

        this.setState({
            hasEmailError: !emailIsValid
        });

        return emailIsValid;
    }

    checkUsernameIsValid = () => {
        const usernameIsValid = isUsernameValid(this.state.user.username);

        this.setState({
            hasUsernameError: !usernameIsValid
        });

        return usernameIsValid
    }

    checkPasswordIsValid = () => {
        const passwordIsValid = isPasswordValid(this.state.user.password);

        this.setState({
            hasPasswordError: !passwordIsValid
        });

        return passwordIsValid;
    }

    render() {
        return (
            <div className="form-page">
                <div className="form-wrapper">
                    <div className="form-container">
                        <div className="title">register</div>
                        <form className="input-group">
                            <InputGroup className="mb-3">
                                <InputGroup.Prepend>
                                    <InputGroup.Text>
                                        @
                                    </InputGroup.Text>
                                </InputGroup.Prepend>
                                <FormControl
                                    onKeyDown={this.onKeyDown}
                                    autoComplete="email"
                                    placeholder="email"
                                    value={this.state.user.email}
                                    onChange={(evt: any) =>
                                        this.updateUserField('email', evt.target.value)}
                                    onBlur={this.checkEmailIsValid}
                                    onFocus={() => this.setState({
                                        hasEmailError: false
                                    })}
                                />
                            </InputGroup>
                            {this.state.hasEmailError &&
                                <span className="alert-message mb-3">Email is not valid</span>}
                            <InputGroup className="mb-3">
                                <InputGroup.Prepend>
                                    <InputGroup.Text>
                                        <i className="fa fa-user-circle-o" aria-hidden="true"/>
                                    </InputGroup.Text>
                                </InputGroup.Prepend>
                                <FormControl
                                    onKeyDown={this.onKeyDown}
                                    autoComplete="username"
                                    placeholder="username"
                                    value={this.state.user.username}
                                    onChange={(evt: any) =>
                                        this.updateUserField('username', evt.target.value)}
                                    onBlur={this.checkUsernameIsValid}
                                    onFocus={() => this.setState({
                                        hasUsernameError: false
                                    })}
                                />
                            </InputGroup>
                            {this.state.hasUsernameError &&
                                <span className="alert-message mb-3">Username must be between 3 and 20 characters</span>}
                            <InputGroup className="mb-3">
                                <InputGroup.Prepend>
                                    <InputGroup.Text>
                                        <i className="fa fa-key-modern" aria-hidden="true"/>
                                    </InputGroup.Text>
                                </InputGroup.Prepend>
                                <FormControl
                                    onKeyDown={this.onKeyDown}
                                    autoComplete="new-password"
                                    type="password"
                                    placeholder="password"
                                    value={this.state.user.password}
                                    onChange={(evt: any) =>
                                        this.updateUserField('password', evt.target.value)}
                                    onBlur={this.checkPasswordIsValid}
                                    onFocus={() => this.setState({
                                        hasPasswordError: false
                                    })}
                                />
                            </InputGroup>
                            {this.state.hasPasswordError &&
                                <span className="alert-message mb-3">Password must have at least 8 characters</span>}
                        </form>
                        <Button
                            disabled={this.props.isRegisterLoading}
                            variant="primary"
                            size="lg"
                            block
                            onClick={this.handleRegister}>
                            {this.props.isRegisterLoading &&
                                <Spinner
                                    as="span"
                                    animation="border"
                                    size="sm"
                                    role="status"
                                    aria-hidden="true"
                                    />}
                            {this.props.isRegisterLoading
                                ? ' loading...'
                                : 'register'}
                        </Button>
                    </div>
                </div>
            </div>
        );
    }
}