import request from "../../utils/axios";

export const getCategories = async() => {
    try {
        const response = await request.get("/CategoryController_62132937");
        return response.data;
    } catch (error) {
        alert(error);
    }
};