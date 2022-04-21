import { useNavigation } from '@react-navigation/native';
import React from 'react';
import Button from '../../components/Button';
import { useAuth } from '../../hooks/auth';
import Icon from 'react-native-vector-icons/Feather';

import { Container, SignOut, SignOutText, Title } from './styles';

const Home: React.FC = () => {
    const { signOut } = useAuth();
    const navigation = useNavigation();
    return (
        <>
            <Title>Home</Title>
            <Container>
                <Button onPress={() => navigation.navigate('Profile')} >
                    Perfil
                </Button>
                <Button onPress={() => navigation.navigate('TransactionPix')} >
                    Pix
                </Button>
                <Button onPress={() => navigation.navigate('Extrato')} >
                    Extrato
                </Button>

                <SignOut onPress={() => signOut()}>
                    <Icon name="log-out" size={20} color="#fff" />
                    <SignOutText>Sair</SignOutText>
                </SignOut>
            </Container>
        </>
    );
};

export default Home;
