import React from "react";
import s from "./Register.module.css";
import * as z from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { useNavigate } from "react-router";
import { useForm } from "react-hook-form";
import { Link } from "react-router-dom";
import useAuthStore from "../../hooks/useAuthStore";
import { signup } from "../../apis/user";

const schema = z.object({
  name: z.string().min(6),
  username: z.string().min(6),
  password: z.string().min(6),
});
const Register = () => {
  const navigate = useNavigate();
  const { setToken } = useAuthStore();
  const {
    register,
    handleSubmit,
    watch,
    formState: { errors, isSubmitting },
  } = useForm({
    defaultValues: {
      username: "",
      password: "",
      email: "",
      role: 2
    },
    resolver: zodResolver(schema),
    reValidateMode: "onBlur",
    mode: "onBlur",
  });

  const onSubmit = async (data) => {
    try {
      const response = await signup(data);
      setToken(response);
      navigate("/dang-nhap");
    } catch (error) {
      alert(error);
    }
  };

  return (
    <div className={s.container}>
      <section className={s.wrapper}>
        <div className={s.sideLeft}></div>
        <div className={s.sideRight}>
          <h2>Đăng ký</h2>
          <form onSubmit={handleSubmit(onSubmit)} className={s.form}>
          <div className={s.inputField}>
              <label>Tên</label>
              <input {...register("name")} />
              {errors.name && (
                <span className={s.error}>Ít nhất 6 ký tự</span>
              )}
            </div>


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

            <button type="submit" className={s.btnSubmit}>
              Đăng ký
            </button>
          </form>
          <p>
            Bạn đã có tài khoản?
            <Link to="/dang-nhap"> đăng nhập tại đây</Link>
          </p>
        </div>
      </section>
    </div>
  );
};

export default Register;
