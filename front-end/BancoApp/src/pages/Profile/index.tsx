import React from 'react';
import { KeyboardAvoidingView, Platform, Text, View } from 'react-native';
import Button from '../../components/Button';
import { useAuth } from '../../hooks/auth';

import { Container } from './styles';

const Profile: React.FC = () => {
    const { signOut } = useAuth();
    return (
        <KeyboardAvoidingView
            behavior={Platform.OS === 'ios' ? 'padding' : undefined}
            style={{ flex: 1 }}>
            <Container>
                <View>
                    <Button onPress={() => signOut()}>sair</Button>
                </View>
            </Container>
        </KeyboardAvoidingView>
    );
};

export default Profile;
