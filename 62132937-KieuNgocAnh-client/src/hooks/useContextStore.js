import { create } from "zustand";

const useContextStore = create((set) => ({
    imageUrl: import.meta.env.VITE_BASE_IMAGE,
}));

export default useContextStore;