import request from "../../utils/axios";
import qs from "query-string";
import requsetInstance from "../../utils/requsetInstance";

export const getProducts = async () => {
  const url = qs.stringifyUrl({
    url: "/Product",
  });
  try {
    const response = await request.get(url);
    return response.data;
  } catch (error) {
    alert(error);
  }
};

export const getProduct = async (id) => {
  try {
    const response = await request.get(`/Product/${id}`);
    return response.data;
  } catch (error) {
    alert(error);
  }
};

export const getProductsByCategoryIdOrKeyword = async (id, keyword) => {
  const url = qs.stringifyUrl({
    url: "/Products",
    query: {
      kw: keyword,
      categoryId: id,
    },
  });
  try {
    const response = await request.get(url);
    return response.data;
  } catch (error) {
    alert(error);
  }
};

export const createProduct = async () => {
  try {
    const response = await requsetInstance.post("/Product", data);
    return response.data;
  } catch (error) {
    console.log(error);
  }
};
