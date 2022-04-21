import React from 'react';
import { createStackNavigator } from '@react-navigation/stack'
import Home from '../pages/Home';
import Profile from '../pages/Profile';
import TransactionPix from '../pages/TransactionPix';
import Extrato from '../pages/Extrato';

const App = createStackNavigator();

const AppRoutes: React.FC = () => (
    <App.Navigator
        screenOptions={{
            headerShown: false,
            cardStyle: { backgroundColor: '#312e38' },
        }}>
        <App.Screen name="Home" component={Home} />
        <App.Screen name="Profile" component={Profile} />
        <App.Screen name="TransactionPix" component={TransactionPix} />
        <App.Screen name="Extrato" component={Extrato} />
    </App.Navigator>
);

export default AppRoutes;
