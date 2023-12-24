import request from "../../utils/axios";
import qs from "query-string";
import requestInstance from "../../utils/requsetInstance";

export const getProducts = async() => {
    const url = qs.stringifyUrl({
        url: "/ProductController_62132937",
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
        const response = await request.get(`/ProductController_62132937/${id}`);
        return response.data;
    } catch (error) {
        alert(error);
    }
};

export const getProductsByCategoryIdOrKeyword = async(id, keyword) => {
    const url = qs.stringifyUrl({
        url: "/ProductController_62132937/search",
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
        const response = await requestInstance.post("/ProductController_62132937", data, {
            headers: {
                "Content-Type": "multipart/form-data",
            }
        });
        return response.data;
    } catch (error) {
        alert(error);
    }
};


export const deleteProduct = async(id) => {
    try {
        const response = await requestInstance.delete(`/ProductController_62132937/${id}`);
        return response.data;
    } catch (error) {
        alert(error);
    }
};