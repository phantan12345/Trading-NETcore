import request from "../../utils/axios";
import axios from "axios";

export const getProducts = async () => {
  //   console.log(import.meta.env.VITE_BASE_URL);
  try {
    const response = await request.get("/products");
    return response.data;
  } catch (error) {
    alert(error);
  }
};

export const getProduct = async (id) => {
  console.log(id);
  try {
    const response = await request.get(`/products/${id}`);
    return response.data;
  } catch (error) {
    alert(error);
  }
};