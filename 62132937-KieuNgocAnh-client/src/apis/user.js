import request from "../../utils/axios";

export const login = async (data) => {
  try {
    const response = await request.get(`/Login`, data);
    return response.data;
  } catch (error) {
    alert(error);
  }
};

export const signup = async (data) => {
  try {
    const response = await request.get(`/Register`, data);
    return response.data;
  } catch (error) {
    alert(error);
  }
};
