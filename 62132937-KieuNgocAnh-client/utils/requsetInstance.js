import useAuthStore from "../src/hooks/useAuthStore";
import request from "./axios";

const requestInstance = request;
requestInstance.interceptors.request.use((config) => {
    const token = useAuthStore.getState().token;
    if (token) {
        config.headers.Authorization = "Bearer " + token;
    }
    return config;
});

export default requestInstance;