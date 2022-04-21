import { FormHandles } from '@unform/core';
import { Form } from '@unform/mobile';
import * as Yup from 'yup';
import React, { useCallback, useRef } from 'react';
import { Alert, KeyboardAvoidingView, Platform, ScrollView, TextInput } from 'react-native';
import Button from '../../components/Button';
import Input from '../../components/Input';
import { Transaction } from '../../interfaces/transaction';
import { useAuth } from '../../hooks/auth';
import api from '../../services/api';
import { useNavigation } from '@react-navigation/native';
import getValidationErrors from '../../utils/getValidationErrors';

import { Back, BackText, Container, Title } from './styles';
import Icon from 'react-native-vector-icons/Feather';

const TransactionPix: React.FC = () => {
    const navigation = useNavigation();
    const { user } = useAuth();

    const formRef = useRef<FormHandles>(null);
    const pixKeyInputRef = useRef<TextInput>(null);
    const valueInputRef = useRef<TextInput>(null);

    const handleTransaction = useCallback(
        async (data: Transaction) => {
            try {
                formRef.current?.setErrors({});

                data.idClientOrigin = user.id;
                data.idClientDestiny = 0;

                const schema = Yup.object().shape({
                    pixKeyDestiny: Yup.string().required('Chave pix obrigatória'),
                    value: Yup.string().nullable()
                });

                await schema.validate(data, {
                    abortEarly: false,
                });

                data.value = parseFloat(data.value.toString());

                console.log(data)

                await api.post('transferencia', data);

                Alert.alert('Pix realizado com sucesso', 'Você pode visualizar os detalhes no extrato');

                navigation.navigate('Home');

            } catch (err) {
                if (err instanceof Yup.ValidationError) {
                    const errors = getValidationErrors(err);
                    formRef.current?.setErrors(errors);
                    return;
                }
                Alert.alert('Erro na autenticação', 'Ocorreu um erro ao fazer login, cheque as credenciais.')
            }
        }, []);

    return (
        <KeyboardAvoidingView
            behavior={Platform.OS === 'ios' ? 'padding' : undefined}
            style={{ flex: 1 }}
        >
            <ScrollView
                keyboardShouldPersistTaps="handled"
                contentContainerStyle={{ flex: 1 }}
            >
                <Title>Pix</Title>
                <Container>
                    {/* <Image source={logoImage} /> */}
                    <Form ref={formRef} onSubmit={handleTransaction}>
                        <Input
                            ref={pixKeyInputRef}
                            name="pixKeyDestiny"
                            icon="key"
                            placeholder="Chave pix"
                            returnKeyType="next"
                            onSubmitEditing={() => valueInputRef.current?.focus()}
                        />
                        <Input
                            ref={valueInputRef}
                            name="value"
                            icon="dollar-sign"
                            placeholder="Valor"
                            returnKeyType="send"
                            onSubmitEditing={() => formRef.current?.submitForm()}
                        />
                        <Button onPress={() => formRef.current?.submitForm()}>
                            Enviar
                        </Button>
                    </Form>

                </Container>
            </ScrollView>
            <Back onPress={() => navigation.goBack()}>
                <Icon name="arrow-left" size={20} color="#fff" />
                <BackText>Voltar</BackText>
            </Back>
        </KeyboardAvoidingView>
    );
}

export default TransactionPix;
