import { useNavigate } from "react-router";
import * as z from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import s from "./AddProduct.module.css";
import useCategoryStore from "../../hooks/useCategoryStore";
import { createProduct } from "../../apis/products";

const schema = z.object({
  name: z.string().min(6),
  price: z.string().min(1),
  file: z.any(),
  categoryId: z.string()
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
      categoryId: "1",
    },
    resolver: zodResolver(schema),
    reValidateMode: "onBlur",
    mode: "onBlur",
  });

  const onSubmit = async (data) => {
    try {
      const newData = {
        ...data,
        price: parseInt(data?.price),
        categoryId:parseInt(data?.categoryId),
        file: data?.file[0]
      }
      const response = await createProduct(newData);
      console.log(response);
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
          {errors.name && <span className={s.error}>Ít nhất 6 ký tự</span>}
        </div>
        <div className={s.inputField}>
          <label>Giá</label>
          <input type="string" {...register("price")} />
          {errors.price && <span className={s.error}>Ít nhất 1 ký tự</span>}
        </div>
        <div className={s.inputField}>
          <label>Hình ảnh</label>
          <input type="file" {...register("file")} />
          {errors.file && (
            <span className={s.error}>Vui long chọn file</span>
          )}
        </div>
        <div className={s.inputField}>
          <label>Danh mục</label>
          <select
            className={s.inputField}
            id="selectmethod"
            defaultValue=""
            name="categoryId"
            {...register("categoryId")}
          >
            {categories?.map((item) => (
              <option value={item.id} key={item.id}>{item?.name}</option>
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
