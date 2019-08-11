import { connect } from 'react-redux';

import NavBar from './navbar';
import { isUserAuthenticated, revokeAuthentication } from 'shared/authentication';
import { withRouter } from 'react-router';
import { push } from 'react-router-redux';
import { Routes } from 'app/routes';

function mapStateToProps(state: any, props: any) {
    return {
        isUserAuthenticated: isUserAuthenticated(),
        currentPath: props.location.pathname
    }
}

function mapDispatchToProps(dispatch: Function) {
    return {
        logUserOut: () => {
            revokeAuthentication();
            dispatch(push(Routes.Home.path))
        }
    }
}

const NavBarContainer = connect(
    mapStateToProps,
    mapDispatchToProps
) (NavBar);

export default withRouter(NavBarContainer);