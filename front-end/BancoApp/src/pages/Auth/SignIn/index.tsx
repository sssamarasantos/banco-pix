/* eslint-disable @typescript-eslint/no-unused-vars */
import { useNavigation } from '@react-navigation/native';
import React, { useCallback, useRef } from 'react';
import {
    Image,
    ScrollView,
    KeyboardAvoidingView,
    Platform,
    TextInput,
    Alert
} from 'react-native';
import Icon from 'react-native-vector-icons/Feather';
import * as Yup from 'yup';
import { Form } from '@unform/mobile';
import {
    Container,
    Title,
    CreateAccountButton,
    CreateAccountButtonText,
} from './styles';
import { FormHandles } from '@unform/core';
import { useAuth } from '../../../hooks/auth';
import Input from '../../../components/Input';
import getValidationErrors from '../../../utils/getValidationErrors';
import Button from '../../../components/Button';

interface SignInFormData {
    cpf: string;
    password: string;
}

const SignIn: React.FC = () => {
    const navigation = useNavigation();
    const formRef = useRef<FormHandles>(null);
    const passwordInputRef = useRef<TextInput>(null);

    const { signIn } = useAuth();

    const handleSignIn = useCallback(
        async (data: SignInFormData) => {
            try {
                formRef.current?.setErrors({});

                const schema = Yup.object().shape({
                    cpf: Yup.string()
                        .required('CPF obrigatório'),
                    password: Yup.string().min(6, 'Senha obrigatória'),

                });

                await schema.validate(data, {
                    abortEarly: false,
                });

                await signIn({
                    cpf: data.cpf,
                    password: data.password,
                });

                navigation.navigate('Profile');

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
                        <Title>Faça seu login</Title>
                        <Form ref={formRef} onSubmit={handleSignIn}>
                            <Input
                                name="cpf"
                                icon="user"
                                placeholder="CPF"
                                autoCorrect={false}
                                autoCapitalize="none"
                                keyboardType="numbers-and-punctuation"
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
                                returnKeyType="send"
                                onSubmitEditing={() => formRef.current?.submitForm()}
                            />
                            <Button onPress={() => formRef.current?.submitForm()}>
                                Entrar
                            </Button>
                        </Form>
                    </Container>
                    <CreateAccountButton
                        onPress={() => navigation.navigate('SignUp')}
                    >
                        <Icon name="log-in" size={20} color="#ff9000" />
                        <CreateAccountButtonText>
                            Crie uma conta
                        </CreateAccountButtonText>
                    </CreateAccountButton>
                </ScrollView>
            </KeyboardAvoidingView>
        </>
    );
};

export default SignIn;
