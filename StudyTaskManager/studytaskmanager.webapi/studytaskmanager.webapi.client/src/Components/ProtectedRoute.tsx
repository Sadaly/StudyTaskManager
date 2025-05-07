import React from 'react';
import { Navigate, Outlet } from 'react-router-dom';

const isAuthenticated = (): boolean => {
    // ����� �� ������ ������������ ��������� ���������, �������� ��� ������ � API
    // ������: �������� ������� ���� (���� JWT �������� � HttpOnly, ���� ����������� ������)
    const token = document.cookie.includes('access_token');
    return token;
};

const ProtectedRoute: React.FC = () => {
    return isAuthenticated() ? <Outlet /> : <Navigate to="/login" />;
};

export default ProtectedRoute;
