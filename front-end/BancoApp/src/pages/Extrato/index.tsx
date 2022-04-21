import { useNavigation } from '@react-navigation/native';
import React, { useEffect, useState } from 'react';
import { ScrollView, Text, View } from 'react-native';
import Icon from 'react-native-vector-icons/Feather';
import { useAuth } from '../../hooks/auth';
import { BankStatement } from '../../interfaces/bankStatement';
import api from '../../services/api';
import { Back, BackText, Box, Container, Data, Label, Title } from './styles';

// import { Container } from './styles';

const Extrato: React.FC = () => {
    const navigation = useNavigation();
    const { user } = useAuth();
    const [dadosExtrato, setDadosExtrato] = useState<BankStatement[]>([]);

    useEffect(() => {
        async function loadExtrato() {
            const { data } = await api.get(`extrato/${user.id}`);
            setDadosExtrato(data);
        }

        loadExtrato();
    }, []);

    return (
        <>
            <Title>Extrato</Title>
            <ScrollView>
                <Container>
                    {dadosExtrato.map(item => (
                        <>
                            <Box>
                                <Data>
                                    <Label>Nome: </Label>
                                    {item.nameClientOrigin}
                                </Data>

                                <Data>
                                    <Label>Valor: </Label>
                                    {item.value}
                                </Data>

                                <Data>
                                    <Label>Data: </Label>
                                    {item.date}
                                </Data>
                            </Box>
                        </>
                    ))}


                </Container>
            </ScrollView>
            <Back onPress={() => navigation.goBack()}>
                <Icon name="arrow-left" size={20} color="#fff" />
                <BackText>Voltar</BackText>
            </Back>
        </>
    );
}

export default Extrato;
