import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { StatusBar, View } from 'react-native';
import Routes from './routes';
import AppProvider from './hooks';

const App = () => {
    return (
        <NavigationContainer>
            <StatusBar barStyle="light-content" backgroundColor="#312e38" />
            <AppProvider>
                <View style={{ flex: 1, backgroundColor: '#312e38' }}>
                    <Routes />
                </View>
            </AppProvider>
        </NavigationContainer>
    );
};

export default App;
