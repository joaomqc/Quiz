import React, { Component } from 'react';
import { StyleSheet, Text, View } from 'react-native';
import SplashScreen from 'quiz-app/src/screens/SplashScreen';
import { getAllTopics } from 'quiz-app/src/services/quizzesService';
import { thisExpression } from '@babel/types';

type Props = {};
export default class Home extends Component<Props> {

    constructor(props) {
        super(props);

        this.state = {
            isLoading: true,
            topics: []
        };
    }

    componentDidMount() {
        getAllTopics()
            .then(response => {
                this.setState({
                    isLoading: false,
                    topics: response.data.topics
                });
            });
    }

    render() {
        if (this.state.isLoading) {
            return <SplashScreen />;
        }

        return (
            <View style={styles.container}>
                {this.state.topics.map(topic => (
                    <Text key={topic.topicId}>{topic.name}</Text>
                ))}
            </View>
        );
    }
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems: 'center',
        backgroundColor: '#F5FCFF'
    }
});
