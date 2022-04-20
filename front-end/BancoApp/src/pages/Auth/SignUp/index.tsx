import { useNavigation } from '@react-navigation/native';
import * as Yup from 'yup';
import { FormHandles } from '@unform/core';
import { Form } from '@unform/mobile';
import React, { useCallback, useRef } from 'react';
import {
    Image,
    ScrollView,
    KeyboardAvoidingView,
    Platform,
    TextInput,
    Alert,
} from 'react-native';
import Icon from 'react-native-vector-icons/Feather';

import { Container, Title, BackToSignIn, BackToSignInText } from './styles';
import api from '../../../services/api';
import getValidationErrors from '../../../utils/getValidationErrors';
import Input from '../../../components/Input';
import Button from '../../../components/Button';

interface SignUpProps {
    name: string;
    cpf: string;
    password: string;
    pixKey: string;
    value: number;
}

const SignUp: React.FC = () => {
    const navigation = useNavigation();
    const formRef = useRef<FormHandles>(null);
    const cpfInputRef = useRef<TextInput>(null);
    const passwordInputRef = useRef<TextInput>(null);
    const pixKeyInputRef = useRef<TextInput>(null);
    const valueInputRef = useRef<TextInput>(null);

    const handleSignUp = useCallback(
        async (data: SignUpProps) => {
            try {
                formRef.current?.setErrors({});
                const schema = Yup.object().shape({
                    name: Yup.string().required('Nome obrigatório'),
                    cpf: Yup.string()
                        .required('CPF obrigatório'),
                    password: Yup.string().min(6, 'Digite no minímo 6 dígitos'),
                    pixKey: Yup.string().required('Chave pix obrigatória'),
                    value: Yup.string().nullable()
                });

                await schema.validate(data, {
                    abortEarly: false,
                });

                data.value = parseFloat(data.value.toString());

                console.log(data)

                await api.post('cliente', data);

                Alert.alert('Cadastro realizado com sucesso', 'Você já pode fazer login');

                navigation.navigate('SignIn');

            } catch (err) {
                if (err instanceof Yup.ValidationError) {
                    const errors = getValidationErrors(err);
                    formRef.current?.setErrors(errors);
                    return;
                }
                Alert.alert('Erro na autenticação', 'Ocorreu um erro ao fazer login, cheque as credenciais.')
            }
        },
        [],
    );

    return (
        <>
            <KeyboardAvoidingView
                behavior={Platform.OS === 'ios' ? 'padding' : undefined}
                style={{ flex: 1 }}
            >
                <ScrollView
                    keyboardShouldPersistTaps="handled"
                    contentContainerStyle={{ flex: 1 }}
                >
                    <Container>
                        {/* <Image source={logoImage} /> */}

                        <Title>Crie sua conta</Title>
                        <Form ref={formRef} onSubmit={handleSignUp}>
                            <Input
                                name="name"
                                icon="user"
                                placeholder="Nome"
                                returnKeyType="next"
                                autoCapitalize="words"
                                onSubmitEditing={() => {
                                    cpfInputRef.current?.focus()
                                }}
                            />
                            <Input
                                ref={cpfInputRef}
                                name="cpf"
                                icon="user"
                                placeholder="CPF"
                                keyboardType="numeric"
                                autoCorrect={false}
                                autoCapitalize="none"
                                returnKeyType="next"
                                onSubmitEditing={() => {
                                    passwordInputRef.current?.focus()
                                }}
                            />
                            <Input
                                ref={passwordInputRef}
                                name="password"
                                icon="lock"
                                placeholder="Senha"
                                secureTextEntry
                                returnKeyType="next"
                                onSubmitEditing={() => pixKeyInputRef.current?.focus()}
                            />
                            <Input
                                ref={pixKeyInputRef}
                                name="pixKey"
                                icon="key"
                                placeholder="Chave pix"
                                returnKeyType="next"
                                onSubmitEditing={() => formRef.current?.submitForm()}
                            />
                            <Input
                                ref={valueInputRef}
                                name="value"
                                icon="dollar-sign"
                                placeholder="Valor"
                                returnKeyType="send"
                                onSubmitEditing={() => formRef.current?.submitForm()}
                            />
                            <Button onPress={() => { formRef.current?.submitForm() }}>
                                Cadastrar
                            </Button>
                        </Form>
                    </Container>

                    <BackToSignIn onPress={() => navigation.goBack()}>
                        <Icon name="arrow-left" size={20} color="#fff" />
                        <BackToSignInText>Voltar para login</BackToSignInText>
                    </BackToSignIn>
                </ScrollView>
            </KeyboardAvoidingView>
        </>
    );
};

export default SignUp;
