import * as React from 'react';
import InputGroup from 'react-bootstrap/InputGroup';
import FormControl from 'react-bootstrap/FormControl';
import Button from 'react-bootstrap/Button';
import Spinner from 'react-bootstrap/Spinner';
import { LoginUser } from 'models/user';

type Props = {
    isLoginLoading: boolean,
    hasLoginError: boolean,
    logInUser: Function
}

type State = {
    user: LoginUser
}

export default class Login extends React.Component<Props, State> {

    constructor(props: Props){
        super(props);

        this.state = {
            user: {
                username: '',
                password: ''
            }
        }
    }

    isInfoValid = () => {
        return this.state.user.username
            && this.state.user.password;
    }

    handleLogin = (): void => {
        if(!this.props.isLoginLoading){
            if(this.isInfoValid()){
                this.props.logInUser(this.state.user);
            }
        }
    }

    onKeyDown = (evt: React.KeyboardEvent<HTMLInputElement>): void => {
        if(evt.key === 'Enter'){
            this.handleLogin();
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

    render() {
        return (
            <div className="form-page">
                <div className="form-wrapper">
                    <div className="form-container">
                        <div className="title">log in</div>
                        <form className="input-group">
                            <InputGroup className="mb-3">
                                <InputGroup.Prepend>
                                    <InputGroup.Text>
                                        <i className="fa fa-user-circle-o" aria-hidden="true"/>
                                    </InputGroup.Text>
                                </InputGroup.Prepend>
                                <FormControl
                                    autoComplete="username"
                                    placeholder="username"
                                    value={this.state.user.username}
                                    onKeyDown={this.onKeyDown}
                                    onChange={(evt: any) => this.updateUserField('username', evt.target.value)}
                                />
                            </InputGroup>
                            <InputGroup className="mb-3">
                                <InputGroup.Prepend>
                                    <InputGroup.Text>
                                        <i className="fa fa-key-modern" aria-hidden="true"/>
                                    </InputGroup.Text>
                                </InputGroup.Prepend>
                                <FormControl
                                    type="password"
                                    autoComplete="current-password"
                                    placeholder="password"
                                    value={this.state.user.password}
                                    onKeyDown={this.onKeyDown}
                                    onChange={(evt: any) => this.updateUserField('password', evt.target.value)}
                                />
                            </InputGroup>
                        </form>
                        <Button
                            disabled={this.props.isLoginLoading}
                            variant="primary"
                            size="lg"
                            block
                            onClick={this.handleLogin}>
                            {this.props.isLoginLoading &&
                                <Spinner
                                    as="span"
                                    animation="border"
                                    size="sm"
                                    role="status"
                                    aria-hidden="true"
                                    />}
                            {this.props.isLoginLoading
                                ? ' loading...'
                                : ' log in'}
                        </Button>
                    </div>
                </div>
            </div>
        );
    }
}