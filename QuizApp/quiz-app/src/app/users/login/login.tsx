import * as React from 'react';
import InputGroup from 'react-bootstrap/InputGroup';
import FormControl from 'react-bootstrap/FormControl';
import Button from 'react-bootstrap/Button';

type Props = {}

type State = {
    username: string,
    password: string
}

export default class Login extends React.Component<Props, State> {

    constructor(props: Props){
        super(props);

        this.state = {
            username: '',
            password: ''
        }
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
                                    value={this.state.username}
                                    onChange={(evt: any) => this.setState({username: evt.target.value})}
                                />
                            </InputGroup>
                            <InputGroup className="mb-3">
                                <InputGroup.Prepend>
                                    <InputGroup.Text>
                                        <i className="fa fa-key-modern" aria-hidden="true"/>
                                    </InputGroup.Text>
                                </InputGroup.Prepend>
                                <FormControl
                                    autoComplete="current-password"
                                    placeholder="password"
                                    value={this.state.password}
                                    onChange={(evt: any) => this.setState({password: evt.target.value})}
                                />
                            </InputGroup>
                        </form>
                        <Button
                            variant="primary"
                            size="lg"
                            block>
                            log in
                        </Button>
                    </div>
                </div>
            </div>
        );
    }
}