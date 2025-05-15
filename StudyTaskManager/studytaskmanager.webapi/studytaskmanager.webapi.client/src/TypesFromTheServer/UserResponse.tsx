import axios from "axios";

export interface UserResponse {
    userId: string;
    username: string;
    email: string;
    isEmailVerifed: boolean;
    isPhoneNumberVerifed: boolean;
    phoneNumber: string | null;
    registrationDate: string;
    systemRoleId: string | null;
}

// ������� ��� ��������� ������������ �� ID
const fetchUserById = async (userId: string): Promise<UserResponse | null> => {
    try {
        const response = await axios.get(
            `https://localhost:7241/api/Users/${userId}`,
            { withCredentials: true }
        );
        return response.data;
    } catch (error) {
        console.error(`������ ��� �������� ������������ � ID ${userId}`, error);
        return null;
    }
};