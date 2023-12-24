import request from "../../utils/axios";
import requestInstance from "../../utils/requsetInstance";

export const login = async(data) => {
    try {
        const response = await request.post(`UserController_62132937/login`, data, {
            headers: {
                "Content-Type": "application/json",
            },
        });
        return response.data;
    } catch (error) {
        alert(error);
    }
};

export const signup = async(data) => {
    try {
        const response = await request.post(`UserController_62132937/signup`, data, {
            headers: {
                "Content-Type": "application/json",
            },
        });
        return response.data;
    } catch (error) {
        alert(error);
    }
};

export const getCurrentUser = async() => {
    try {
        const response = await requestInstance.get(`UserController_62132937/curren-user`);
        return response.data;
    } catch (error) {
        alert(error);
    }
}