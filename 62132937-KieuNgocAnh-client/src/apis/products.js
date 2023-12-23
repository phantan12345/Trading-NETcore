import request from "../../utils/axios";
import qs from "query-string";
import requestInstance from "../../utils/requsetInstance";

export const getProducts = async() => {
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

export const getProduct = async(id) => {
    try {
        const response = await request.get(`/Product/${id}`);
        return response.data;
    } catch (error) {
        alert(error);
    }
};

export const getProductsByCategoryIdOrKeyword = async(id, keyword) => {
    const url = qs.stringifyUrl({
        url: "/Product/search",
        query: {
            Kw: keyword,
            CategoryId: id,
        },
    });
    try {
        const response = await request.get(url);
        return response.data;
    } catch (error) {
        alert(error);
    }
};

export const createProduct = async(data) => {
    try {
        console.log(data);
        const response = await requestInstance.post("/Product", data, {
            headers: {
                "Content-Type": "multipart/form-data",
            }
        });
        return response.data;
    } catch (error) {
        alert(error);
    }
};