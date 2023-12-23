import useAuthStore from "../src/hooks/useAuthStore";
import request from "./axios";

const requsetInstance = request;
requsetInstance.interceptors.request.use((config) => {
  const token = useAuthStore.getState().loginData?.token;
  if (token) {
    config.headers.Authorization = "Bearer " + token;
  }
  return config;
});

export default requsetInstance;
