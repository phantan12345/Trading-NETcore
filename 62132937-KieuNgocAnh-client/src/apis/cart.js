import requestInstance from "../../utils/requsetInstance"


export const checkout = async(data) => {
    try {
        const response = await requestInstance.post("CartController_62132937", data, {
            headers: {
                "Content-Type": "application/json",
            },
        })
        return response.data;
    } catch (error) {
        alert(error)
    }
}