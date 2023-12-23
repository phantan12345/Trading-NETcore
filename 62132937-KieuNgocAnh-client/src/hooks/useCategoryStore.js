import { create } from "zustand";

const useCategoryStore = create((set) => ({
  categories: [],
  setCategories: (data) =>
    set((state) => ({
      ...state,
      categories: data,
    })),
}));

export default useCategoryStore;
