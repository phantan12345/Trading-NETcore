import { create } from "zustand";

const useAuthStore = create((set) => ({
  token: JSON.parse(localStorage.getItem("access_token")) || null,
  setToken: (token) =>
    set((state) => {
      localStorage.setItem("access_token", JSON.stringify(token));
      return {
        ...state,
        token,
      };
    }),
}));

export default useAuthStore;
