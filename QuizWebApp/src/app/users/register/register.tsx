import * as React from 'react';
import InputGroup from 'react-bootstrap/InputGroup';
import FormControl from 'react-bootstrap/FormControl';
import Button from 'react-bootstrap/Button';
import Spinner from 'react-bootstrap/Spinner';
import { RegisterUser } from 'models/user';

type Props = {
    isRegisterLoading: boolean,
    hasRegisterError: boolean,
    registerUser: Function,
}

type State = {
    user: RegisterUser,
    isRegistering: boolean
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
            isRegistering: false
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
        
        return !user.email
            || !user.username
            || !user.password;
    }

    handleRegister = () => {
        if(!this.isUserValid()){
            this.setState({
                isRegistering: true
            })
        }
    }

    componentDidUpdate(prevProps: Props, prevState: State){
        if(prevProps.isRegisterLoading
            && !this.props.isRegisterLoading
            && this.props.hasRegisterError){
            this.setState({
                isRegistering: false
            })
        }

        if(!prevState.isRegistering && this.state.isRegistering){
            this.props.registerUser({
                ...this.state.user
            });
        }
    }

    onKeyDown = (evt: React.KeyboardEvent<HTMLInputElement>): void => {
        if(evt.key === 'Enter' && !this.state.isRegistering){
            this.handleRegister();
        }
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
                                    onChange={(evt: any) => this.updateUserField('email', evt.target.value)}
                                />
                            </InputGroup>
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
                                    onKeyDown={this.onKeyDown}
                                    autoComplete="new-password"
                                    type="password"
                                    placeholder="password"
                                    value={this.state.user.password}
                                    onChange={(evt: any) => this.updateUserField('password', evt.target.value)}
                                />
                            </InputGroup>
                        </form>
                        <Button
                            disabled={this.state.isRegistering || !this.isUserValid()}
                            variant="primary"
                            size="lg"
                            block
                            onClick={this.handleRegister}>
                            {this.state.isRegistering &&
                                <Spinner
                                    as="span"
                                    animation="border"
                                    size="sm"
                                    role="status"
                                    aria-hidden="true"
                                    />}
                            {this.state.isRegistering
                                ? ' loading...'
                                : ' register'}
                        </Button>
                    </div>
                </div>
            </div>
        );
    }
}