import React from "react";
import s from "./CheckOutModal.module.css";
import { IoMdClose } from "react-icons/io";
import { useForm } from "react-hook-form";
import * as z from "zod";
import { zodResolver } from "@hookform/resolvers/zod";

const schema = z.object({
  username: z.string().min(6),
  password: z.string().min(6),
});
const CheckOutModal = ({ handleClickOutside }) => {
  const {
    register,
    handleSubmit,
    watch,
    formState: { errors, isSubmitting },
  } = useForm({
    defaultValues: {
      username: "",
      password: "",
    },
    resolver: zodResolver(schema),
    reValidateMode: "onBlur",
    mode: "onBlur",
  });

  const onSubmit = (data) => {
    console.log(data);
  };

  const handleStopPropagation = (event) => {
    event.stopPropagation();
  };

  return (
    <div className={s.overlay} onClick={handleClickOutside}>
      <div className={s.container} onClick={handleStopPropagation}>
        <header className={s.header}>
          <h2>Thanh toán</h2>
          <span onClick={handleClickOutside}>
            <IoMdClose size={26} />
          </span>
        </header>
        <section className={s.content}>
          <form className={s.form}>
            <div className={s.inputField}>
              <label>Tên đăng nhập</label>
              <input {...register("username")} />
              {errors.username && (
                <span className={s.error}>Ít nhất 6 ký tự</span>
              )}
            </div>
            <div className={s.inputField}>
              <label>Mật khẩu</label>
              <input {...register("password")} />
              {errors.password && (
                <span className={s.error}>Ít nhất 6 ký tự</span>
              )}
            </div>
          </form>
          <div className={s.contentRight}>
            <ul className={s.note}>
              <li>Điền chính nơi nhận hàng</li>
              <li>Xác nhận lại số lượng đơn hàng </li>
              <li>Kiểm tra lại tổng tiền đơn hàng</li>
              <li>Vui lòng cung cung cấp đầy đủ thông tin và chính xác</li>
            </ul>
          </div>
        </section>
        <footer className={s.footer}>
          <button onClick={handleSubmit(onSubmit)}>Thanh toán</button>
        </footer>
      </div>
    </div>
  );
};

export default CheckOutModal;
