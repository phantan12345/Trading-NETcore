import { create } from "zustand";

const useCart = create((set) => ({
  listCarts: JSON.parse(localStorage.getItem("listCarts")) || [],
  total: JSON.parse(localStorage.getItem("totalCart")) || 0,
  setListCarts: (product, quantity) =>
    set((state) => {
      const updatedCarts = state.listCarts ? [...state.listCarts] : [];

      // Kiểm tra xem sản phẩm đã có trong danh sách chưa
      const existingProductIndex = updatedCarts.findIndex(
        (item) => item.id === product.id
      );

      if (existingProductIndex !== -1) {
        // Nếu sản phẩm đã có, cập nhật số lượng
        const updatedQuantity =
          updatedCarts[existingProductIndex].quantity + quantity;

        updatedCarts[existingProductIndex] = {
          ...updatedCarts[existingProductIndex],
          quantity: updatedQuantity,
        };

        // Kiểm tra và xóa nếu số lượng là 0
        if (updatedQuantity <= 0) {
          updatedCarts.splice(existingProductIndex, 1);
        }
      } else {
        // Nếu sản phẩm chưa có, thêm vào danh sách
        updatedCarts.push({ ...product, quantity: quantity });
      }

      //Tính tổng dựa trên các giỏ hàng đã cập nhật
      const updatedTotal = updatedCarts.reduce((acc, cartItem) => {
        return acc + cartItem.quantity * cartItem.price;
      }, 0);
      localStorage.setItem("totalCart", JSON.stringify(updatedTotal));
      localStorage.setItem("listCarts", JSON.stringify(updatedCarts));
      return { ...state, listCarts: updatedCarts, total: updatedTotal };
    }),
  deleteCarts: (id) =>
    set((state) => {
      const updatedCarts = state.listCarts ? [...state.listCarts] : [];
      const filteredCarts = updatedCarts.filter((item) => item.id !== id);

      const updatedTotal = filteredCarts.reduce((acc, cartItem) => {
        return acc + cartItem.quantity * cartItem.price;
      }, 0);

      localStorage.setItem("totalCart", JSON.stringify(updatedTotal));
      localStorage.setItem("listCarts", JSON.stringify(filteredCarts));
      return { ...state, listCarts: filteredCarts, total: updatedTotal };
    }),
}));

export default useCart;
