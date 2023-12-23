import { create } from "zustand";

const useImageStore = create((set) => ({
  newIamge: "",
  setImage: (data) =>
    set((state) => ({
      ...state,
      newIamge: data,
    })),
}));

export default useImageStore;
