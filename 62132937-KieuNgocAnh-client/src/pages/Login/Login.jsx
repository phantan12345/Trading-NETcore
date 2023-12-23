import React from "react";
import s from "./Login.module.css";
import { useNavigate } from "react-router";
import * as z from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { Link } from "react-router-dom";
import useAuthStore from "../../hooks/useAuthStore";
import { login } from "../../apis/user";

const schema = z.object({
  username: z.string().min(6),
  password: z.string().min(6),
});
const Login = () => {
  const { setToken } = useAuthStore();
  const navigate = useNavigate();

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

  const onSubmit = async (data) => {
    try {
      const response = await login(data);
      setToken(response);
      navigate("/");
    } catch (error) {
      alert(error);
    }
  };

  return (
    <div className={s.container}>
      <section className={s.wrapper}>
        <div className={s.sideLeft}></div>
        <div className={s.sideRight}>
          <h2>Đăng nhập</h2>
          <form onSubmit={handleSubmit(onSubmit)} className={s.form}>
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
              Đăng nhập
            </button>
          </form>
          <p>
            Bạn chưa có tài khoản?
            <Link to="/dang-ky"> đăng ký tại đây</Link>
          </p>
        </div>
      </section>
    </div>
  );
};

export default Login;
