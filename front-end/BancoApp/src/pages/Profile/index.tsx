import { useNavigation } from '@react-navigation/native';
import React, { useEffect, useState } from 'react';
import { Text } from 'react-native';
import Icon from 'react-native-vector-icons/Feather';
import { useAuth } from '../../hooks/auth';
import { User } from '../../interfaces/user';
import api from '../../services/api';

import { Back, BackText, Box, Container, Data, Label, Title } from './styles';

const Profile: React.FC = () => {
    const navigation = useNavigation();
    const { user } = useAuth();

    const [userProfile, setUserProfile] = useState<User>({} as User);

    useEffect(() => {
        async function loadUser() {
            const { data } = await api.get(`cliente/${user.id}`);
            setUserProfile(data);
        }

        loadUser();
    }, []);

    return (
        <>
            <Title>Perfil</Title>
            <Container>
                <Box>
                    <Label>Nome: </Label>
                    <Data>
                        {userProfile.name}
                    </Data>

                    <Label>CPF: </Label>
                    <Data>
                        {userProfile.cpf}
                    </Data>

                    <Label>Chave pix: </Label>
                    <Data>
                        {userProfile.pixKey}
                    </Data>

                    <Label>Valor: </Label>
                    <Data>
                        {`R$ ${userProfile.value}`}
                    </Data>
                </Box>


            </Container>
            <Back onPress={() => navigation.goBack()}>
                <Icon name="arrow-left" size={20} color="#fff" />
                <BackText>Voltar</BackText>
            </Back>
        </>
    );
}

export default Profile;
