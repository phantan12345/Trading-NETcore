import request from "../../utils/axios";

export const getCategories = async () => {
  try {
    const response = await request.get("/Category");
    return response.data;
  } catch (error) {
    alert(error);
  }
};
