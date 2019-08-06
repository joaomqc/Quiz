import React, { Component } from 'react';
import { StyleSheet, Image, View, Text } from 'react-native';

type Props = {};
export default class SplashScreen extends Component<Props> {

    render() {
        return (
            <View style={styles.container}>
                <View style={styles.logoContainer}>
                    <Image
                        source={{ uri: 'https://facebook.github.io/react/logo-og.png' }}
                        style={styles.logo}
                    />
                </View>
                <View style={styles.textContainer}>
                    <Text style={styles.text}>Loading...</Text>
                </View>
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
        backgroundColor: '#79C0FF'
    },
    logo: {
        width: '50%',
        height: undefined,
        aspectRatio: 1
    },
    logoContainer: {
        height: '95%',
        justifyContent: 'center'
    },
    textContainer: {
        height: '5%',
    }
})