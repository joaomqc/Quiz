import { connect } from 'react-redux';

import Home from './home';

function mapStateToProps(state: any, props: any) {
    return {
    }
}

function mapDispatchToProps(dispatch: Function) {
    return {
    }
}

const HomeContainer = connect(
    mapStateToProps,
    mapDispatchToProps
) (Home);

export default HomeContainer;