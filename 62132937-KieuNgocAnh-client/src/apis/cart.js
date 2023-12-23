import requestInstance from "../../utils/requsetInstance"


export const checkout = async(data) => {
    try {
        const response = await requestInstance.post("Cart", data, {
            headers: {
                "Content-Type": "application/json",
            },
        })
        return response.data;
    } catch (error) {
        alert(error)
    }
}