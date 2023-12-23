import { useNavigate } from "react-router";
import * as z from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import s from "./AddProduct.module.css";
import useCategoryStore from "../../hooks/useCategoryStore";
import { createProduct } from "../../apis/products";

const schema = z.object({
  name: z.string().min(6),
  price: z.string().min(2),
  image: z.object().nullable(),
});

export default function AddProduct() {
  const { categories } = useCategoryStore();
  const {
    register,
    handleSubmit,
    watch,
    formState: { errors, isSubmitting },
  } = useForm({
    defaultValues: {
      name: "",
      price: "",
      iamge: null,
    },
    resolver: zodResolver(schema),
    reValidateMode: "onBlur",
    mode: "onBlur",
  });

  const onSubmit = async (data) => {
    try {
      const response = await createProduct(data);
      setToken(response);
    } catch (error) {
      alert(error);
    }
  };

  return (
    <div className={s.container}>
      <h1>Thêm sản phẩm</h1>
      <form onSubmit={handleSubmit(onSubmit)} className={s.form}>
        <div className={s.inputField}>
          <label>Tên sản phẩm</label>
          <input {...register("name")} />
          {errors.username && <span className={s.error}>Ít nhất 6 ký tự</span>}
        </div>
        <div className={s.inputField}>
          <label>Giá</label>
          <input {...register("price")} />
          {errors.password && <span className={s.error}>Ít nhất 2 ký tự</span>}
        </div>
        <div className={s.inputField}>
          <label>Hình ảnh</label>
          <input type="file" {...register("image")} />
          {errors.password && (
            <span className={s.error}>Vui loàng chọn file</span>
          )}
        </div>
        <div className={s.inputField}>
          <label>Danh mục</label>
          <select
            className={s.inputField}
            id="selectmethod"
            defaultValue=""
            name="categoryId"
            {...register("categoryId", { required: true })}
          >
            {categories?.map((item) => (
              <option value={item.id}>{item?.name}</option>
            ))}
          </select>
        </div>
        <button type="submit" className={s.btnSubmit}>
          Thêm sản phẩm
        </button>
      </form>
    </div>
  );
}
