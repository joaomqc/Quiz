import * as React from 'react';
import InputGroup from 'react-bootstrap/InputGroup';
import FormControl from 'react-bootstrap/FormControl';
import Button from 'react-bootstrap/Button';
import { RegisterUser } from 'models/user';

type Props = {
    isRegisterLoading: boolean,
    hasRegisterError: boolean,
    registerUser: Function
}

type State = {
    user: RegisterUser
}

export default class Register extends React.Component<Props, State> {

    constructor(props: Props){
        super(props);

        this.state = {
            user: {
                email: '',
                username: '',
                password: ''
            }
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

    handleRegister = () => {
        this.props.registerUser({
            ...this.state.user
        });
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
                                    autoComplete="new-password"
                                    type="password"
                                    placeholder="password"
                                    value={this.state.user.password}
                                    onChange={(evt: any) => this.updateUserField('password', evt.target.value)}
                                />
                            </InputGroup>
                        </form>
                        <Button
                            variant="primary"
                            size="lg"
                            block
                            onClick={this.handleRegister}>
                            register
                        </Button>
                    </div>
                </div>
            </div>
        );
    }
}