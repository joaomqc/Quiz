import { connect } from 'react-redux';

import Home from './home';
import { getTopics } from 'mockData';

function mapStateToProps(state: any, props: any) {
    return {
        topics: getTopics()
    }
}

const HomeContainer = connect(
    mapStateToProps
) (Home);

export default HomeContainer;