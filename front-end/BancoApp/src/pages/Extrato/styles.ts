import { Platform } from 'react-native';
import styled from 'styled-components/native';

export const Container = styled.View`
    flex: 1;
    margin-left: 20px;
    padding: 0 0px ${Platform.OS === 'android' ? 100 : 40}px;
`;

export const Title = styled.Text`
    font-size: 25px;
    color: #f4ede8;
    font-family: 'RobotoSlab-Medium';
    margin: 30px 20px 5px;
    font-weight: 800;
`;

export const Box = styled.View`
    margin-top: 20px;
    margin-left: 30px;
`;

export const Label = styled.Text`
    color: #fff;
    font-weight: 700;
`;

export const Data = styled.Text`
    color: #fff;
    margin-left: 20px;
`;

export const Back = styled.TouchableOpacity`
    position: absolute;
    left: 0;
    right: 0;
    bottom: 0;
    background: #312e38;
    border-top-width: 1px;
    border-color: #232129;
    padding: 16px 0 16px;

    justify-content: center;
    align-items: center;
    flex-direction: row;
`;

export const BackText = styled.Text`
    color: #fff;
    font-size: 18px;
    font-family: 'RobotoSlab-Regular';
    margin-left: 16px;
`;

